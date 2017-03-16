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
        FindObjectOfType<ExternalUtilities>().NotifyOfNewGO(gameObject);
    }

    private void Start()
    {

        var e = EventsManager.Instance.GetEvent<EntityPostCreated>();
        e.Root = gameObject;
        EventsManager.Instance.FireEvent(e);
    }
    public string PrefabName { get; set; }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, 0, y);
    }
    
    public Vector3 Position {  get { return transform.position; } }
    
    
    public void RandomPosition(float x, float y, float range)
    {
        transform.position = new Vector3(x + Random.Range(-range, range), 0, y + Random.Range(-range, range));
    }
    public void RandomOffset( float range)
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x + Random.Range(-range, range), 0, pos.y + Random.Range(-range, range));
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

public class EntityPostCreated : Event
{ }