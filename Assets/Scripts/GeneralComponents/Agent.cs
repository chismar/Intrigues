using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;


public class Agent : MonoBehaviour
{
	public List<AgentBehaviour> behaviours = new List<AgentBehaviour>();

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
	public AgentBehaviour(Agent agent, Task task)
	{
		Task = task;
		Agent = agent;
		state = BehaviourState.None;
	}

	public virtual void Clean()
	{
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

	protected static ObjectPool<StringBuilder> builders = new ObjectPool<StringBuilder>();

}

public class PrimitiveAgentBehaviour : AgentBehaviour
{
	PrimitiveTask selfTask { get { return Task as PrimitiveTask; } }
	AgentBehaviour satisfactionBehaviour;
	List<Constraint> cons;
	List<NewCondition> deps;

	public override void Clean ()
	{
		base.Clean ();
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
		NewCondition unsatCond = null;
		if (AreAllConditionsSatisfied (out unsatCond)) {
			Activate ();
		} else {
			satisfactionBehaviour = GetSatisfactor (unsatCond);
			if (satisfactionBehaviour == null) {
				State = BehaviourState.ImpossibleToStart;
				return;
			} else {
				WaitSatisfaction ();
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
			Agent.SetExecutingTask (null);
			State = BehaviourState.Finished;
			break;
		case TaskState.Failed:
			Agent.SetExecutingTask (null);
			State = BehaviourState.Failed;
			break;
		}
	}
		
	bool AreAllConditionsSatisfied(out NewCondition nextUnsatisfiedCondition)
	{
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

	AgentBehaviour GetSatisfactor(NewCondition c)
	{
	}

	void WaitSatisfaction()
	{
		State = BehaviourState.Waiting;
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
		if (AreAllConditionsSatisfied (out unsatCond))
			selfTask.OnUpdate ();
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
}


