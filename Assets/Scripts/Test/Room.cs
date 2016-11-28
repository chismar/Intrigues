using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour
{

    public List<GameObject> allObjects;
    public List<GameObject> AllObjects {  get { return allObjects; } }

    private void Awake()
    {
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "AllObjects"));
    }
}
