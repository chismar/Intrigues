using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OnLoadActivator : MonoBehaviour
{
    public List<GameObject> ActivateOnLoad;

    private void Awake()
    {
        FindObjectOfType<BasicLoader>().Loaded += OnLoad;
    }
    bool isActive = false;
    void OnLoad()
    {
        isActive = true;
    }

    private void Update()
    {
        if(isActive)
        {
            foreach (var go in ActivateOnLoad)
            {
                if(go != null)
                    go.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

}
