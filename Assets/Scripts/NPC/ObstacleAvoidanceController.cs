using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class ObstacleAvoidanceController : MonoBehaviour
{
    ThirdPersonCharacter body;
    Movable mov;
    private void Awake()
    {
        mov = GetComponentInParent<Movable>();
        body = GetComponentInParent<ThirdPersonCharacter>();
    }
    int faloff;
    private void OnTriggerStay(Collider other)
    {
        if (mov.IsMoving)
        {
            if (other.CompareTag("NPC") && other.gameObject != this.transform.parent.gameObject)
            {
                mov.mod = -Vector3.Cross(10 * (other.transform.position - transform.parent.position), Vector3.up);
                faloff = 3;
            }
        }
    }

    private void Update()
    {
        faloff--;
        if(faloff == 0)
            mov.mod = Vector2.zero;
    }
}
