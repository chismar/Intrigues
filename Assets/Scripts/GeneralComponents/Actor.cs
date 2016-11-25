using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Actor : MonoBehaviour {

    Dictionary<string, List<EventAction>> actionsSet = null;
    List<EventAction> allActions = new List<EventAction>();
    private void Start()
    {
        actionsSet = Actions.Instance.FormActionsSet(gameObject);
        foreach (var cat in actionsSet)
            foreach (var action in cat.Value)
                allActions.Add(action);
    }

    void ChooseAction()
    {
        Actions.Instance.ActByWeight(gameObject, 0.1f, allActions);
    }

    public bool CanDo(string interactionType)
    {
        return false;
    }

    public void Do(string interactionType, GameObject target)
    {

    }
}
