using UnityEngine;
using System.Collections;


public class VisualSensor : Sensor
{
    public bool IsVisibleToYou(Vector3 point)
    {
        return true;
    }

    private void Awake()
    {
        FindObjectOfType<VisualsFeed>().AddFeed(this);
    }

    private void OnDestroy()
    {
        var feed = FindObjectOfType<VisualsFeed>();
        if(feed != null)
            feed.RemoveFeed(this);
    }
}
