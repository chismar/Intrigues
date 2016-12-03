using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour
{
    [SerializeField]
    bool litUp = false;
    public bool LitUp { get { return litUp; } set { litUp = value; if (litUp) transform.localScale = new Vector3(2, 2, 1); else transform.localScale = new Vector3(1, 1, 1); } }
    public float Brightness { get; set; }

    private void Start()
    {
        StartCoroutine(LightsGoOff());
    }

    IEnumerator LightsGoOff()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(4, 7));
            if (LitUp)
                LitUp = false;
        }
    }
}
