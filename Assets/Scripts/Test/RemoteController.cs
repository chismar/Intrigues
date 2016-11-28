using UnityEngine;
using System.Collections;

public class RemoteController : MonoBehaviour
{
    [SerializeField]
    Remote controlled;
    public Remote Controlled { get { return controlled; } set { if (controlled != null && controlled.Controller == this) controlled.Controller = null; controlled = value; controlled.Controller = this; } }
    
}
