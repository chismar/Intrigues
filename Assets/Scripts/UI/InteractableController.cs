using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableController : MonoBehaviour
{

    InteractionsView view;
    void Start()
    {
        view = FindObjectOfType<InteractionsView>();
        view.Controller = this;
        
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
    Agent agent;
    private void Awake()
    {
        agent = GetComponent<Agent>();
    }
    public Interactable interactable;
    public bool noInteractions = false;
    public List<InteractionTask> tasks = new List<InteractionTask>();
    public bool SnapToInteractable(GameObject go)
    {

        noInteractions = true;
        Debug.Log("Snap to " + go);
        ClearSelection();
        interactable = go.GetComponent<Interactable>();
        if (interactable == null)
            return false;
        var highlight = go.GetComponent<Highlightable>();
        if (highlight != null)
            highlight.LitUp();
        tasks.Clear();
        foreach(var typePool in agent.tasksByType)
        {
            if(typeof(InteractionTask).IsAssignableFrom(typePool.Key))
            {
                //found an interaction task
                var task = typePool.Value.Get() as InteractionTask;
                var oip = task.OtherIsProvided;
                task.Root = gameObject;
                task.Other = go;
                task.At = go;
                task.OtherIsProvided = true;
                task.State = TaskState.None;
                task.Init();
                task.Dependencies.Init();
                task.Constraints.Init();
                if (task.EngageIn != null)
                    task.EngageIn.Init();
                if (task.OtherFilter())
                    tasks.Add(task);
                else
                {
                    typePool.Value.Return(task);
                }

            }
        }
        Debug.Log("Interactions: " + tasks.Count);
        noInteractions = tasks.Count == 0;
        return true;
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
