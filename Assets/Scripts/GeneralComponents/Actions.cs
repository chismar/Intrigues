using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

public class Actions : Root<Actions>
{
    BasicLoader loader;

    Dictionary<Type, EventAction> eventActionsByType = new Dictionary<Type, EventAction>();
    List<EventAction> actions = new List<EventAction>();
    Dictionary<Type, List<EventAction>> eventsByCategory = new Dictionary<Type, List<EventAction>>();

    Dictionary<Type, List<EventAction>> interactionsByCategory = new Dictionary<Type, List<EventAction>>();

    Dictionary<Type, List<EventAction>> actionsByCategory = new Dictionary<Type, List<EventAction>>();
    public bool Loaded = false;

    void Awake()
    {
        base.Awake();
        loader = FindObjectOfType<BasicLoader>();
        loader.Loaded += OnLoad;
    }

    static WaitForSeconds clearUpWait = new WaitForSeconds(100);
    List<GameObject> keys = new List<GameObject>();

    void OnLoad()
    {
        var eventTypes = loader.Engine.FindTypesCastableTo<EventAction>();
        foreach (var type in eventTypes)
        {
            var action = Activator.CreateInstance(type) as EventAction;

            var actionMeta = type.GetCustomAttributes(typeof(EventActionAttribute), false)[0] as EventActionAttribute;
            action.Meta = actionMeta;
            eventActionsByType.Add(type, action);
            List<EventAction> catList = null;

            var cats = eventsByCategory;
            if (action.Meta.IsInteraction)
                cats = interactionsByCategory;
            else if (action.Meta.IsAIAction)
                cats = actionsByCategory;

                actions.Add(action);
            var categories = type.GetInterfaces();
            if (categories.Length == 1)
                action.Meta.Category = categories[0].Name;
            else if (categories.Length == 0)
            {
                if (!cats.TryGetValue(typeof(EventAction), out catList))
                {
                    catList = new List<EventAction>();
                    cats.Add(typeof(EventAction), catList);
                }
                catList.Add(action);
            }
                
            foreach ( var cat in categories)
            {
                if (!cats.TryGetValue(cat, out catList))
                {
                    catList = new List<EventAction>();
                    cats.Add(cat, catList);
                }
                catList.Add(action);
            }
        }

        weights = new ActionWeight[actions.Count];
        Loaded = true;
    }

    public EventAction GetAction(Type type)
    {
        var a = Activator.CreateInstance(type) as EventAction;
        a.Meta = eventActionsByType[type].Meta;
        a.Init();
        return a;
    }
    public List<Type> GetActionsByCategory(Type cat)
    {
        var list = new List<Type>();
        List<EventAction> aList = null;
        if (actionsByCategory.TryGetValue(cat, out aList))
            foreach (var a in aList)
                list.Add(a.GetType());
        return list;
    }

    const bool DebugGeneration = true;
    ObjectPool<StringBuilder> debugBuilders = new ObjectPool<StringBuilder>();
    ObjectPool<HashSet<EventAction>> eaPool = new ObjectPool<HashSet<EventAction>>();
    ObjectPool<List<EventAction>> eaListPool = new ObjectPool<List<EventAction>>();
    public void Generate(GameObject go, float fuzzy = 0f)
    {

        var debugBuilder = debugBuilders.Get();
        if (DebugGeneration)
        {
            debugBuilder.Length = 0;
            debugBuilder.AppendLine(go.name);
            //var n = go.GetComponent<Named>();
            //if (n != null)
            //    debugBuilder.AppendLine(n.FullName);
        }


        var performedActions = eaPool.Get();
        var maximizeActions = eaListPool.Get();
        maximizeActions.Clear();
        performedActions.Clear();
        bool oneMoreRun = true;
        int iterations = 0;
        while (oneMoreRun)
        {
            if (DebugGeneration)
                debugBuilder.AppendLine("=================================================================");
            if (Application.isEditor)
                if (iterations++ > 50)
                    break;
            oneMoreRun = false;
            foreach (var categoryPair in eventsByCategory)
            {
                var category = categoryPair.Value;
                if (DebugGeneration)
                    debugBuilder.Append(" ").AppendLine(categoryPair.Key.Name);
                maximizeActions.Clear();
                foreach (var action in category)
                {

                    if (DebugGeneration)
                        debugBuilder.Append("  ").Append(action.GetType().Name).Append(" = ");
                    if (ActedThisWayAndShouldNoMore(go, action) || (action.Meta.OncePerTurn && performedActions.Contains(action)))
                    {
                        debugBuilder.AppendLine("NO");
                        continue;
                    }
                    if (!action.Meta.ShouldHaveMaxUtility)
                    {
                        var cachedRoot = action.Root;
                        action.Root = go;
                        if (action.Filter())
                        {
                            var ut = action.Utility();
                            var useful = ut > 0;
                            oneMoreRun |= useful;
                            if (useful)
                            {
                                if (action.Meta.OncePerTurn)
                                    performedActions.Add(action);
                                action.Action();
                                if (DebugGeneration)
                                    debugBuilder.AppendLine(ut.ToString());
                                NotifyOfAct(go, action);
                            }
                            else
                            if (DebugGeneration)
                                debugBuilder.AppendLine("NO");
                        }
                        else
                        if (DebugGeneration)
                            debugBuilder.AppendLine("NO");
                        action.Root = cachedRoot;
                    }
                    else
                    {
                        maximizeActions.Add(action);
                        if (DebugGeneration)
                            debugBuilder.AppendLine("ONLY_MAX");
                    }
                }
                if (DebugGeneration)
                    debugBuilder.Append("  CHOSEN_MAX = ");
                if (maximizeActions.Count > 0)
                {
                    var act = GenerateMostUseful(go, fuzzy, maximizeActions, performedActions);
                    if (DebugGeneration)
                        debugBuilder.AppendLine(act == null ? "NOTHING" : act.GetType().Name);
                    if (act != null)
                    {
                        if (act.Meta.OncePerTurn)
                            performedActions.Add(act);
                        oneMoreRun = true;
                    }
                }
                else if (DebugGeneration)
                    debugBuilder.AppendLine( "NOTHING");

            }
            eaListPool.Return(maximizeActions);
            eaPool.Return(performedActions);
        }
        if (DebugGeneration)
            debugBuilder.AppendLine("INTERACTIONS:");
        /*var inter = go.GetComponent<Interactable>();
        if (inter != null)
        {
            GetInteractions(inter);
            if (DebugGeneration)
                foreach (var i in inter.Options)
                    debugBuilder.Append(" ").AppendLine(i.GetType().Name);
        }*/

        if (DebugGeneration)
            Debug.Log(debugBuilder.ToString());
        debugBuilders.Return(debugBuilder);

    }

    public IEnumerator GenerateCoroutine(GameObject go, float fuzzy = 0f)
    {

        var debugBuilder = debugBuilders.Get();
        if (DebugGeneration)
        {
            debugBuilder.Length = 0;
            debugBuilder.AppendLine(go.name);
            //var n = go.GetComponent<Named>();
            //if (n != null)
            //    debugBuilder.AppendLine(n.FullName);
        }


        var performedActions = eaPool.Get();
        var maximizeActions = eaListPool.Get();
        maximizeActions.Clear();
        performedActions.Clear();
        bool oneMoreRun = true;
        int iterations = 0;
        while (oneMoreRun)
        {
            yield return null;
            if (DebugGeneration)
                debugBuilder.AppendLine("=================================================================");
            if (Application.isEditor)
                if (iterations++ > 50)
                    break;
            oneMoreRun = false;
            foreach (var categoryPair in eventsByCategory)
            {
                var category = categoryPair.Value;
                if (DebugGeneration)
                    debugBuilder.Append(" ").AppendLine(categoryPair.Key.Name);
                maximizeActions.Clear();
                foreach (var action in category)
                {

                    if (DebugGeneration)
                        debugBuilder.Append("  ").Append(action.GetType().Name).Append(" = ");
                    if (ActedThisWayAndShouldNoMore(go, action) || (action.Meta.OncePerTurn && performedActions.Contains(action)))
                    {
                        debugBuilder.AppendLine("NO");
                        continue;
                    }
                    if (!action.Meta.ShouldHaveMaxUtility)
                    {
                        var cachedRoot = action.Root;
                        action.Root = go;
                        if (action.Filter())
                        {
                            var ut = action.Utility();
                            var useful = ut > 0;
                            oneMoreRun |= useful;
                            if (useful)
                            {
                                if (action.Meta.OncePerTurn)
                                    performedActions.Add(action);
                                action.Action();
                                yield return null;
                                if (DebugGeneration)
                                    debugBuilder.AppendLine(ut.ToString());
                                NotifyOfAct(go, action);
                            }
                            else
                            if (DebugGeneration)
                                debugBuilder.AppendLine("NO");
                        }
                        else
                        if (DebugGeneration)
                            debugBuilder.AppendLine("NO");
                        action.Root = cachedRoot;
                    }
                    else
                    {
                        maximizeActions.Add(action);
                        if (DebugGeneration)
                            debugBuilder.AppendLine("ONLY_MAX");
                    }
                }
                if (DebugGeneration)
                    debugBuilder.Append("  CHOSEN_MAX = ");
                if (maximizeActions.Count > 0)
                {
                    var act = GenerateMostUseful(go, fuzzy, maximizeActions, performedActions);
                    if (DebugGeneration)
                        debugBuilder.AppendLine(act == null ? "NOTHING" : act.GetType().Name);
                    if (act != null)
                    {
                        if (act.Meta.OncePerTurn)
                            performedActions.Add(act);
                        oneMoreRun = true;
                    }
                }
                else if (DebugGeneration)
                    debugBuilder.AppendLine("NOTHING");

            }
            eaListPool.Return(maximizeActions);
            eaPool.Return(performedActions);
        }
        if (DebugGeneration)
            debugBuilder.AppendLine("INTERACTIONS:");
        /*var inter = go.GetComponent<Interactable>();
        if (inter != null)
        {
            GetInteractions(inter);
            if (DebugGeneration)
                foreach (var i in inter.Options)
                    debugBuilder.Append(" ").AppendLine(i.GetType().Name);
        }*/

        if (DebugGeneration)
            Debug.Log(debugBuilder.ToString());
        debugBuilders.Return(debugBuilder);

    }
    ObjectPool<List<EventAction>> listsPool = new ObjectPool<List<EventAction>>();
    public Dictionary<Type, List<EventAction>> FormActionsSet(GameObject go)
    {
        //Debug.Log("Forming actions set", go);
        Dictionary<Type, List<EventAction>> set = new Dictionary<Type, List<EventAction>>();
        foreach ( var cat in actionsByCategory)
        {
            var list = listsPool.Get();
            //Debug.Log(cat.Key.Name);
            foreach (var action in cat.Value)
            {

                //Debug.LogFormat("Check {0} to {1}", action.GetType().Name, go);
                var prevRoot = action.Root;
                action.Root = go;

                if (action.Filter())
                    list.Add(GetAction(action.GetType()));
                action.Root = prevRoot;
            }
            if (list.Count == 0)
                listsPool.Return(list);
            else
                set.Add(cat.Key, list);
        }
        return set;            
    }
    
    public void NotifyOfAct(GameObject go, EventAction action)
    {
        if (action.Meta.OncePerObject || action.Meta.OnceInCategory)
        {

            Markers markers = go.GetComponent<Markers>();
            if (markers == null)
                markers = go.AddComponent<Markers>();
            if (action.Meta.Category == "ui")
                markers.SetUiMarker(action.Meta.OnceInCategory ? action.Meta.Category : action.GetType().Name);
            else
                markers.SetMarker(action.Meta.OnceInCategory ? action.Meta.Category : action.GetType().Name);

        }

    }
    private bool ActedThisWayAndShouldNoMore(GameObject go, EventAction action)
    {
        if (action.Meta.OncePerObject || action.Meta.OnceInCategory)
        {
            Markers markers = go.GetComponent<Markers>();
            if (markers != null)
                return markers.HasMarker(action.Meta.OnceInCategory ? action.Meta.Category : action.GetType().Name);
        }

        return false;
    }

    System.Random random = new System.Random(2);

    public EventAction GenerateMostUseful(GameObject go, float fuzzy = 0f, List<EventAction> customActions = null, HashSet<EventAction> performedActions = null)
    {
        //if (customActions != null)
        //{
        //    Debug.Log("Most useful for " + go);
        //    foreach (var action in customActions)
        //        Debug.Log(action.GetType().Name + " ");
        //}

        if (fuzzy < 0f)
            fuzzy = -fuzzy;
        float maxUt = 0;
        EventAction act = null;
        GameObject maxCachedRoot = null;
        var actions = customActions == null ? this.actions : customActions;
        foreach (var action in actions)
        {
            var cachedRoot = action.Root;
            action.Root = go;
            if (!ActedThisWayAndShouldNoMore(go, action) && !(action.Meta.OncePerTurn && performedActions != null && performedActions.Contains(action)) && action.Filter())
            {
                var baseUt = action.Utility();
                if (baseUt > 0)
                {
                    var ut = baseUt * (1f + fuzzy * ((float)random.NextDouble() - 0.5f) * 2f);
                    //if (customActions != null)
                    //    Debug.LogFormat("Action {0} with ut = {1} is considered", action.GetType().Name, ut);
                    if (ut > maxUt)
                    {
                        maxUt = ut;
                        act = action;
                        maxCachedRoot = cachedRoot;

                    }
                }
                else
                    action.Root = cachedRoot;
            }
            else
                action.Root = cachedRoot;
        }
        if (act != null)
        {
            //Debug.LogFormat("{0} has chosen to do {1} with ut {2}", go, act.GetType().Name, maxUt);
            act.Action();
            act.Root = maxCachedRoot;
            NotifyOfAct(go, act);

        }
        return act;

    }

    ActionWeight[] weights;

    struct ActionWeight
    {
        public EventAction Action;
        public float Weight;
        public GameObject CachedRoot;
    }

    public void ActByWeight(GameObject go, float fuzzy = 0f, List<EventAction> actionsSet = null)
    {
        float cumulativeWeights = 0f;
        int filteredActionsCount = 0;
        List<EventAction> actions = this.actions;
        if (actionsSet != null)
            actions = actionsSet;
        foreach (var action in actions)
        {
            var cachedRoot = action.Root;
            action.Root = go;
            if (!ActedThisWayAndShouldNoMore(go, action) && (actionsSet != null || action.Filter()))
            {
                var baseUt = action.Utility();
                var ut = baseUt * (1f + fuzzy * ((float)random.NextDouble() - 0.5f) * 2f);
                if (baseUt > 0f)
                {
                    weights[filteredActionsCount].CachedRoot = cachedRoot;
                    weights[filteredActionsCount].Action = action;
                    weights[filteredActionsCount].Weight = cumulativeWeights;
                    cumulativeWeights += ut;
                    filteredActionsCount++;
                }
                else
                    action.Root = cachedRoot;

            }
            else
                action.Root = cachedRoot;
        }

        var num = (float)random.NextDouble() * cumulativeWeights;
        EventAction act = null;
        for (int i = 1; i < filteredActionsCount; i++)
        {
            if (weights[i - 1].Weight <= num && weights[i].Weight > num)
                act = weights[i - 1].Action;
        }
        if (act == null && filteredActionsCount > 0)
            act = weights[filteredActionsCount - 1].Action;
        if (act != null)
        {
            act.Action();
            NotifyOfAct(go, act);
        }

        for (int i = 0; i < filteredActionsCount; i++)
        {
            weights[i].Action.Root = weights[i].CachedRoot;
        }

    }

    public List<Dependency> GetDeps(Type eventActionType)
    {
        return eventActionsByType[eventActionType].GetDependencies();
    }
}

