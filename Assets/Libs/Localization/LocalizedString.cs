using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalizedString
{
    string value;
    Dictionary<string, object> objects;
    public LocalizedString(string value, Dictionary<string, object> objects)
    {
        this.value = value;
        this.objects = objects;
    }

    public string Render(GameObject from)
    {
        return StringRenderer.Instance.Render(from, value, objects);
    }

    public static implicit operator string(LocalizedString str)
    {
        return str.value;
    }


}
