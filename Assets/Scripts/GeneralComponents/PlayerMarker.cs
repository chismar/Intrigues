using UnityEngine;
using System.Collections;

public class PlayerMarker : MonoBehaviour
{

    public GameObject Player()
    {
        return gameObject;
    }

    private void Awake()
    {
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "Player"));
        Camera.main.transform.SetParent(transform, false);
    }
}
