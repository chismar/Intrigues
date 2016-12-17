using UnityEngine;
using System.Collections;

public class MovableController : MonoBehaviour
{
    Movable movable;
    private void Awake()
    {
        movable = GetComponent<Movable>();
        if (movable == null)
            Debug.LogError("Movable controller can't find Movable component in " + name);
        Step = movable.Speed * SpeedMultiplier;
        OKDistance = Step / 10;
        
    }
    public float SpeedMultiplier = 0.1f;
    public float Step = 0.30f;
    public float OKDistance = 0.05f;
    public float TimeoutMax = 0.1f;
    public float CurTimeout = 0f;
    private void Update()
    {
        if (movable == null)
            return;
        Vector2 gotoPoint = transform.position;
        bool hasNewPoint = false;
        if(Input.GetKey(KeyCode.W))
        {
            gotoPoint += (Vector2.up * movable.Speed);
            hasNewPoint = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gotoPoint += (Vector2.left * movable.Speed);
            hasNewPoint = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gotoPoint += (Vector2.down * movable.Speed);
            hasNewPoint = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gotoPoint += (Vector2.right * movable.Speed);
            hasNewPoint = true;
        }
        if(hasNewPoint)
        movable.GotoPoint(OKDistance, gotoPoint);
        else
        {
            CurTimeout += Time.deltaTime;
            if(CurTimeout > TimeoutMax)
            {
                CurTimeout = 0;
                movable.GotoPoint(OKDistance, (Vector2)transform.position);
            }
        }

    }
}
