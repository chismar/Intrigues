using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public void ComponentAdded()
    {

    }
    
    public string PrefabName { get; set; }

    public void Position(float x, float y)
    {
        transform.position = new Vector3(x, y);
    }

    
    public void RandomPosition(float x, float y, float range)
    {
        transform.position = new Vector3(x + Random.Range(-range, range), y + Random.Range(-range, range));
    }
}
