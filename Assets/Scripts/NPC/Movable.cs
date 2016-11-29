using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Movable : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float Speed { get; set; }
    public bool IsMoving { get; internal set; }
    public bool NearTarget { get; internal set; }
    Vector3 target;
    Transform targetGo;
    float OKDistance;
    public void GotoPoint(float OKDistance, Vector2 point)
    {
        targetGo = null;
        target = point;
        this.OKDistance = OKDistance;
        IsMoving = true;

    }

    public void Goto(float OKDistance, GameObject go)
    {
        targetGo = go.transform;
        this.OKDistance = OKDistance;
        IsMoving = true;
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = transform.position;
        OKDistance = 1f;
    }
    private void Update()
    {
        if(targetGo != null)
            target = targetGo.position;
        var transform = base.transform;
        var difVector = transform.position - target;
        var distance = difVector.magnitude;
        if(NearTarget = IsMoving = distance > OKDistance)
        {
            var normalVector = difVector / distance;
            rigidBody.AddForce(normalVector * Speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
