using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour
{
    [SerializeField]
    bool litUp = false;
    public bool LitUp { get { return litUp; } set { litUp = value; if (litUp) transform.localScale = new Vector3(1, 3, 1); } }
    public float Brightness { get; set; }
}
