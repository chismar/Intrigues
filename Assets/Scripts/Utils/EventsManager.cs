using UnityEngine;
using System.Collections.Generic;
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
    Dictionary<Type, List<PersonalReaction>> allReactions = new Dictionary<Type, List<PersonalReaction>>();

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