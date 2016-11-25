using UnityEngine;
using System.Collections;

public class Root<T> : MonoBehaviour where T : Root<T>
{
    static Root<T> instance;
    public static T Instance { get { return instance as T; } }

    public void Awake()
    {
        instance = this;
    }

}
