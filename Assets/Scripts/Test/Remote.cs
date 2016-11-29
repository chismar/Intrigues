using UnityEngine;
using System.Collections;

public class Remote : MonoBehaviour
{
    [SerializeField]
    RemoteController controller;
    public GameObject Controller { get { return controller.gameObject; } set { if (controller != null && controller.Controlled == this) controller.Controlled = null;  controller = value.GetComponent<RemoteController>(); controller.Controlled = gameObject; } }
    
}
