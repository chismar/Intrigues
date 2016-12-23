using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InteractionsView : MonoBehaviour
{

    public GameObject InteractionButtonPrefab;
    InteractableController controller;
    public void ShowInteractions(List<EventAction> interactions, InteractableController controller)
    {
        this.controller = controller;
        while (buttons.Count > 0)
        {
            Destroy(buttons[buttons.Count - 1].gameObject);
            buttons.RemoveAt(buttons.Count - 1);
        }
        if (updater != null)
        {
            StopCoroutine(updater);
            updater = null;
        }
        
        if (interactions == null)
            return;

        Debug.Log("show interactions");
        foreach (var interaction in interactions)
        {
            CreateButton(interaction);
        }
        if (interactions != null)
            StartCoroutine(updater = Updater());
    }

    public void CreateButton(EventAction interaction)
    {
        var button = GameObject.Instantiate(InteractionButtonPrefab);
        var iB = button.GetComponent<InteractableButton>();
        iB.Interaction = interaction;
        iB.View = this;
        button.transform.SetParent(transform);
        buttons.Add(iB);
    }
    List<InteractableButton> buttons = new List<InteractableButton>();
    HashSet<Type> intersToIgnore = new HashSet<Type>();
    public void UpdateView()
    {
        if(controller.GetComponent<Actor>().curAction != null)
        {
            while(buttons.Count > 0)
            {
                Destroy(buttons[buttons.Count - 1].gameObject);
                buttons.RemoveAt(buttons.Count - 1);
            }
            return;
        }
        intersToIgnore.Clear();
        for ( int i =0; i < buttons.Count; i++)
        {
            var button = buttons[i];
            intersToIgnore.Add(button.Interaction.GetType());
            if (!button.Interaction.Filter())
            {
                Destroy(button.gameObject);
                buttons.RemoveAt(i);
                i--;
            }
            
        }
        var inters = controller.UpdateInteractions(intersToIgnore);
        foreach(var inter in inters)
        {
            CreateButton(inter);
        }
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
