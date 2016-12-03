using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Story : Root<Story>
{
    [SerializeField]
    int prefferableActorsCount;
    public int TargetActorsCount { get { return prefferableActorsCount; } set { prefferableActorsCount = value; } }

    [SerializeField]
    int prefferableScenariosCountPerActor;
    public int TargetScenariosPerActor { get { return prefferableScenariosCountPerActor; } set { prefferableScenariosCountPerActor = value; } }

    List<GameObject> npcs = new List<GameObject>();

    public void AttachNPC(GameObject go)
    {
        npcs.Add(go);
    }

    private void Awake()
    {
        base.Awake();
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "AllActors"));
    }
    public List<GameObject> AllActors {  get { return npcs; } }

    public int ActorsCount {  get { return npcs.Count; } }
}
