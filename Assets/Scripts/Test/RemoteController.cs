using UnityEngine;
using System.Collections;

public class RemoteController : MonoBehaviour
{
    [SerializeField]
    Remote controlled;
    public GameObject Controlled { get { return controlled.gameObject; } set { if (controlled != null && controlled.Controller == this) controlled.Controller = null; controlled = value.GetComponent<Remote>(); controlled.Controller = gameObject; } }
    
}
