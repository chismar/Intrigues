﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class EventsManager : Root<EventsManager>
{
    Dictionary<Type, object> pools = new Dictionary<Type, object>();
    public T GetEvent<T>() where T : Event, new()
    {
        var pool = pools[typeof(T)] as ObjectPool<T>;
        var e = pool.Get();
        e.Init();
        e.commonReactions = commonReactions[typeof(T)];
        return e;
    }

    public void FireEvent<T>(T e) where T : Event, new()
    {
        e.Update();
        var pool = pools[typeof(T)] as ObjectPool<T>;
        pool.Return(e);
    }
    
    public void UpdateEvent<T>(T e) where T : Event, new()
    {
        e.Update();
    }

    public void FinishEvent<T>(T e) where T : Event, new()
    {
        var pool = pools[typeof(T)] as ObjectPool<T>;
        pool.Return(e);
    }

    public void AddEventType<T>() where T : Event, new()
    {
        pools.Add(typeof(T), new ObjectPool<T>());
    }

    Dictionary<Type, List<Reaction>> commonReactions = new Dictionary<Type, List<Reaction>>();
    //feed type, event type, reactions
    Dictionary<Type, Dictionary<Type, List<PersonalReaction>>> personalReactions = new Dictionary<Type, Dictionary<Type, List<PersonalReaction>>>();
    private void Awake()
    {
        base.Awake();
        AddEventType<TestEvent>();
        FindObjectOfType<BasicLoader>().Loaded += OnLoad;
    }

    void OnLoad()
    {
        var engine = FindObjectOfType<BasicLoader>().Engine;
        var commonReactionTypes = engine.FindTypesCastableTo<Reaction>();
        var personalReactionTypes = engine.FindTypesCastableTo<PersonalReaction>();

        foreach ( var crType in commonReactionTypes)
        {
            var reaction = Activator.CreateInstance(crType) as Reaction;
            var reactionMeta = crType.GetCustomAttributes(typeof(ReactionAttribute), false)[0] as ReactionAttribute;
            reaction.Meta = reactionMeta;
            var list = commonReactions.Get(reaction.Meta.EventType);
            list.Add(reaction);
        }

        foreach (var prType in personalReactionTypes)
        {
            var reaction = Activator.CreateInstance(prType) as PersonalReaction;
            var reactionMeta = prType.GetCustomAttributes(typeof(ReactionAttribute), false)[0] as ReactionAttribute;
            reaction.Meta = reactionMeta;
            var feedDictionary = personalReactions.Get(reaction.Meta.EventFeed);
            var list = feedDictionary.Get(reaction.Meta.EventType);
            list.Add(reaction);
        }
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(5);
        var utils = FindObjectOfType<ExternalUtilities>();
        var story = FindObjectOfType<Story>();
        while (true)
        {
            var actor = utils.Any(story.AllActors, go => true);
            if(actor != null)
            {
                var e = GetEvent<TestEvent>();
                e.Target = actor;
                FireEvent(e);
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    List<Sensor> cachedSensors = new List<Sensor>();
    public void InitReactions(GameObject go)
    {
        cachedSensors.Clear();
        go.GetComponents<Sensor>(cachedSensors);
        foreach(var sensor in cachedSensors)
        {
            var sensorReactions = personalReactions.TryGet(sensor.GetType());
            if (sensorReactions == null)
                continue;
            foreach(var pair in sensorReactions)
            {
                var sensorList = sensor.allReactions.Get(pair.Key);
                foreach(var reaction in pair.Value)
                {
                    var cachedRoot = reaction.Root;
                    reaction.Root = go;
                    if (reaction.RootFilter())
                        sensorList.Add(reaction);
                    reaction.Root = cachedRoot;
                }
            }
        }
    }
}
public class TestEvent : Event
{
    public GameObject Target { get; set; }
}
public class Event
{
    public GameObject Root;
    public HashSet<object> Reacted = new HashSet<object>();
    //should be in the events manager class
    List<EventsFeedClass> allFeeds = new List<EventsFeedClass>();

    public List<Reaction> commonReactions = null;
    public void Init()
    {
        Reacted.Clear();
    }
    public void Update()
    {
        //Not really EventAction but rather an EventReaction
        //here it should go for each simple reaction to event if it haven't reacted yet
        for ( int i = 0; i < commonReactions.Count; i++)
        {
            var reaction = commonReactions[i];
            if( reaction.Meta.IsRepeatable || !Reacted.Contains(reaction))
            {
                var cachedRoot = reaction.Root;
                reaction.Root = this;
                bool available = reaction.Filter();
                if(available)
                {
                    
                    reaction.Action();
                    Reacted.Add(reaction);
                }
                reaction.Root = cachedRoot;
            }
        }
        
    }
}


public abstract class EventsFeed
{
    public Reaction Reaction { get; set; }
}

public abstract class EventsFeedClass : MonoBehaviour
{ 
    private void Awake()
    {
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this));
    }
    
}

public class VisualsFeed : EventsFeedClass
{

    List<WeakReference> objectsFeeds = new List<WeakReference>();
    public void Push(Event e, Vector3 position)
    {
        for ( int i =0; i < objectsFeeds.Count;i++)
        {
            if(!objectsFeeds[i].IsAlive)
            {
                objectsFeeds.RemoveAt(i);
                i--;
                continue;
            }
            var sensor = objectsFeeds[i].Target as VisualSensor;
            if(sensor.IsVisibleToYou(position))
            {
                var reactions = sensor.GetReactionsTo(e.GetType());
                for ( int j = 0; j < reactions.Count; j++)
                {
                    var reaction = reactions[i];
                    if (reaction.Meta.IsRepeatable || !e.Reacted.Contains(reaction))
                    {
                        var cachedEvent = reaction.Event;
                        reaction.Root = sensor.gameObject;
                        reaction.Event = e;
                        reaction.Action();
                        e.Reacted.Add(reaction);
                        reaction.Event = cachedEvent;
                    }
                }
            }
        }
    }
    public void AddFeed(VisualSensor sensor)
    {
        objectsFeeds.Add(new WeakReference(sensor));
    }

    
}

public class Sensor : MonoBehaviour
{
    public Dictionary<Type, List<PersonalReaction>> allReactions = new Dictionary<Type, List<PersonalReaction>>();

    public List<PersonalReaction> GetReactionsTo(Type eventType)
    {
        List<PersonalReaction> reactions = null;
        allReactions.TryGetValue(eventType, out reactions);
        return reactions;
    }
}

public class VisualSensor : Sensor
{
    public bool IsVisibleToYou(Vector3 point)
    {
        return true;
    }
}

public static class DictionaryExtensions
{
    public static V Get<K,V>(this Dictionary<K,V> dictionary, K key) where V : class, new()
    {
        V value = null;
        if(!dictionary.TryGetValue(key, out value))
        {
            value = new V();
            dictionary.Add(key, value);
        }
        return value;
    }
    public static V TryGet<K, V>(this Dictionary<K, V> dictionary, K key) where V : class
    {
        V value = null;
        dictionary.TryGetValue(key, out value);
        return value;
    }

}