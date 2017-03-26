using UnityEngine;
using System.Collections;

public class PlayerMarker : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0, 8,3);
    public GameObject Player()
    {
        return gameObject;
    }

    private void Awake()
    {
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "Player"));
        
    }
    private void Update()
    {
        Camera.main.transform.position = transform.position + Offset;
        Camera.main.transform.LookAt(transform);
    }
}
