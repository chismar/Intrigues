using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class Relationships : MonoBehaviour
{
    Dictionary<GameObject, Relationship> all = new Dictionary<GameObject, Relationship>();
    static float TooOld = 5f;
    public float RelationsWith(GameObject go)
    {
        Relationship rel = null;
        if(all.TryGetValue(go, out rel))
        {
            if (Time.realtimeSinceStartup - rel.TimeStamp > TooOld)
            {
                rel.Value = RelationsMetrics.Instance.ComputeRelationsFor(gameObject, go);
                rel.TimeStamp = Time.realtimeSinceStartup;
            }
        }
        else
        {
            rel = new Relationship();
            rel.Value = RelationsMetrics.Instance.ComputeRelationsFor(gameObject, go);
            rel.TimeStamp = Time.realtimeSinceStartup;
            all.Add(go, rel);
            go.GetComponent<Entity>().OnDeath += OnGODeath;
        }
        return rel.Value;
    }

    private void OnGODeath(GameObject go)
    {
        all.Remove(go);
    }

    private void Start()
    {

    }
    
}

public class Relationship
{
    public float TimeStamp;
    public float Value;


}