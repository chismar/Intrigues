using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{

    public bool Can(System.Type interactionType, GameObject initiator)
    {
        var a = Actions.Instance.GetAction(interactionType);
        a.Root = gameObject;
        var i = a as EventInteraction;
        GameObject cachedIniniator = null;
        if (i != null)
        {
            cachedIniniator = i.Initiator;
            i.Initiator = initiator;
            var scoped =  a.Filter();
            i.Initiator = cachedIniniator;
            return scoped;
        }
        return a.Filter();
    }
}
