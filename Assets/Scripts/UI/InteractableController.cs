using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableController : MonoBehaviour
{

    InteractionsView view;
    void Start()
    {
        view = FindObjectOfType<InteractionsView>();
    }
    RaycastHit hit;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    return;
            SnapToInteractable(hit.transform.gameObject);
        }
        if (Input.GetMouseButtonUp(1))
        {
            ClearSelection();
        }
    }
    Interactable interactable;
    List<EventAction> availableInteractions = new List<EventAction>();
    public void SnapToInteractable(GameObject go)
    {
        Debug.Log(go);
        ClearSelection();
        interactable = go.GetComponent<Interactable>();
        if (interactable == null)
            return;
        var highlight = go.GetComponent<Highlightable>();
        if (highlight != null)
            highlight.LitUp();

        var actor = GetComponent<Actor>();
        if (actor == null)
            return;
        availableInteractions.Clear();
        foreach (var inter in actor.allInteractions)
        {
            (inter as EventInteraction).Initiator = gameObject;
            inter.Root = go;
            if (inter.Filter())
                availableInteractions.Add(inter);
        }
        view.ShowInteractions(availableInteractions);
        
    }

    void ClearSelection()
    {
        if (interactable == null)
            return;
        var highlight = interactable.GetComponent<Highlightable>();
        if (highlight != null)
            highlight.LitDown();
        interactable = null;
        view.ShowInteractions(null);
    }
}
