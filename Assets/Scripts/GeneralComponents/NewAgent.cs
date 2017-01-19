using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
public class NewAgent : MonoBehaviour
{
	List<Behaviour> behaviours = new List<Behaviour>();
	Behaviour curBehaviour = null;

	Dictionary<Type, HashSet<Type>> tasksSet = new Dictionary<Type, HashSet<Type>>(); 

	void UpdateAI()
	{
		float maxUt = curBehaviour == null ? 0f : curBehaviour.Utility () + 0.1;
		Behaviour maxBeh = null;
		for (int i = 0; i < behaviours.Count; i++) {
			var ut = behaviours [i].Utility ();
			if (ut > maxUt) {
				maxUt = ut;
				maxBeh = behaviours [i];
			}
		}
		if (curBehaviour != maxBeh) {
			if (curBehaviour != null)
				curBehaviour.Pause ();
			curBehaviour = maxBeh;
			if (curBehaviour.Paused)
				curBehaviour.Resume ();
			else
				curBehaviour.Perform ();
		}

	}

	void Update()
	{
		if (curBehaviour != null) {
			if (curTaskBehaviour == null) {
				
				curBehaviour.Update ();
				if (curBehaviour.Done ()) {
					curBehaviour = null;	
				}
			} else if (curTaskBehaviour.Done ())
				curTaskBehaviour = null;
			else
				curTaskBehaviour.Update ();
		}
	}
	PrimitiveBehaviour curTaskBehaviour;
	public void RegisterPrimitiveBehaviourToUpdate(PrimitiveBehaviour b)
	{
		curTaskBehaviour = b;
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
	protected static float ImpossiblePenaltyValue = 0.2f;
	protected static float ImpossiblePenaltyDuration = 30f;
	protected static float FailPenaltyValue = 0.1f;
	protected static float FailPenaltyDuration = 15f;
	public bool Paused { get; internal set; }
	public Penalties Penalties { get; set; }
	protected abstract Task Task { get; set; }
	protected NewAgent Agent { get; private set; }
	public TaskState State { get { return Task.State; } } 
	public float Utility()
	{
		return Task.Utility ();
	}
	public void Perform()
	{
		Task.Penalties = Penalties;
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
			beh = new ComplexBehaviour ();
		} 
		beh.Agent = agent;
		beh.Task = task;
		return beh;
	}
	public void Pause ()
	{
		Paused = true;
		OnPause ();
	}

	public void Resume()
	{
		Paused = false;
		OnResume ();
	}

	protected abstract void OnPause();
	protected abstract void OnResume();
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
			Task.State = TaskState.Failed;
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

	protected override void OnPause ()
	{
		Interrupt ();
	}

	protected override void OnResume ()
	{
		InternalResume ();
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

	public static void Update<T>(this List<T> conditions) where T : NewCondition
	{
		if (conditions == null)
			return;
		for (int i = 0; i < conditions.Count; i++)
			conditions [i].Update ();
	}
}

public abstract class NewCondition
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
	public abstract void InitTask(Task task);
	public AgentBehaviour Behaviour { get; set; }
}

public abstract class Constraint : NewCondition
{
	public bool Interruptive { get; set; }
}



public class Penalties
{

	Dictionary<System.Type, Penalties> penaltiesByType = new Dictionary<System.Type, Penalties>();
	class Penalty
	{
		public float StartTime { get; set;}
		public float Duration { get;set;}
		public float Value {get;set;}
		public bool Expired { get { return StartTime + Duration < Time.realtimeSinceStartup; } }
	}
	Dictionary<object, Penalty> penalties = new Dictionary<object, Penalty>();
	static List<object> timedOutObjects = new List<object>();
	public bool ClearSelf { get { return penalties.Count == 0 && penaltiesByType.Count == 0; } }
	static ObjectPool<List<System.Type>> clearLists = new ObjectPool<List<System.Type>>();
	public void ClearFromHere()
	{
		Update ();
		Clear ();
	}
	void Clear()
	{

		var clearList = clearLists.Get ();
		clearList.Clear ();

		foreach (var penalties in penaltiesByType) {
			penalties.Value.Clear ();
			if (penalties.Value.ClearSelf)
				clearList.Add (penalties.Key);	
		}
		for (int i = 0; i < clearList.Count; i++)
			penaltiesByType.Remove (clearList [i]);
		clearList.Clear ();
		clearLists.Return (clearList);

	}
	public void Update()
	{
		foreach (var penalties in penaltiesByType)
			penalties.Value.Update ();
		timedOutObjects.Clear ();
		foreach (var penalty in penalties) {
			if (penalty.Value.Expired)
				timedOutObjects.Add (penalty.Key);
		}
		for (int i = 0; i < timedOutObjects.Count; i++) {
			penalties.Remove (timedOutObjects [i]);
		}
		timedOutObjects.Clear ();


	}

	public void SetPenalty(object obj, float duration, float value)
	{
		Penalty p = null;
		if (!penalties.TryGetValue (obj, out p)) {
			p = new Penalty ();
			penalties.Add (obj, p);
		}
		p.StartTime = Time.realtimeSinceStartup;
		p.Duration = duration;
		p.Value = value;
	}

	public void AddPenalty(object obj, float duration, float value)
	{
		Penalty p = null;
		if (!penalties.TryGetValue (obj, out p)) {
			p = new Penalty ();
			penalties.Add (obj, p);
		}
		p.StartTime = Time.realtimeSinceStartup;
		p.Duration = duration;
		p.Value += value;
	}

	public float GetPenalty(object obj)
	{
		var p = penalties.TryGet (obj);
		if (p == null)
			return 0f;
		else if (p.Expired) {
			penalties.Remove (obj);
			return 0f;
		}
		return p.Value;
	}

	public void Init(Behaviour b)
	{
		var type = b.GetType ();
		var p = penaltiesByType.TryGet (type);
		if (p == null) {

			p = new Penalties ();
			penaltiesByType.Add (type, p);
		}
		b.Penalties = p;
	}
}