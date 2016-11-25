using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Markers : MonoBehaviour
{
    public List<string> Flags { get { return new List<string>(markers); } set { markers = new HashSet<string>(value); } }

    public HashSet<string> markers = new HashSet<string>();
    HashSet<string> uiMarkers = new HashSet<string>();
    public void ClearUIMarkers()
    {
        uiMarkers.Clear();
    }
    void Awake()
    {

    }

    public bool HasMarker(string marker)
    {
        return markers.Contains(marker) || uiMarkers.Contains(marker);

    }

    public void SetMarker(string marker)
    {
        markers.Add(marker);
    }

    public void SetUiMarker(string marker)
    {
        uiMarkers.Add(marker);
    }

    public void RemoveMarker(string marker)
    {
        markers.Remove(marker);
    }
}
