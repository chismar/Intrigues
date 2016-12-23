using UnityEngine;
using System.Collections;

public class TurnFollowMouseController : MonoBehaviour
{
    RaycastHit hit;
    private void Update()
    {
        /*if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            transform.LookAt(hit.point, Vector3.back);
            var rotation = transform.rotation.eulerAngles;
            rotation.y = 0;
            rotation.x = 0;
            transform.rotation = Quaternion.Euler(rotation);
        }*/
        transform.rotation = Quaternion.identity;

    }
}
