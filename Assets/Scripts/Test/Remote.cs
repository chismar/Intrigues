using UnityEngine;
using System.Collections;

public class Remote : MonoBehaviour
{
    [SerializeField]
    RemoteController controller;
    public RemoteController Controller { get { return controller; } set { if (controller != null && controller.Controlled == this) controller.Controlled = null;  controller = value; controller.Controlled = this; } }
    
}
