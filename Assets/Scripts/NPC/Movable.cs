using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {

    Rigidbody rigidBody;
    [SerializeField]
    float speed;
    public float Speed { get { return speed; } set { speed = Mathf.Clamp(value, 0 , 1000); } }
    public bool IsMoving { get; internal set; }
	public bool NearTarget { get; internal set; }
	[SerializeField]
	Vector3 target;
	[SerializeField]
    Transform targetGo;
	float OKDistance;
    public void GotoPoint(float OKDistance, Vector2 point)
    {
        targetGo = null;
		target = new Vector3(point.x, 0, point.y);
        this.OKDistance = OKDistance;
        IsMoving = true;
        NearTarget = false;

    }

    public void Goto(float OKDistance, GameObject go)
    {
        targetGo = go.transform;
        this.OKDistance = OKDistance;
        IsMoving = true;
        NearTarget = false;
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
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
        var difVector = target - transform.position;
        var distance = difVector.magnitude;
        if (IsMoving = distance > OKDistance)
        {
            var normalVector = difVector / distance;
			Debug.DrawLine (transform.position, transform.position + normalVector);
			rigidBody.velocity = normalVector * Mathf.Min(Speed, distance);
			Debug.DrawLine (transform.position, transform.position + rigidBody.velocity, Color.red);
            NearTarget = false;
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
            NearTarget = true;
        }
    }

	public void Clear(bool yes)
	{
		target = transform.position;
		OKDistance = 1;
	}


}
