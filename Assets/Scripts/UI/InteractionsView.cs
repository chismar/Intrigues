using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InteractionsView : MonoBehaviour
{

    public GameObject InteractionButtonPrefab;
    public InteractableController Controller;
    Interactable target;
    void Update()
    {
        if(Controller != null)
        {
            if(Controller.interactable != null && target != Controller.interactable)
            {
                ShowInteractions(null);
                if(updater != null)
                StopCoroutine(updater);
                updater = null;
                target = Controller.interactable;
                if (!Controller.noInteractions)
                {
                    ShowInteractions(Controller.tasks);
                    StartCoroutine(updater = Updater());
                }
                    
            }
        }
        
    }
    


    public void ShowInteractions(List<InteractionTask> interactions)
    {
        while (buttons.Count > 0)
        {
            Destroy(buttons[buttons.Count - 1].gameObject);
            buttons.RemoveAt(buttons.Count - 1);
        }
        
        if (interactions == null)
            return;

        //Debug.Log("show interactions");
        foreach (var interaction in interactions)
        {
            CreateButton(interaction);
        }
        if (interactions != null)
            StartCoroutine(updater = Updater());
    }

    public void CreateButton(InteractionTask interaction)
    {
        var button = GameObject.Instantiate(InteractionButtonPrefab);
        var iB = button.GetComponent<InteractableButton>();
        iB.Interaction = interaction;
        button.transform.SetParent(transform);
        buttons.Add(iB);
    }
    List<InteractableButton> buttons = new List<InteractableButton>();
    public void UpdateView()
    {
        foreach (var button in buttons)
            button.DemandUpdate();

    }
    IEnumerator updater;
    IEnumerator Updater()
    {
        while(true)
        {
            UpdateView();
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
