using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RelationsMetrics : Root<RelationsMetrics>
{ 
    public delegate float RelationDelegate(GameObject root, GameObject other);
    public List<RelationDelegate> metrics = new List<RelationDelegate>();
    public float ComputeRelationsFor(GameObject root, GameObject other)
    {
        float accumulator = 0f;
        for ( int i = 0; i < metrics.Count; i++)
        {
            accumulator += metrics[i](root, other);
        }
        if(metrics.Count != 0)
            accumulator /= metrics.Count;
        return accumulator;
    }
}
