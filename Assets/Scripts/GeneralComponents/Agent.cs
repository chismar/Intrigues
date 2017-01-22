using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;


public class Agent : MonoBehaviour
{
	public List<AgentBehaviour> behaviours = new List<AgentBehaviour>();

	Dictionary<Type, List<ObjectPool>> tasksSet;
	Dictionary<Type, ObjectPool> tasksByType;
	PrimitiveAgentBehaviour currentTaskBehaviour;

	AgentBehaviour currentBehaviour;

	public bool IsExternal(TaskCondition c)
	{
		return tasksSet.ContainsKey (c.TaskCategory ());
	}
	void UpdateAI()
	{
		float maxUt = 0;
		AgentBehaviour maxBeh = null;
		for (int i = 0; i < behaviours.Count; i++) {
			var beh = behaviours [i];
			var ut = beh.Utility ();
			if (ut > maxUt) {
				maxBeh = beh;
				maxUt = ut;
			}
		}
		if (maxBeh != null)
		if (maxBeh != currentBehaviour) {
			if (currentBehaviour != null) {
				//currentBehaviour.Interrupt();
			}
			currentBehaviour = maxBeh;
		}
		if (currentBehaviour != null && currentTaskBehaviour == null) {
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
	public AgentBehaviour GetSatisfactor(TaskCondition c)
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
		smartScope = Task.AtScope;
	}
	SmartScope smartScope;

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

	public abstract void PlanAhead();

}
public class PrimitiveAgentBehaviour : AgentBehaviour
{
	PrimitiveTask selfTask { get { return Task as PrimitiveTask; } }
	AgentBehaviour satisfactionBehaviour;
	List<Constraint> cons;
	List<TaskCondition> deps;

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
			ProcessPreTaskConditions ();
			break;
		case BehaviourState.Waiting:
			ProcessPreTaskConditions ();
			break;		
		}
	}

	void ProcessPreTaskConditions()
	{
		if (satisfactionBehaviour == null) {
			TaskCondition unsatCond = null;
			if (AreAllTaskConditionsSatisfied (out unsatCond)) {
				Activate ();
			} else {
				satisfactionBehaviour = unsatCond.Behaviour;
				if (satisfactionBehaviour == null) {
					PlanAhead ();
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
		
	bool AreAllTaskConditionsSatisfied(out TaskCondition nextUnsatisfiedTaskCondition)
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
		nextUnsatisfiedTaskCondition = unsatisfiedCond;
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
		TaskCondition unsatCond = null;
		if (AreAllTaskConditionsSatisfied (out unsatCond)) {
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


	public override void PlanAhead ()
	{
		cons.Update ();
		deps.Update ();

		for (int i = 0; i < cons.Count; i++) {
			var con = cons [i];
			if (!con.Met) {
				con.Behaviour = Agent.GetSatisfactor (con);
				if (con.Behaviour == null) {
					//here should also go backtracking in terms of chosing alternative
					State = BehaviourState.ImpossibleToStart;
					return;
				} else {
					con.Behaviour.PlanAhead ();
					if (con.Behaviour.State == BehaviourState.ImpossibleToStart) {
						//here should also go backtracking in terms of chosing alternative
						State = BehaviourState.ImpossibleToStart;
						return;
					}
				}
			} else if (con.Behaviour != null) {
				//con.Behaviour.Terminate();
				con.Behaviour = null;
			}
		}
		var isResuming = Task.State == TaskState.Paused;
		if (Task.State != TaskState.Active && (!isResuming || (isResuming && Task.Interruption () == InterruptionType.Restartable))) {
			for (int i = 0; i < deps.Count; i++) {
				var dep = deps [i];
				if (!dep.Met) {
					dep.Behaviour = Agent.GetSatisfactor (dep);
					if (dep.Behaviour == null) {
						//here should also go backtracking in terms of chosing alternative
						State = BehaviourState.ImpossibleToStart;
						return;
					} else {
						dep.Behaviour.PlanAhead ();
						if (dep.Behaviour.State == BehaviourState.ImpossibleToStart) {
							//here should also go backtracking in terms of chosing alternative
							State = BehaviourState.ImpossibleToStart;
							return;
						}
					}
				} else if (dep.Behaviour != null) {
					//dep.Behaviour.Terminate();
					dep.Behaviour = null;
				}
			}
		}


	}
}

public class ComplexAgentBehaviour : AgentBehaviour
{
	ComplexTask cTask = null;
	List<TaskWrapper> tasks = new List<TaskWrapper>();
	IEnumerator<TaskWrapper> tasksEnumeration;
	TaskWrapper currentTaskWrapper;
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
			if (currentTaskWrapper == null) {
				if (tasksEnumeration.MoveNext ()) {
					currentTaskWrapper = tasksEnumeration.Current;
					//currentTaskWrapper.Behaviour = Agent.GetSatisfactor (currentTaskWrapper);
					if (currentTaskWrapper.Behaviour == null) {
						PlanAhead ();
					}
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
			switch (currentTaskWrapper.Behaviour.State) {
			case BehaviourState.Failed:
				currentTaskWrapper = null;
				State = BehaviourState.Failed;
				break;
			case BehaviourState.Finished:
				currentTaskWrapper = null;
				State = BehaviourState.Active;
				break;
			case BehaviourState.ImpossibleToStart:
				currentTaskWrapper = null;
				State = BehaviourState.Failed;
				break;
			default:
				currentTaskWrapper.Behaviour.Do ();
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
	IEnumerator<TaskCondition> TasksEnumerator()
	{
		for (int i = 0; i < tasks.Count; i++)
			if (!tasks [i].Update ())
				yield return tasks [i];
	}

	public override void PlanAhead ()
	{
		if (Task.Finished ())
			return;
		tasks = cTask.Decomposition ();
		tasks.Update ();
		for (int i = 0; i < tasks.Count; i++) {

			var task = tasks [i];
			if (task.Met) {
				task.Behaviour = Agent.GetSatisfactor (task);
				if (task.Behaviour = null) {
					//here - replan if possible
					State = BehaviourState.ImpossibleToStart;
					return;
				} else {
					task.Behaviour.PlanAhead ();
					if (task.Behaviour.State = BehaviourState.ImpossibleToStart) {
						//here - replan if possible
						State = BehaviourState.ImpossibleToStart;
						return;
					}
				}
			} else if (task.Behaviour != null) {
				//task.Behaviour.Terminate();
				task.Behaviour = null;
			}
		}
	}
}


public abstract class TaskCondition
{

	public bool Update()
	{
		met = Satisfied ();
		return met;
	}

	protected bool met;
	public bool Met { get { return met; } }
	protected abstract bool Satisfied ();
	public abstract Type TaskCategory();
	public abstract void InitTask(Task task);
	public AgentBehaviour Behaviour { get;set;}
	
}

public abstract class Constraint : TaskCondition
{
	public bool Interruptive { get; internal set; }
}
	
public abstract class TaskWrapper : TaskCondition
{
	
	public HashSet<Type> AlreadyChosenBehaviours = new HashSet<Type>();
	public virtual int MaxAttempts()
	{
		return 1;
	}

	public int CurrentAttempts()
	{
		return AlreadyChosenBehaviours.Count;
	}
}
