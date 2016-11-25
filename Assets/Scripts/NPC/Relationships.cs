using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class Relationships : MonoBehaviour
{
    //Dictionary<GameObject, Relationship> all = new Dictionary<GameObject, Relationship>();

    public float RelationsWith(GameObject go)
    {
        return RelationsMetrics.Instance.ComputeRelationsFor(gameObject, go);
    }
}

public class Relationship
{
    public bool UpdatedThisFrame;
    public float Result {  get { return (OtherComponent + SocialComponent) / 2; } }
    public float NonSocialResult { get { return OtherComponent; } }
    public float SocialComponent;
    public float OtherComponent;


}