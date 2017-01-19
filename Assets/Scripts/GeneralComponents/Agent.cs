using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;


public class Agent : MonoBehaviour
{
	public List<AgentBehaviour> behaviours = new List<AgentBehaviour>();

	Dictionary<Type, List<ObjectPool>> tasksSet;
	PrimitiveAgentBehaviour currentTaskBehaviour;

	AgentBehaviour currentBehaviour;

	void UpdateAI()
	{
		if (currentBehaviour != null && currentBehaviour.State == BehaviourState.Active) {
			currentBehaviour.Do ();
		}
	}

	void Update()
	{
		if (currentTaskBehaviour != null && currentTaskBehaviour.State == BehaviourState.Active) {
			currentTaskBehaviour.Update ();
		}
	}

	public void SetExecutingTask(PrimitiveAgentBehaviour beh)
	{
		currentTaskBehaviour = beh;
	}

	List<Task> tasksList = new List<Task>();
	public AgentBehaviour GetSatisfactor(NewCondition c)
	{
		var satTaskCat = c.TaskCategory ();
		var catList = tasksSet.Get (satTaskCat);
		tasksList.Clear ();
		for (int i = 0; i < catList.Count; i++)
			tasksList.Add (catList [i].Get () as Task);
		float maxUt = 0;
		Task maxTask;
		int maxTaskIndex;
		for (int i = 0; i < tasksList.Count; i++) {
			var task = tasksList [i];
			c.InitTask (task);

			bool doableInTheory = true;
			var pTask = task as PrimitiveTask;
			if (pTask != null) {
				var deps = pTask.Dependencies ();
				var cons = pTask.Constraints ();
				for (int j = 0; j < deps.Count; j++)
					if (!tasksSet.ContainsKey (deps [i].TaskCategory ())) {
						doableInTheory = false;
						break;
					}
				if(doableInTheory)
				for (int j = 0; j < cons.Count; j++)
					if (!tasksSet.ContainsKey (cons [i].TaskCategory ())) {
						doableInTheory = false;
						break;
					}
			}
			if (doableInTheory) {
				float taskUt = task.Utility ();
				if (taskUt > maxUt) {
					if(maxTask != null)
						catList [maxTaskIndex].Return (maxTask);
					maxTask = task;
					maxUt = taskUt;
					maxTaskIndex = i;
				}
				else
					catList [i].Return (task);
			} else
				catList [i].Return (task);

		}

		return AgentBehaviour.FromTask (maxTask);
		
	}
}

/*

Behaviours handle their tasks results and subbehaviours results.

Self UpdateAI:

None -> Try starting. Goto Active. 
ImpossibleToStart -> error, should be noted
Failed -> error, should be noted
Finished -> error, should be noted
Active -> Either decompose more or update self. Goto other states if neccessary.
Paused -> Resume
Waiting -> check for the awaited behaviour whether it has finished

Subbehaviour state on updateAI:
None -> Update
ImpossibleToStart -> Fail self
Failed -> Fail self
Finished -> Check whether finished itself or continue with a new task
Active -> Update
Paused -> Update
Waiting -> Update

Self task state on update IF THE BEHAVIOUR IS ACTIVE:
None -> start it
Active -> proceed with an update, update decompose, check contraints
Finished -> goto finished
Failed -> goto failed


No behaviour -> UpdateAI -> has current task -> update cycle -> no task -> UpdateAI
 */
public enum BehaviourState { None, Finished, Failed, ImpossibleToStart, Active, Paused, Waiting }
public abstract class AgentBehaviour
{
	protected Task Task { get; private set; }
	protected Agent Agent { get; private set; }
	public virtual void Init(Agent agent, Task task)
	{
		Task = task;
		Agent = agent;
		state = BehaviourState.None;
		Task.Init ();
	}

	BehaviourState state;
	public BehaviourState State { 
		get { return state; } 
		set { state = value; } 
	}
	public abstract void Do ();
	public float Utility()
	{
		return Task.Utility ();
	}


	public static AgentBehaviour FromTask(Agent agent, Task task)
	{
		AgentBehaviour b = null;
		if (task == null)
			return null;
		if (task is PrimitiveTask) { 
			var pTask = task as PrimitiveTask;
			b = new PrimitiveAgentBehaviour ();

		} else if (task is ComplexTask) {
			var cTask = task as ComplexTask;
			b = new ComplexAgentBehaviour ();
		}
		b.Init (agent, task);
		return b;
	}

}
public class PrimitiveAgentBehaviour : AgentBehaviour
{
	PrimitiveTask selfTask { get { return Task as PrimitiveTask; } }
	AgentBehaviour satisfactionBehaviour;
	List<Constraint> cons;
	List<NewCondition> deps;

	public override void Init (Agent agent, Task task)
	{
		base.Init (agent, task);
		cons = null;
		deps = null;
		satisfactionBehaviour = null;
	}

	public override void Do ()
	{
		switch (State) {
		case BehaviourState.None:
			cons = selfTask.Constraints ();
			deps = selfTask.Dependencies ();
			ProcessPreconditions ();
			break;
		case BehaviourState.Waiting:
			ProcessPreconditions ();
			break;		
		}
	}

	void ProcessPreconditions()
	{
		if (satisfactionBehaviour == null) {
			NewCondition unsatCond = null;
			if (AreAllConditionsSatisfied (out unsatCond)) {
				Activate ();
			} else {
				satisfactionBehaviour = Agent.GetSatisfactor (unsatCond);
				if (satisfactionBehaviour == null) {
					State = BehaviourState.ImpossibleToStart;
					return;
				} else {
					State = BehaviourState.Waiting;
				}
			}	
		} else {
			//State == Waiting
			switch (satisfactionBehaviour.State) {
			case BehaviourState.Failed:
			case BehaviourState.ImpossibleToStart:
				//Set penalty for it
				//either fail or try other
				//in any case - clean the behaiour
				//for now - fail
				State = BehaviourState.ImpossibleToStart;
				satisfactionBehaviour = null;
				break;
			case BehaviourState.Finished:
				satisfactionBehaviour = null;
				break;
			default:
				satisfactionBehaviour.Do ();
				
			}

		}

	}
	public void Update()
	{
		//here the state of the behaviour and task is Active
		switch (Task.State) {
		case TaskState.Active:
			UpdateActiveTask ();
			break;
		case TaskState.Finished:
			selfTask.OnFinish ();
			Agent.SetExecutingTask (null);
			State = BehaviourState.Finished;
			break;
		case TaskState.Failed:
			selfTask.OnTerminate ();
			Agent.SetExecutingTask (null);
			State = BehaviourState.Failed;
			break;
		}
	}
		
	bool AreAllConditionsSatisfied(out NewCondition nextUnsatisfiedCondition)
	{
		cons.Update ();
		deps.Update ();
		var unsatisfiedCond = cons.Unsatisfied ();
		var isResuming = Task.State == TaskState.Paused;
		if (unsatisfiedCond == null)
		if (Task.State != TaskState.Active && (!isResuming || (isResuming && Task.Interruption() == InterruptionType.Restartable)))
			unsatisfiedCond = deps.Unsatisfied ();
		if (unsatisfiedCond == null)
			return true;
		nextUnsatisfiedCondition = unsatisfiedCond;
		return false;
	}

	void StartTask()
	{
		selfTask.State = TaskState.Active;
		Agent.SetExecutingTask (this);
		selfTask.OnStart ();
	}

	void ResumeTask()
	{
		selfTask.State = TaskState.Active;
		Agent.SetExecutingTask (this);
		selfTask.OnResume ();
	}




	void Activate()
	{

		State = BehaviourState.Active;
		if (Task.State == TaskState.None) {
			StartTask ();
		} else if (Task.State == TaskState.Paused) {
			ResumeTask ();
		}
	}

	void UpdateActiveTask()
	{
		NewCondition unsatCond = null;
		if (AreAllConditionsSatisfied (out unsatCond)) {
			if (selfTask.Finished ())
				selfTask.State = TaskState.Finished;
			else
				selfTask.OnUpdate ();
		}
		else {
			switch (Task.Interruption ()) {
			case InterruptionType.Terminal:
				Agent.SetExecutingTask (null);
				State = BehaviourState.Failed;
				break;
			case InterruptionType.Resumable:
				State = BehaviourState.None;
				Task.State = TaskState.Paused;
				selfTask.OnInterrupt ();
				break;
			case InterruptionType.Restartable:
				State = BehaviourState.Waiting;
				Task.State = TaskState.Paused;
				selfTask.OnInterrupt ();
				break;
			}
		}
	}

}

public class ComplexAgentBehaviour : AgentBehaviour
{
	ComplexTask cTask = null;
	List<NewCondition> tasks = new List<NewCondition>();
	IEnumerator<NewCondition> tasksEnumeration;
	NewCondition currentTask;
	public override void Init (Agent agent, Task task)
	{
		base.Init (agent, task);
		cTask = task as ComplexTask;
		tasks = cTask.Decomposition ();
		tasksEnumeration = TasksEnumerator ();
	
	}
	public override void Do ()
	{
		switch (Task.State) {
		case BehaviourState.None:
			tasksEnumeration.Reset ();
			Task.State = TaskState.Active;
			break;
		case BehaviourState.Active:
			if (currentTask == null) {
				if (tasksEnumeration.MoveNext ()) {
					currentTask = tasksEnumeration.Current;
					currentTask.Behaviour = Agent.GetSatisfactor (currentTask);
					if (currentTask.Behaviour == null)
						State = BehaviourState.ImpossibleToStart;
					else
						State = BehaviourState.Waiting;
				} else {
					if (!IsFinishedOrTerminated ())
						Task.State = TaskState.None;
				}
			} else
				State = BehaviourState.Waiting;
			break;
		case BehaviourState.Waiting:
			switch (currentTask.Behaviour.State) {
			case BehaviourState.Failed:
				currentTask = null;
				State = BehaviourState.Failed;
				break;
			case BehaviourState.Finished:
				currentTask = null;
				State = BehaviourState.Active;
				break;
			case BehaviourState.ImpossibleToStart:
				currentTask = null;
				State = BehaviourState.Failed;
				break;
			default:
				currentTask.Behaviour.Do ();
				break;
			}
			break;
		case BehaviourState.Paused:
			switch (Task.Interruption ()) {
			case InterruptionType.Restartable:
				Task.State = TaskState.None;
				break;
			case InterruptionType.Resumable:
				Task.State = TaskState.Active;
				break;
			}
			break;
		}
	}


	bool IsFinishedOrTerminated()
	{
		if (cTask.Finished ()) {
			State = BehaviourState.Finished;
			return true;
		}
		if (cTask.Terminated ()) {
			State = BehaviourState.Failed;
			return true;
		}

		return false;
	}
	IEnumerator<NewCondition> TasksEnumerator()
	{
		for (int i = 0; i < tasks.Count; i++)
			if (!tasks [i].Update ())
				yield return tasks [i];
	}
}


