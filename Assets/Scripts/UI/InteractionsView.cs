using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractionsView : MonoBehaviour
{

    public GameObject InteractionButtonPrefab;

    public void ShowInteractions(List<EventAction> interactions)
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        if (interactions == null)
            return;

        Debug.Log("show interactions");
        foreach (var interaction in interactions)
        {
            var button = GameObject.Instantiate(InteractionButtonPrefab);
            button.GetComponent<InteractableButton>().Interaction = interaction;
            button.transform.SetParent(transform);
        }
    }
}
