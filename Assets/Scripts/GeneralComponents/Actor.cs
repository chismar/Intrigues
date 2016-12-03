using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class Actor : MonoBehaviour {

    Dictionary<Type, List<EventAction>> actionsSet = null;
    List<EventAction> allActions = new List<EventAction>();
    Dictionary<Type, int> actionsInUse = new Dictionary<Type, int>();
    Stack<ActionWrapper> actionsStack = new Stack<ActionWrapper>();
    ActionWrapper curAction = null;
    public int ScenariosCount { get; set; }

    private void Awake()
    {
    }
    private void Start()
    {
        StartCoroutine(InitCoroutine());
        fuzziness  = new System.Random(UnityEngine.Random.Range(0, 500));
        Story.Instance.AttachNPC(gameObject);
    }

    IEnumerator InitCoroutine()
    {
        while (!Actions.Instance.Loaded)
            yield return null;
        actionsSet = Actions.Instance.FormActionsSet(gameObject);
        foreach (var cat in actionsSet)
            foreach (var action in cat.Value)
                allActions.Add(action);
    }
    System.Random fuzziness;
    private void Update()
    {
        if (actionsSet == null)
            return;
        if (curAction == null)
            ChooseAction();
        if (curAction != null)
        {
            //Debug.Log("Update " + curAction.Action.GetType().Name);
            curAction.Update(this);
            if(curAction.Action.State == EventAction.ActionState.Failed || curAction.Action.State == EventAction.ActionState.Finished)
            {
                //Debug.Log(curAction.Action.State);
                var aType = curAction.GetType();
                int countUsed = 0;
                if(actionsInUse.TryGetValue(aType, out countUsed))
                {
                    if (countUsed == 1)
                        actionsInUse.Remove(aType);
                    else
                        actionsInUse[aType] = countUsed - 1;
                }

                curAction = actionsStack.Count > 0 ? actionsStack.Pop() : null;
            }
        }
    }

    StringBuilder builder = new StringBuilder();
    void ChooseAction(Type category = null)
    {
        List<Dependency> maxDeps = null;
        var maxAction = FindAction(category, out maxDeps);
        //Debug.Log("choose action");
        if (maxAction != null)
        {
            Act(maxAction, maxDeps);
        }

    }
    public EventAction FindAction(Type category, out List<Dependency> maxDeps, Dependency targetDep = null)
    {
        var maxUt = 0f;
        EventAction maxAction = null;
        maxDeps = null;
        List<EventAction> actions = allActions;
        if (category != null)
            actionsSet.TryGetValue(category, out actions);
        //builder.Length = 0;
        //builder.Append("Actor choosing action: ");
        //builder.Append(gameObject.name).AppendLine();
        foreach (var action in actions)
        {
            EventAction a = action;
            //builder.Append(action.GetType().Name).Append(" ");
            int countUsed = 0;
            if (actionsInUse.TryGetValue(action.GetType(), out countUsed))
            {
                a = Actions.Instance.GetAction(action.GetType());
            }
            a.Init();
            if (targetDep != null)
                targetDep.InitAction(a);
            a.Root = gameObject;
            var ut = a.Utility();
            ut = ut * (1f + ((float)fuzziness.NextDouble() - 0.5f) * 2f * 0.1f);
            //builder.Append(ut).Append(" ").Append(a.State).AppendLine();
            var deps = a.GetDependencies();
            if (ut > maxUt && Traverse(deps))
            {
                maxUt = ut;
                maxAction = a;
                maxDeps = deps;
            }
        }
        //Debug.Log(builder.ToString());
        return maxAction;
    }
    public bool CanDo(Type interactionType)
    {
        var a =  Actions.Instance.GetAction(interactionType);
        a.Root = gameObject;
        bool res =  a.Interaction();
        return res;
    }
    HashSet<Type> externalDependencies = new HashSet<Type>();

    public void Act(EventAction action, List<Dependency> deps = null)
    {
        //Debug.Log("Act " + action.GetType().Name, gameObject);
        //Debug.Log(action.State);
        ActionWrapper wrapper = new ActionWrapper();
        wrapper.Action = action;
        bool canDo = true;
        if (deps == null)
        {
            wrapper.Deps = action.GetDependencies();//Here it should ask the action to get its dependencies
            canDo = Traverse(wrapper.Deps);//Here it should traverse those and answer whether it's possible to achieve this action at all, 
                                           //while also marking external dependencies
        }
        else
            wrapper.Deps = deps;
        if (!canDo)
        {
            action.State = EventAction.ActionState.Failed;
        }
        else
        {
            //Debug.Log("Put as current action");
            PutAsCurrentAction(wrapper);
        }
    }
    private void PutAsCurrentAction(ActionWrapper wrapper)
    {
        if(curAction != null)
        {
            actionsStack.Push(curAction);
        }
        int countUsed = 0;
        if (actionsInUse.TryGetValue(wrapper.Action.GetType(), out countUsed))
            actionsInUse[wrapper.Action.GetType()] = countUsed + 1;
        else
            actionsInUse.Add(wrapper.Action.GetType(), 1);
        curAction = wrapper;
    }

    public bool Traverse(List<Dependency> deps)
    {
        if (deps == null)
            return true;
        bool canDo = true;
        foreach ( var dep in deps)
        {
            if (dep.Satisfied())
                continue;
            if(externalDependencies.Contains(dep.GetType()))
            {
                canDo = false;
                break;
            }
            var cat = dep.ActionCategory();
            var actions = Actions.Instance.GetActionsByCategory(cat);
            if (actions.Count == 0)
                externalDependencies.Add(dep.GetType());
            bool traversed = false;
            foreach (var action in actions)
            {
                if(Traverse(Actions.Instance.GetDeps(action)))
                {
                    traversed = true;
                    break;
                }
            }
            if (!traversed)
                canDo = false;
        }
        return canDo;
    }
}


public class ActionWrapper
{
    public EventAction Action;
    public List<Dependency> Deps;
    Dependency currentDep;
    public void Update(Actor actor)
    {
        if(Action.State == EventAction.ActionState.None)
        {
            bool satisfied = true;
            //Debug.Log(Deps);
            if (Deps != null)
            {
                //Debug.Log(Deps.Count);
                foreach (var dep in Deps)
                {
                    //Debug.LogFormat("{0} = {1}", dep.GetType(), dep.Satisfied());
                    if (!dep.Satisfied())
                    {
                        satisfied = false;
                        break;
                    }
                }
            }
            if (satisfied)
            {
                //Debug.Log("Performing " + Action.GetType().Name);
                Action.Action();

            }
            else
            {
                if (currentDep == null || currentDep.Satisfied())
                {
                    var dep = Deps.Find(d => !d.Satisfied());
                    //Debug.Log(Deps.Count);
                    currentDep = dep;
                    //Debug.Log(dep.GetType().Name);
                }
                if (currentDep.ActionWrapper == null)
                {
                    currentDep.ActionWrapper = new ActionWrapper();
                    currentDep.ActionWrapper.Action = actor.FindAction(currentDep.ActionCategory(), out currentDep.ActionWrapper.Deps, currentDep);
                }
                currentDep.ActionWrapper.Update(actor);
                
                
            }
        }

        if(Action.State == EventAction.ActionState.Started)
        {
            //Debug.Log("Update the action " + Action.GetType().Name);
            Action.Update();
        }
        
        if(Action.State == EventAction.ActionState.Failed)
        {
            //Debug.Log(Action.State);
        }

        if(Action.State == EventAction.ActionState.Finished)
        {

            //Debug.Log(Action.State);
        }
    }
}

public abstract class Dependency
{
    public abstract System.Type ActionCategory();
    public abstract bool Satisfied(); //Внутри оно так же должно прекращать
    //действия и прочее если что-то исполняется
    public abstract void InitAction(EventAction action);
    public ActionWrapper ActionWrapper { get; set; }
}

public class CloserThan : Dependency
{
    Transform targetTransform;
    Transform rootTransform;
    float distance;
    public Dependency Init(GameObject interactable, GameObject initiator, float distance)
    {
        if (interactable == null || initiator == null)
            return this;
        this.distance = distance;
        rootTransform = initiator.transform;
        targetTransform = interactable.transform;
        return this;
    }
    
    public override Type ActionCategory()
    {
        return typeof(ScriptedTypes.move_to);
    }

    public override void InitAction(EventAction action)
    {
        var moveTo = action as ScriptedTypes.move_to;
        moveTo.Target = targetTransform.gameObject;
        moveTo.Distance = distance;
    }
    
    public override bool Satisfied()
    {
        return (targetTransform.position - rootTransform.position).magnitude < distance;
    }
}

namespace ScriptedTypes
{
    public interface move_to
    {
        GameObject Target { get; set; }
        float Distance { get; set; }
    }
}