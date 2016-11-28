using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Actor : MonoBehaviour {

    Dictionary<Type, List<EventAction>> actionsSet = null;
    List<EventAction> allActions = new List<EventAction>();
    Stack<ActionWrapper> actionsStack = new Stack<ActionWrapper>();
    ActionWrapper curAction = null;
    private void Start()
    {
        actionsSet = Actions.Instance.FormActionsSet(gameObject);
        foreach (var cat in actionsSet)
            foreach (var action in cat.Value)
                allActions.Add(action);
    }

    private void Update()
    {
        if (curAction == null)
            ChooseAction();
        if (curAction != null)
            curAction.Update();
    }

    void ChooseAction(Type category = null)
    {
        var maxUt = 0f;
        EventAction maxAction = null;
        List<Dependency> maxDeps = null;
        List<EventAction> actions = allActions;
        if (category != null)
            actionsSet.TryGetValue(category, out actions);
        foreach (var action in allActions)
        {
            action.Root = gameObject;
            var ut = action.Utility();
            var deps = Actions.Instance.GetDeps(action.GetType());
            if (ut > maxUt && Traverse(deps))
            {
                maxUt = ut;
                maxAction = action;
                maxDeps = deps;
            }
        }
        if(maxAction != null)
        {
            var action = Actions.Instance.GetAction(maxAction.GetType());
            Act(action, maxDeps);
        }

    }

    public bool CanDo(Type interactionType)
    {
        var a =  Actions.Instance.GetAction(interactionType);
        a.Root = gameObject;
        return a.Interaction();
        
    }
    HashSet<Type> externalDependencies = new HashSet<Type>();

    public void Act(EventAction action, List<Dependency> deps = null)
    {
        ActionWrapper wrapper = new ActionWrapper();
        wrapper.Action = action;
        bool canDo = true;
        if (deps == null)
        {
            wrapper.Deps = Actions.Instance.GetDeps(action.GetType());//Here it should ask the action to get its dependencies
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
            PutAsCurrentAction(wrapper);
        }
    }
    private void PutAsCurrentAction(ActionWrapper wrapper)
    {
        if(curAction != null)
        {
            actionsStack.Push(curAction);
            curAction = wrapper;
        }
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
    public void Update()
    {
        if(Action.State == EventAction.ActionState.None)
        {
            bool satisfied = true;
            if (Deps != null)
            foreach (var dep in Deps)
            {
                if(!dep.Satisfied())
                {
                    satisfied = false;
                    break;
                }
            }
            if (satisfied)
                Action.Action();
            else
            {
                if (currentDep == null || currentDep.Satisfied())
                {
                    var dep = Deps.Find(d => !d.Satisfied());
                    currentDep = dep;
                }
                currentDep.ActionWrapper.Update();
            }
        }

        if(Action.State == EventAction.ActionState.Started)
        {
            Action.Update();
        }
        
        if(Action.State == EventAction.ActionState.Failed)
        {

        }

        if(Action.State == EventAction.ActionState.Finished)
        {

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
    public CloserThan(GameObject root, GameObject other, float distance)
    {
        this.distance = distance;
        rootTransform = root.transform;
        targetTransform = other.transform;
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