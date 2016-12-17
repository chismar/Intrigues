using UnityEngine;
using System.Collections;

public class TurnFollowMouseController : MonoBehaviour
{
    RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            transform.LookAt(hit.point, Vector3.back);
        }

    }
}
