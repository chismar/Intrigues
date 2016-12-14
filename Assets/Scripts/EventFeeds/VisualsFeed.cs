using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class VisualsFeed : EventsFeedClass
{

    List<VisualSensor> objectsFeeds = new List<VisualSensor>();
    public void Push(Event e, Vector3 position)
    {
        for (int i = 0; i < objectsFeeds.Count; i++)
        {
            var sensor = objectsFeeds[i];
            if (sensor.IsVisibleToYou(position))
            {
                Debug.Log("SENSOR NOTICED EVENT: " + sensor);
                var reactions = sensor.GetReactionsTo(e.GetType());
                if (reactions == null)
                    continue;
                e.PersonalReacted.Clear();
                for (int j = 0; j < reactions.Count; j++)
                {
                    var reaction = reactions[j];
                    if (reaction.Meta.IsRepeatable || !e.PersonalReacted.Contains(reaction))
                    {
                        
                        var cachedEvent = reaction.Event;
                        var cachedRoot = reaction.Root;
                        reaction.Root = sensor.gameObject;
                        reaction.Event = e;
                        if (reaction.EventFilter())
                        {
                            reaction.Action();
                            e.PersonalReacted.Add(reaction);
                        }
                        reaction.Root = cachedRoot;
                        reaction.Event = cachedEvent;
                    }
                }
            }
        }
    }
    public void AddFeed(VisualSensor sensor)
    {
        objectsFeeds.Add(sensor);
    }

    public void RemoveFeed(VisualSensor sensor)
    {
        objectsFeeds.Remove(sensor);
    }

    private void Awake()
    {
        base.Awake();
    }

}
