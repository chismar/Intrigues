using UnityEngine;
using System.Collections;
using System;

public class MovableController : MonoBehaviour
{
    private void Awake()
    {
        agent = GetComponent<Agent>();
        OKDistance = Speed / 10;
        moveTask = BehaviourTask.New<MovePlayerTask>(gameObject, OnTaskInterruption, "walking");
        if (!moveTask.Filter())
        {
            Debug.LogError("Movable controller can't do MovePlayerTask component in " + name);
            Destroy(this);
        }
        moveTask.ProvidedUtility = 0.4f;
        moveTask.OKDistance = OKDistance;
        moveTask.TimeoutMax = TimeoutMax;
        moveTask.CurTimeout = CurTimeout;
        moveTask.Speed = Speed;
        
    }
    public float Speed = 1f;
    public float OKDistance = 0.05f;
    public float TimeoutMax = 0.1f;
    public float CurTimeout = 0f;
    Agent agent;
    public bool isInCharge = false;
    void OnTaskInterruption()
    {
        isInCharge = false;
        Debug.Log("stop doing");
    }
    MovePlayerTask moveTask;
    private void Update()
    {
        if(!isInCharge)
        if(moveTask.ShouldBeInCharge() || agent.CurrentUtility() == 0f)
        {

            if(agent.CurrentUtility() < moveTask.Utility())
            {
                agent.Do(moveTask);
                isInCharge = true;
            }
        }

    }
}


public class MovePlayerTask : BehaviourTask
{
    Movable movable;
    public float OKDistance;
    public float CurTimeout;
    public float TimeoutMax;
    public float Speed;
    public override string Animation { get { return "walk";  }  }
    public override bool Filter()
    {
        return base.Filter() && Root.GetComponent<Movable>() != null;
    }
    public override void OnStart()
    {
        movable = Root.GetComponent<Movable>();
        movable.Clear();
    }

    public bool ShouldBeInCharge()
    {
        
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }
    public override void OnUpdate()
    {
        //Debug.Log("updated move player task");
        Vector3 gotoPoint = Root.transform.position;
        bool hasNewPoint = false;
        movable.Speed = Speed;
        if (Input.GetKey(KeyCode.W))
        {
            gotoPoint += (-Vector3.forward * movable.Speed);
            hasNewPoint = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gotoPoint += (Vector3.right * movable.Speed);
            hasNewPoint = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gotoPoint += (Vector3.forward * movable.Speed);
            hasNewPoint = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gotoPoint += (-Vector3.right * movable.Speed);
            hasNewPoint = true;
        }
        if (hasNewPoint)
        {
            CurTimeout = 0;
            movable.GotoPoint(OKDistance, new Vector2(gotoPoint.x, gotoPoint.z));
        }
        else
        {
            CurTimeout += Time.deltaTime;
            if (CurTimeout > TimeoutMax)
            {
                CurTimeout = 0;
                var pos = Root.transform.position;
                movable.GotoPoint(OKDistance, new Vector2(pos.x, pos.z));
            }
        }
    }
}
