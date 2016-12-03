using UnityEngine;
using System.Collections;

public class GenerationMarker : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(WaitCoroutine());
    }
    
    IEnumerator WaitCoroutine()
    {
        yield return null;
        while (!Actions.Instance.Loaded)
            yield return null;
        yield return Actions.Instance.GenerateCoroutine(gameObject, 0.1f);
        Destroy(this);
    }
}
