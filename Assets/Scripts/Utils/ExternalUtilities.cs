using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExternalUtilities : MonoBehaviour
{

    private void Awake()
    {
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "Any"));
    }
    //ayn
    System.Random rand = new System.Random();
    public delegate bool GOCheckDelegate(GameObject go);
    List<GameObject> cachedList = new List<GameObject>();
    public GameObject Any(List<GameObject> list, GOCheckDelegate checker)
    {
        cachedList.Clear();
        foreach (var go in list)
            if (checker(go))
                cachedList.Add(go);
        if (cachedList.Count > 0)
            return cachedList[rand.Next(cachedList.Count)];
        return null;
    }
}
