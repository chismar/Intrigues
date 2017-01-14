using UnityEngine;
using System.Collections.Generic;

public class NewAgent : MonoBehaviour
{
	List<Behaviour> behaviours = new List<Behaviour>();
	Behaviour curBehaviour = null;


	void UpdateAI()
	{
		float maxUt = curBehaviour == null ? 0f : curBehaviour.Utility ();
		Behaviour maxBeh = null;
		for (int i = 0; i < behaviours.Count; i++) {
			var ut = behaviours [i].Utility ();
			if (ut > maxUt) {
				maxUt = ut;
				maxBeh = behaviours [i];
			}
		}
		if (curBehaviour != maxBeh) {
			curBehaviour = maxBeh;
			curBehaviour.Perform ();
		}

	}

	void Update()
	{
		if (curBehaviour != null) {
			curBehaviour.Update ();
			if (curBehaviour.Done ()) {
				curBehaviour = null;	
			}
		
		}
	}

	public bool CanDo(System.Type type)
	{
		return false;
	}
	public bool CanDoCategory(System.Type type)
	{
		return false;
	}
	public bool IsExternal(NewCondition c)
	{
		var taskCat = c.TaskCategory ();
		return CanDoCategory(taskCat);
	}

	public void FindSatisfaction(NewCondition c)
	{
		
	}
}

public abstract class Behaviour
{
	protected abstract Task Task { get; set; }
	protected NewAgent Agent { get; private set; }
	public TaskState State { get { return Task.State; } } 
	public float Utility()
	{
		return Task.Utility ();
	}
	public void Perform()
	{
		
		Do ();
	}
	protected abstract void Do ();
	public abstract void Update ();
	public bool Done()
	{
		return Task.State == TaskState.Failed || Task.State == TaskState.Finished || Task.State == TaskState.Impossible;
	}

	public static Behaviour FromTask(NewAgent agent, Task task)
	{
		Behaviour beh = null;
		if (task is PrimitiveTask) {
			beh = new PrimitiveBehaviour ();
		} else if (task is RecurrentTask) {
			beh = new RecurrentBehaviour ();
		} else if (task is ComplexTask) {
			beh = ComplexBehaviour ();
		} 
		beh.Agent = agent;
		beh.Task = task;
	}

}

public class PrimitiveBehaviour : Behaviour
{
	PrimitiveTask task;
	//here should go cur dependency task or list of tasks, or whatever
	protected override Task Task {
		get { return task; }
		set { task = value as PrimitiveTask; }
	}
	List<NewCondition> deps;
	List<Constraint> cons;
	NewCondition curConditionToSatisfy;
	protected override void Do ()
	{
		Task.State = TaskState.None;
		Task.Init ();
		UpdateConditions ();
	}

	void UpdateConditions()
	{
		deps = task.Dependencies ();
		cons = task.Constraints ();
	}

	bool CanDo()
	{
		var canSatisfy = deps.CanBeSatisfiedBy (Agent) && deps.CanBeSatisfiedBy (Agent);
		if (!canSatisfy)
			Task.State = TaskState.Impossible;
		return canSatisfy;
	}

	public override void Update ()
	{
		
		switch (task.State) {
		case TaskState.None: 
			if (deps.Met () && cons.Met ())
				StartTask ();
			else
				SatisfyConditions ();
			break;
		case TaskState.Active: 
			if (cons.Met ())
				task.Update ();
			else
				InterruptToSatisfyOrTerminate ();
			break;
		case TaskState.Waits:
			SatisfyConstraints ();
			break;
		case TaskState.Paused: 
			InternalResume ();
			break;
		}
	}

	void SatisfyConstraints()
	{
		if (cons.Met ()) {
			InternalResume ();
			return;
		}
		if (TerminateIfNotInterrupt ())
			return;
		
		if (!cons.CanBeSatisfiedBy (Agent)) {
			Terminate ();
			return;
		}
		if (curConditionToSatisfy == null || curConditionToSatisfy.Met) {
			curConditionToSatisfy = cons.Unsatisfied ();
			if (!SatisfyCurCondition ()) {
				return;
			}
		}
		curConditionToSatisfy.Behaviour.Update ();

	}

	bool TerminateIfNotInterrupt()
	{
		for (int i = 0; i < cons.Count; i++) {
			if (!cons [i].Met) {
				if (!cons [i].Interruptive) {
					Terminate ();
					return true;
				}	
			}
		}
		return false;
	}
	void InterruptToSatisfyOrTerminate()
	{
		if (!cons.CanBeSatisfiedBy (Agent)) {
			Terminate ();
			return;
		}
			
		if (TerminateIfNotInterrupt ())
			return;
		Interrupt ();
	}

	void Terminate()
	{
		task.OnTerminate ();
		cons = null;
	}

	void Interrupt()
	{
		task.OnInterrupt ();
		if (task.State == TaskState.Paused)
			task.State = TaskState.Waits;
	}

	void InternalResume()
	{
		task.OnResume ();
		if (task.State == TaskState.None)
			Do ();
		else
			UpdateConditions ();
	
	}
	void SatisfyConditions()
	{
		if (curConditionToSatisfy == null || curConditionToSatisfy.Met)
			curConditionToSatisfy = null;
		if (!CanDo ())
			return;
		if (curConditionToSatisfy == null) {
			curConditionToSatisfy = deps.Unsatisfied ();
			if (curConditionToSatisfy == null)
				curConditionToSatisfy = cons.Unsatisfied ();
			if (!SatisfyCurCondition ())
				return;

		}
		curConditionToSatisfy.Behaviour.Update ();

		
	}

	bool SatisfyCurCondition()
	{
		Agent.FindSatisfaction (curConditionToSatisfy);
		if (curConditionToSatisfy.Behaviour == null) {
			//Вот тут он должен или найти другое, в надежде, что когда он его удовлетворит, уже можно будет удовлетворить и это
			//либо просто зафейлится, что он будет делать пока что
			State = TaskState.Failed;
			return false;
		}
		curConditionToSatisfy.Behaviour.Perform ();
		return true;
	}
	void StartTask()
	{
		deps = null;
		curConditionToSatisfy = null;
		if(cons != null)
		for (int i = 0; i < cons.Count; i++)
			cons [i].Behaviour = null;
		task.OnStart ();
	}
}

public static class ConditionsExt
{
	public static bool Met<T>(this List<T> conditions) where T : NewCondition
	{
		if (conditions == null)
			return true;
		
		bool met = true;
		for (int i = 0; i < conditions.Count; i++)
			if (!conditions [i].Update ()) {
				met = false;
				break;
			}
		return met;
	
	}
	public static bool CanBeSatisfiedBy<T>(this List<T> conditions, NewAgent agent) where T : NewCondition
	{
		if (conditions == null)
			return true;
		bool canBeSatisfied = true;
		for (int i = 0; i < conditions.Count; i++) {
			if(!conditions[i].Met)
				canBeSatisfied = !agent.IsExternal(conditions[i]);
		}
		return canBeSatisfied;
		
	}
	public static NewCondition Unsatisfied<T>(this List<T> conditions) where T : NewCondition
	{
		if (conditions == null)
			return null;
		for (int i = 0; i < conditions.Count; i++)
			if (!conditions [i].Met)
				return conditions [i];
		return null;
	}
}
public class ComplexBehaviour : Behaviour
{

	ComplexTask task;
	protected override Task Task {
		get { return task; }
		set { task = value as ComplexTask; }
	}
	protected override void Do ()
	{
		task.Perform ();
	}
}

public class RecurrentBehaviour : Behaviour
{
	RecurrentTask task;
	protected override Task Task {
		get { return task; }
		set { task = value as RecurrentTask; }
	}
	protected override void Do ()
	{
		//start a coroutine?
	}
}


public class NewCondition
{

	public abstract System.Type TaskCategory();
	public bool Update()
	{
		met = Satisfied ();
		return met;
	}
	protected abstract bool Satisfied ();
	public bool Met { get { return met; } }
	protected bool met;
	public abstract void InitTask(EventAction action);
	public Behaviour Behaviour { get; set; }
}

public class Constraint : NewCondition
{
	public bool Interruptive { get; set; }
}