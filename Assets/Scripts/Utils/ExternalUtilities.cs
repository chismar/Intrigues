using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExternalUtilities : Root<ExternalUtilities>
{

    public int NextID { get; set; }
    private void Awake()
    {
        base.Awake();
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "AllEntities", "SelectByWeight", "Any", "Log", "Has", "SpawnPrefab", "FindObject", "NoOne", "RandomPoint"));
    }
    //ayn
    System.Random rand = new System.Random();
    public delegate bool GOCheckDelegate(GameObject go);
    List<GameObject> cachedList = new List<GameObject>();
    public GameObject Any(List<GameObject> list, GOCheckDelegate checker)
    {
        if (list == null)
            return null;
        cachedList.Clear();
        foreach (var go in list)
            if (checker(go))
                cachedList.Add(go);
        if (cachedList.Count > 0)
            return cachedList[rand.Next(cachedList.Count)];
        return null;
    }

    public delegate float GOFloatDelegate(GameObject go);
    public GameObject SelectByWeight(List<GameObject> list, GOFloatDelegate weight)
    {
        GameObject mostWeight = null;
        float maxWeight = 0.05f;
        foreach(var go in list)
        {
            var w = weight(go);
            if(w > maxWeight)
            {
                maxWeight = w;
                mostWeight = go;
            }
        }
        return mostWeight;
    }
    public bool Log(object data)
    {
        Debug.Log(data);
        return true;
    }

    public bool Has(GameObject go)
    {
        return go != null;
    }

    public GameObject SpawnPrefab(string name, string goName)
    {
        var go =  GameObject.Instantiate(Resources.Load("Prefabs/" + name) as GameObject);
        go.name = goName;
        go.GetComponent<Entity>().PrefabName = name;
        return go;
    }

    public GameObject NoOne()
    {
        return null;
    }

    public delegate bool CheckDelegate(GameObject go);
    List<GameObject> found = new List<GameObject>();
    public GameObject FindObject(string prefabType, CheckDelegate checker)
    {
        found.Clear();
        foreach (var obj in Story.Instance.AllActors)
        {
            if (obj.GetComponent<Entity>().PrefabName == prefabType)
            {
                if (checker(obj))
                    found.Add(obj);
            }
        }
        if (found.Count == 0)
            return null;
        else
            return found[Random.Range(0, found.Count)];
    }


	public Vector2 RandomPoint(Vector2 pos, float distance)
	{
		return Random.insideUnitCircle * distance + pos;
	}
    List<GameObject> allActors = new List<GameObject>();
    public List<GameObject> AllEntities()
    {
        return allActors;
    }

    public void NotifyOfNewGO(GameObject go)
    {
        allActors.Add(go);
    }
}
