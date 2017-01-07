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
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;
            else
            {
                bool foundInter = false;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
                {

				if (hit.transform)
					foundInter = SnapToInteractable(hit.transform.gameObject);
				else
					ClearSelection();
                    
                }
                if(!foundInter)
                {
                    var hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                    Debug.Log(hit.transform);
                    if (hit.transform)
                        SnapToInteractable(hit.transform.gameObject);
                    else
                        ClearSelection();
                }
            }
        
        if (Input.GetMouseButtonUp(1))
        {
            ClearSelection();
        }
    }
    Interactable interactable;
    List<EventAction> availableInteractions = new List<EventAction>();
    Actor actor;
    public bool SnapToInteractable(GameObject go)
    {
        Debug.Log(go);
        ClearSelection();
        interactable = go.GetComponent<Interactable>();
        if (interactable == null)
            return false;
        var highlight = go.GetComponent<Highlightable>();
        if (highlight != null)
            highlight.LitUp();

        actor = GetComponent<Actor>();
        if (actor == null)
            return false;
        availableInteractions.Clear();
        foreach (var inter in actor.allInteractions)
        {
            (inter as EventInteraction).Initiator = gameObject;
            inter.Root = go;
            if (inter.Filter())
                availableInteractions.Add(inter);
        }
        view.ShowInteractions(availableInteractions, this);
        return true;
    }

    public List<EventAction> UpdateInteractions(HashSet<System.Type> interactionsToIgnore)
    {
        availableInteractions.Clear();
        foreach (var inter in actor.allInteractions)
        {
            if (interactionsToIgnore.Contains(inter.GetType()))
                continue;
            (inter as EventInteraction).Initiator = gameObject;
            inter.Root = interactable.gameObject;
            if (inter.Filter())
                availableInteractions.Add(inter);
        }
        return availableInteractions;
    }
    void ClearSelection()
    {
        if (interactable == null)
            return;
        var highlight = interactable.GetComponent<Highlightable>();
        if (highlight != null)
            highlight.LitDown();
        interactable = null;
        view.ShowInteractions(null, this);
    }
}
