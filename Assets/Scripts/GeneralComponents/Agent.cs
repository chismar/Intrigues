using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;


public class Agent : MonoBehaviour
{
	public List<AgentBehaviour> Behaviours = new List<AgentBehaviour>();
    Metrics metrics;
	public Dictionary<Type, List<ObjectPool>> tasksSet;
	public Dictionary<Type, ObjectPool> tasksByType;
	public PrimitiveAgentBehaviour currentTaskBehaviour;

	public AgentBehaviour currentBehaviour;
	public bool IsExternal(TaskCondition c)
	{
		return tasksSet.ContainsKey (c.TaskCategory);
	}
    bool passive = false;
    private void Awake()
    {
        metrics = gameObject.GetComponent<Metrics>();
    }
    private void Start()
    {
        passive = GetComponent<PlayerMarker>() != null;
    }
    static System.Random rand = new System.Random();
    void UpdateAI()
	{
        //Debug.Log ("UpdateAI");
		float maxUt = 0;
		AgentBehaviour maxBeh = null;
		for (int i = 0; i < Behaviours.Count; i++) {
			var beh = Behaviours [i];
			if (beh.State != BehaviourState.Paused && beh != currentBehaviour && beh.State != BehaviourState.Waiting)
            {

                beh.Init(this, beh.Task);

                beh.Task.Init();
                if (beh.Task.State == TaskState.Failed)
                    continue;
            }
			var ut = beh.Utility (beh == currentBehaviour) * (1f + 0.1f * (0.5f - (float)rand.NextDouble()) / 0.5f);
			if (ut > maxUt) {
				maxBeh = beh;
				maxUt = ut;
			}
		}
		if (maxBeh != null)
		if (maxBeh != currentBehaviour) {
			if (currentBehaviour != null) {
				currentBehaviour.Interrupt();
			}
			currentBehaviour = maxBeh;
          //Debug.LogWarning("{0} has chosen to do {1}".Fmt(gameObject, currentBehaviour), gameObject);
            if(currentBehaviour.State == BehaviourState.None)
                {

                    currentBehaviour.PlanAhead();
                    //Debug.Log(currentBehaviour.State);
                }
        }
		if (currentBehaviour != null && currentTaskBehaviour == null) {
			if (currentBehaviour.State == BehaviourState.ImpossibleToStart)
            {

              //Debug.LogWarning("{0} can't do {1}".Fmt(gameObject, currentBehaviour), gameObject);
                currentBehaviour = null;
            }
			else
            {

                currentBehaviour.Do();
              //Debug.LogWarning("{0} updates {1}".Fmt(gameObject, currentBehaviour), gameObject);
            }

		}
        else
        {

          //Debug.LogWarning("{0} can't update {1}".Fmt(gameObject, currentBehaviour), gameObject);
        }

	}
    public string Task {  get { return currentTaskBehaviour.Task is BehaviourTask ? (currentTaskBehaviour.Task as BehaviourTask).TaskName : null; } }
    public void Do(BehaviourTask interactionTask)
    {

        if (currentBehaviour != null)
        {
            currentBehaviour.Interrupt();
        }
        currentBehaviour = AgentBehaviour.FromTask(this, interactionTask);
        currentTaskBehaviour = currentBehaviour as PrimitiveAgentBehaviour;
        currentTaskBehaviour.selfTask.OnStart();
        currentBehaviour.State = BehaviourState.Active;
        interactionTask.State = TaskState.Active;
    }
    void Update()
    {
        if (currentTaskBehaviour != null && currentTaskBehaviour.State == BehaviourState.Active) {
          //Debug.Log("agent updates " + currentTaskBehaviour);
            currentTaskBehaviour.Update();
        } else {
            //if (currentTaskBehaviour != null)
                //Debug.Log(currentTaskBehaviour);
            if (currentBehaviour != null)
                if (currentBehaviour.State == BehaviourState.ImpossibleToStart || currentBehaviour.State == BehaviourState.Failed || currentBehaviour.State == BehaviourState.Finished)
                {

                 //Debug.LogWarning("{0} state of {1} is {2}, clearing current behaviour".Fmt(gameObject, currentBehaviour, currentBehaviour.State), gameObject);
                    
                    currentBehaviour = null;
                }
            if (!passive)
                UpdateAI ();
		}
	}
    public float CurrentUtility()
    {
        return currentBehaviour == null ? 0f : currentBehaviour.Utility(false);
    }
	public void SetExecutingTask(PrimitiveAgentBehaviour beh)
	{
		currentTaskBehaviour = beh;
	}

	List<Task> tasksList = new List<Task>();
	public AgentBehaviour GetSatisfactor(TaskCondition c)
	{
        
		var satTaskCat = c.TaskCategory;
		var catList = tasksSet.Get (satTaskCat);
		tasksList.Clear ();
		for (int i = 0; i < catList.Count; i++)
			tasksList.Add (catList [i].Get () as Task);
		float maxUt = 0;
		Task maxTask = null;
		int maxTaskIndex = -1;
		for (int i = 0; i < tasksList.Count; i++) {
			var task = tasksList [i];
            c.InitTask (task);
            task.Root = gameObject;
            task.Init();
            if (task.State == TaskState.Failed)
                continue;
            bool doableInTheory = true;
			var pTask = task as PrimitiveTask;
			if (pTask != null) {
				var deps = pTask.Dependencies;
				var cons = pTask.Constraints;
                if(deps != null)
				for (int j = 0; j < deps.Count; j++)
					if (!tasksSet.ContainsKey (deps [i].TaskCategory)) {
						doableInTheory = false;
						break;
					}
				if(doableInTheory && cons != null)
				for (int j = 0; j < cons.Count; j++)
					if (!tasksSet.ContainsKey (cons [i].TaskCategory)) {
						doableInTheory = false;
						break;
					}
			}
			if (doableInTheory) {
				float taskUt = task.Utility ();
				if (taskUt > maxUt) {
                    bool should = true;
                    if(task is InteractionTask)
                    {
                        var other = (task as InteractionTask).Other.GetComponent<Agent>();
                        if(other != null)
                        {
                            var otherUt = other.CurrentUtility();
                            if (otherUt > taskUt)
                                should = false;
                        }
                    }
                    if (should)
                    {

                        if (maxTask != null)
                            catList[maxTaskIndex].Return(maxTask);
                        maxTask = task;
                        maxUt = taskUt;
                        maxTaskIndex = i;
                    }
				}
				else
					catList [i].Return (task);
			} else
				catList [i].Return (task);

		}

		return AgentBehaviour.FromTask (this, maxTask);
		
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
	public Task Task { get; private set; }
	protected Agent Agent { get; private set; }
	SmartScope atScope;
	Metrics metrics;

    public override string ToString()
    {
        return Task.GetType().Name;
    }
    public virtual void Init(Agent agent, Task task)
	{
		Task = task;
		Task.Root = agent.gameObject;
		Agent = agent;
		state = BehaviourState.None;
        Task.State = TaskState.None;
      //Debug.Log("init " + this + " in " + agent.gameObject.name);
        atScope = task.AtScope;
		if (atScope != null) {

            atScope.AlreadyChosenGameObjects.Clear();
            atScope.CurrentGO = null;
            metrics = agent.GetComponent<Metrics> ();
			atScope.CachedMetrics = metrics.Dictionary.ContainsKey (atScope.FromMetricName ) ? metrics.Dictionary [atScope.FromMetricName ] : null;
            
        }
	}

	public abstract void Interrupt ();



	BehaviourState state;
	public BehaviourState State { 
		get { return state; } 
		set { state = value; } 
	}
	public abstract void Do ();
	public float Utility(bool isCurrent)
	{
        if (State == BehaviourState.ImpossibleToStart)
            return -1f;
		return Task.Utility () + (State == BehaviourState.Paused? 0.3f : 0f) + (isCurrent? 0.2f : 0f);
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
	public void BacktrackOrFail(TaskWrapper wrapper)
	{
		if (atScope != null) {
			wrapper.Behaviour = null;
			while (wrapper.Behaviour == null && SelectNext ()) {
				wrapper.Behaviour = Agent.GetSatisfactor (wrapper);
				if (wrapper.Behaviour != null) {
					wrapper.Behaviour.PlanAhead ();
					if (wrapper.Behaviour.State == BehaviourState.ImpossibleToStart)
						wrapper.Behaviour = null;
				}
			}
			if (wrapper.Behaviour == null)
				State = BehaviourState.ImpossibleToStart;

		} else {
			if (wrapper.Behaviour == null)
				State = BehaviourState.ImpossibleToStart;
			else {
				wrapper.AlreadyChosenBehaviours.Add (wrapper.Behaviour.GetType ());
				while (wrapper.CurrentAttempts < wrapper.MaxAttempts) {

					wrapper.CurrentAttempts++;
					wrapper.Behaviour = Agent.GetSatisfactor (wrapper);
					if (wrapper.Behaviour == null) {

						State = BehaviourState.ImpossibleToStart;
						return;
					} else {
						wrapper.AlreadyChosenBehaviours.Add (wrapper.Behaviour.GetType ());

						wrapper.Behaviour.PlanAhead ();
						if (wrapper.Behaviour.State == BehaviourState.ImpossibleToStart) {
							wrapper.Behaviour = null;
						}
					}
				}
			}
		}

	}
    
	protected bool SelectNext()
	{
        return atScope.SelectNext(Task, Agent);
	}
    
}
public class PrimitiveAgentBehaviour : AgentBehaviour
{
	public PrimitiveTask selfTask { get { return Task as PrimitiveTask; } }
	AgentBehaviour satisfactionBehaviour;
	List<TaskWrapper> cons;
	List<TaskWrapper> deps;

	TaskWrapper engageIn;
    public float timeLeft = 0f;
	public override void Init (Agent agent, Task task)
	{
		base.Init (agent, task);
		cons = null;
		deps = null;
		satisfactionBehaviour = null;
        engageIn = selfTask.EngageIn;
        
	}
	public override void Interrupt ()
	{
		switch (State) {
		case BehaviourState.Active:
			OnInterrupt ();
			break;
		case BehaviourState.Waiting:
			satisfactionBehaviour.Interrupt ();
			break;
		}
	}


	public override void Do ()
	{
        switch (State) {
		case BehaviourState.None:
			ProcessPreTaskConditions ();
			break;
		case BehaviourState.Waiting:
                ProcessPreTaskConditions();
			break;		
		}
	}

	void ProcessPreTaskConditions()
	{
		if (satisfactionBehaviour == null) {
          //Debug.Log("satisfaction behaviour is null in " + Agent.gameObject.name);
			TaskCondition unsatCond = null;
			if (AreAllTaskConditionsSatisfied (out unsatCond)) {
				Activate ();
			} else {
                if(unsatCond == null)
                {
                    State = BehaviourState.Failed;
                    return;
                }
                else
                {
                    satisfactionBehaviour = unsatCond.Behaviour;
                  //Debug.Log(Agent.gameObject.name + " sat = " + satisfactionBehaviour);
                    if (satisfactionBehaviour == null)
                    {
                        Replan();
                        return;
                    }
                    else
                    {
                        State = BehaviourState.Waiting;

                    }
                }
				
			}	
		} else
        {
          //Debug.Log("NOT satisfaction behaviour is null in " + Agent.gameObject.name);
          //Debug.Log(satisfactionBehaviour.State + " in " + Agent.gameObject.name);
            //State == Waiting
            switch (satisfactionBehaviour.State) {
			case BehaviourState.Failed:
			case BehaviourState.ImpossibleToStart:
                    Replan();
				if(State == BehaviourState.ImpossibleToStart)
					satisfactionBehaviour = null;
				break;
			case BehaviourState.Finished:
                    if(engageIn != null)
                if (satisfactionBehaviour == engageIn.Behaviour)
                    State = BehaviourState.Finished;
                    
				satisfactionBehaviour = null;
				break;
			default:

                  //Debug.Log("updates satisfaction beh: " + satisfactionBehaviour);
				satisfactionBehaviour.Do ();
				break;
			}

		}

	}
	public void Update()
	{
        if(cons != null)
        {
            foreach(var con in cons)
            {
                var debugOther = con.GetType().GetProperty("Other").GetValue(con, null) as GameObject;
              //Debug.DrawLine(con.Root.transform.position, debugOther.transform.position, con.Met ? Color.green : Color.red);
            }
          //Debug.DrawLine(Agent.transform.position, (Task as InteractionTask).Other.transform.position + Vector3.up * 2, Color.yellow);
        }
		//here the state of the behaviour is Active
		switch (Task.State) {
		case TaskState.Active:
			UpdateActiveTask ();
			break;
		case TaskState.Finished:
			selfTask.OnFinish ();
			Agent.SetExecutingTask (null);
                if(engageIn == null)
                {

                    State = BehaviourState.Finished;
                  //Debug.Log(Agent.gameObject.name + " Finished " + this);
                }
                else
                {
                    State = BehaviourState.Waiting;
                    satisfactionBehaviour = engageIn.Behaviour;
                    
                }
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
		nextUnsatisfiedTaskCondition = null;
		cons.Update ();
		deps.Update ();
		var unsatisfiedCond = cons.Unsatisfied ();
		var isResuming = Task.State == TaskState.Paused;
		if (unsatisfiedCond == null)
		if (Task.State != TaskState.Active && (!isResuming || (isResuming && Task.Interruption == InterruptionType.Restartable)))
			unsatisfiedCond = deps.Unsatisfied ();
		if (unsatisfiedCond == null)
			return true;
		nextUnsatisfiedTaskCondition = unsatisfiedCond;
        if(isResuming)
        {
            if (!PlanForCons())
                nextUnsatisfiedTaskCondition = null;
        }
		return false;
	}

	void StartTask()
	{
      //Debug.LogWarningFormat("{0} is starting task {1}", Agent.gameObject.name, this);
        State = BehaviourState.Active;
		selfTask.State = TaskState.Active;
		Agent.SetExecutingTask (this);
        timeLeft = selfTask.Timed;
        selfTask.OnStart ();
	}

	void ResumeTask()
    {
      //Debug.LogWarningFormat("{0} is resuming task {1}", Agent.gameObject.name, this);
        State = BehaviourState.Active;
        selfTask.State = TaskState.Active;
		Agent.SetExecutingTask (this);
        
		selfTask.OnResume ();
	}




	void Activate()
	{

		if (Task.State == TaskState.None) {
			StartTask ();
		} else if (Task.State == TaskState.Paused) {
			ResumeTask ();
		}
	}

	void UpdateActiveTask()
	{
      //Debug.Log(Agent.gameObject.name + " updates active task " + this);
		TaskCondition unsatCond = null;
        if (selfTask.Timed > 0)
        {
            timeLeft -= Time.deltaTime;
          //Debug.LogWarning(this + "" + timeLeft);
            if (timeLeft <= 0)
            {
                selfTask.State = TaskState.Finished;
                return;
            }
        }
        if (AreAllTaskConditionsSatisfied (out unsatCond)) {
			if (selfTask.Finished ())
				selfTask.State = TaskState.Finished;
			else
				selfTask.OnUpdate ();
		}
		else {
			OnInterrupt ();
		}
	}

	void OnInterrupt()
	{
     //Debug.Log("interrupted " + Agent.gameObject.name + " " + Task.Interruption);
		switch (Task.Interruption ) {
		case InterruptionType.Terminal:
			Agent.SetExecutingTask (null);
                satisfactionBehaviour = null;
			State = BehaviourState.Failed;
                selfTask.OnTerminate();
			break;
		case InterruptionType.Resumable:
                satisfactionBehaviour = null;
                State = BehaviourState.None;
			Task.State = TaskState.Paused;
            Agent.SetExecutingTask(null);
            selfTask.OnInterrupt ();
			break;
		case InterruptionType.Restartable:
            satisfactionBehaviour = null;
            State = BehaviourState.Waiting;
			Task.State = TaskState.Paused;
            Agent.SetExecutingTask(null);
            selfTask.OnInterrupt ();
			break;
		}
	}
	public override void PlanAhead ()
	{

		cons = selfTask.Constraints;
		deps = selfTask.Dependencies;
        //Debug.Log("PlanAhead  " + Agent.gameObject.name);
        //if (cons != null)
        //   //Debug.Log("Cons " + cons.Count);
        Replan ();


	}
	void Replan()
	{
        Task.Init();
        if(Task.State == TaskState.Failed)
        {
            State = BehaviourState.ImpossibleToStart;
            return;
        }
        //if (Task is InteractionTask)
        //Debug.Log((Task as InteractionTask).Other);
        if (!PlanForCons())
            return;
        var isResuming = Task.State == TaskState.Paused;
        if (Task.State != TaskState.Active && (!isResuming || (isResuming && Task.Interruption == InterruptionType.Restartable)))
        {
            if (deps != null)
                for (int i = 0; i < deps.Count; i++)
                {
                    var dep = deps[i];
                    dep.FromTask = Task;
                    dep.Init();
                    dep.Update();
                    if (!dep.Met)
                    {
                        dep.Behaviour = Agent.GetSatisfactor(dep);
                        if (dep.Behaviour == null)
                        {
                            //backtrack AtScope if has one, or to the top
                            BacktrackOrFail(dep);
                            if (dep.Behaviour == null)
                                return;
                        }
                        else
                        {
                            dep.Behaviour.PlanAhead();
                            if (dep.Behaviour.State == BehaviourState.ImpossibleToStart)
                            {
                                //here should also go backtracking in terms of chosing alternative
                                BacktrackOrFail(dep);
                                if (dep.Behaviour == null)
                                    return; ;
                            }
                        }
                    }
                    else if (dep.Behaviour != null)
                    {
                        //dep.Behaviour.Terminate();
                        dep.Behaviour = null;
                    }
                }
            if (engageIn != null)
            {
                engageIn.Behaviour = Agent.GetSatisfactor(engageIn);
                if (engageIn.Behaviour == null)
                {
                    BacktrackOrFail(engageIn);
                    if (engageIn.Behaviour == null)
                        return;
                }
                else
                {
                    engageIn.Behaviour.PlanAhead();
                    if (engageIn.Behaviour.State == BehaviourState.ImpossibleToStart)
                    {
                        //here should also go backtracking in terms of chosing alternative
                        BacktrackOrFail(engageIn);
                        if (engageIn.Behaviour == null)
                            return; ;
                    }
                }
            }

        }

    }

    bool PlanForCons()
    {
        if (cons != null)
            for (int i = 0; i < cons.Count; i++)
            {
                var con = cons[i];
                //Debug.Log(con.Serialized.Render(Agent.gameObject));
                con.FromTask = Task;
                con.Init();

                con.Update();
                if (!con.Met)
                {
                    con.Behaviour = Agent.GetSatisfactor(con);
                    if (con.Behaviour == null)
                    {
                        //backtrack AtScope if has one, or to the top
                        BacktrackOrFail(con);
                        if (con.Behaviour == null)
                            return false;
                    }
                    else
                    {
                        con.Behaviour.PlanAhead();
                        if (con.Behaviour.State == BehaviourState.ImpossibleToStart)
                        {
                            //here should also go backtracking in terms of chosing alternative
                            BacktrackOrFail(con);
                            if (con.Behaviour == null)
                                return false;
                        }
                    }
                }
                else if (con.Behaviour != null)
                {
                    //con.Behaviour.Terminate();
                    con.Behaviour = null;
                }
            }
        return true;
    }
}

public class ComplexAgentBehaviour : AgentBehaviour
{
	ComplexTask cTask = null;
	List<TaskWrapper> tasks;
	TaskWrapper currentTaskWrapper;
	int curTaskIndex;
    bool firstTime = true;
	public override void Init (Agent agent, Task task)
	{
		base.Init (agent, task);
		cTask = task as ComplexTask;
		tasks = cTask.Decomposition;
        firstTime = true;
	}

	public override void Interrupt ()
	{
		switch (cTask.Interruption ) {
		case InterruptionType.Restartable:
			State = BehaviourState.None;
			break;
		case InterruptionType.Resumable:
			State = BehaviourState.Paused;
			break;
		case InterruptionType.Terminal:
			State = BehaviourState.Failed;
			break;
		}
		if (currentTaskWrapper != null && currentTaskWrapper.Behaviour != null)
			currentTaskWrapper.Behaviour.Interrupt ();
	}
	public override void Do ()
	{
		switch (State) {
		case BehaviourState.None:
			curTaskIndex = 0;
			currentTaskWrapper = null;
                if (Task.AtScope != null)
                {
                    if (!SelectNext())
                    {
                        State = BehaviourState.ImpossibleToStart;
                        return;

                    }
                }
                State = BehaviourState.Active;
			break;
		case BehaviourState.Active:
			if (currentTaskWrapper == null) {
				if (curTaskIndex < tasks.Count) {
					currentTaskWrapper = tasks[curTaskIndex];
					curTaskIndex++;
                        //Debug.Log("{0} changes task to {1} in {2}".Fmt(Agent.gameObject.name, currentTaskWrapper.Behaviour.Task.GetType().Name, Task.GetType().Name));
                    State = BehaviourState.Waiting;
				} else {
					if (!IsFinishedOrTerminated ())
                        {

                            Task.State = TaskState.None;
                            firstTime = false;
                        }
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
			switch (Task.Interruption ) {
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
           //Debug.Log("{0} finished {1}".Fmt(Agent.gameObject.name, Task.GetType().Name));
			return true;
		}
		if (cTask.Terminated ()) {
			State = BehaviourState.Failed;
			return true;
		}

		return false;
	}
	public override void PlanAhead ()
	{
		if (Task.Finished () &&!firstTime)
			return;
		tasks = cTask.Decomposition;
		for (int i = 0; i < tasks.Count; i++) {

			var task = tasks [i];
            task.FromTask = cTask;
            task.Init();
            task.Update();
			if (task.Met) { //It's a WHEN TO DO, not WHETHER TO SATISFY
				task.Behaviour = Agent.GetSatisfactor (task);

				if (task.Behaviour == null) {					
					//backtrack AtScope if has one, or to the top
					BacktrackOrFail(task);
					if(task.Behaviour == null)
						break;
				} else {
					task.Behaviour.PlanAhead ();
					if (task.Behaviour.State == BehaviourState.ImpossibleToStart) {
						//here - backtrack if possible
						BacktrackOrFail(task);
						if(task.Behaviour == null)
                            break;
					}
				}
			} else if (task.Behaviour != null) {
				//task.Behaviour.Terminate();
				task.Behaviour = null;
			}

            
		}
        //Debug.Log(State);
        foreach (var dtask in tasks)
        {

            if (dtask.Behaviour == null && State != BehaviourState.ImpossibleToStart)
            {
                //Debug.Log("Invalid state " + State);
            }
        }
    }


}


public abstract class TaskCondition
{
    public GameObject Root;
	public bool Update()
	{
        //Debug.Log(Serialized.Render(Root));
		met = Satisfied ();
		return met;
	}

	protected bool met;
	public bool Met { get { return met; } }
	public abstract bool Satisfied ();
	public virtual Type TaskCategory { get { return null; } }
	public virtual void InitTask(Task task) {}
	public AgentBehaviour Behaviour { get;set; }
	public virtual LocalizedString Serialized { get { return null; } }
	public virtual void Init()
	{
	}
}

public abstract class Constraint : TaskCondition
{
	public virtual bool Interruptive { get { return true; } }
}
	
public abstract class TaskWrapper : Constraint
{
	
	public HashSet<Type> AlreadyChosenBehaviours = new HashSet<Type>();
	public virtual int MaxAttempts { get { return 1; } }
	public virtual GameObject TargetAgent {  get { return FromTask.Root; } }
	public int CurrentAttempts;
	public Task FromTask;
}


