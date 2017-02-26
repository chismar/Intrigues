using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ExternalUtilities : Root<ExternalUtilities>
{

    public int NextID { get; set; }
    private void Awake()
    {
        base.Awake();
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "Mag", "AllEntities", "SelectByWeight", "Any", "Log", "Has", "SpawnPrefab", "FindObject", "NoOne", "RandomPoint"));
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
    System.Random fuzziness = new System.Random();
    public GameObject SelectByWeight(List<GameObject> list, GOFloatDelegate weight)
    {
        GameObject mostWeight = null;
        float maxWeight = 0.05f;
        foreach(var go in list)
        {
            var w = weight(go) + (float)(fuzziness.NextDouble() * 0.01 - 0.05);
            
            if (w > maxWeight)
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


    public float Mag(Vector3 vec)
    {
        return vec.magnitude;
    }
	public Vector2 RandomPoint(Vector2 pos, float distance)
	{
		return Random.insideUnitCircle * distance + pos;
	}
    public List<GameObject> allActors = new List<GameObject>();
    public List<GameObject> AllEntities()
    {
        return allActors;
    }

    public void NotifyOfNewGO(GameObject go)
    {
        allActors.Add(go);
    }
    bool enabled = true;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
            enabled = !enabled;
    }
    Vector2 scroll;
    private void OnGUI()
    {
        if(enabled)
        {
            scroll = GUI.BeginScrollView(Rect.MinMaxRect(0, 0, 700, 500), scroll, Rect.MinMaxRect(0, 0, 700, allActors.Count * 30));
            int index = 0;
            foreach (var go in allActors)
            {
                var agent = go.GetComponent<Agent>();
                if (agent == null)
                    continue;
                var curBeh = agent.currentBehaviour;
                var curPrimBeh = agent.currentTaskBehaviour;
                if (curBeh != null)
                {

                    GUI.Label(Rect.MinMaxRect(0, index * 30, 200, (index + 1) * 30), curBeh.ToString());
                    GUI.Label(Rect.MinMaxRect(200, index * 30, 300, (index + 1) * 30), curBeh.State.ToString());
                }
                else
                {

                    GUI.Label(Rect.MinMaxRect(0, index * 30, 200, (index + 1) * 30), "No behaviour");
                }
                if (curPrimBeh != null)
                {

                    GUI.Label(Rect.MinMaxRect(300, index * 30, 500, (index + 1) * 30), curPrimBeh.ToString());
                    GUI.Label(Rect.MinMaxRect(500, index * 30, 600, (index + 1) * 30), curPrimBeh.State.ToString());
                }
                else
                {

                    GUI.Label(Rect.MinMaxRect(300, index * 30, 500, (index + 1) * 30), "No primitive behaviour");
                }
                GUI.Label(Rect.MinMaxRect(600, index * 30, 700, (index + 1) * 30), go.name);
                index++;
            }
            GUI.EndScrollView();
        }
        
    }
}
