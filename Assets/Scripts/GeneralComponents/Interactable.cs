using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{

    public bool Can(System.Type interactionType)
    {
        var a = Actions.Instance.GetAction(interactionType);
        a.Root = gameObject;
        return a.Filter();
    }
}
