using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {


    public int Id { get; internal set; }
	public void ComponentAdded()
    {
        
    }

    private void Awake()
    {
        Id = ExternalUtilities.Instance.NextID++;
        var e = EventsManager.Instance.GetEvent<EntityCreated>();
        e.Root = gameObject;
        EventsManager.Instance.FireEvent(e);
    }
    public string PrefabName { get; set; }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, y);
    }
    
    public Vector3 Position {  get { return transform.position; } }
    
    
    public void RandomPosition(float x, float y, float range)
    {
        transform.position = new Vector3(x + Random.Range(-range, range), y + Random.Range(-range, range));
    }

    public delegate void GODelegate(GameObject go);
    public event GODelegate OnDeath;

    private void OnDestroy()
    {
        if (OnDeath != null)
            OnDeath(gameObject);
    }
}


public class EntityCreated : Event
{ }
