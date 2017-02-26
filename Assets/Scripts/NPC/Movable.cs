using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Movable : MonoBehaviour {

    ThirdPersonCharacter body;
    [SerializeField]
    float speed;
    public float Speed { get { return speed; } set { speed = Mathf.Clamp(value, 0 , 1000); } }
    public bool IsMoving { get; internal set; }
	public bool NearTarget { get; internal set; }
	[SerializeField]
	Vector3 target;
    public Vector3 mod;
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
        body = GetComponent<ThirdPersonCharacter>();
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

            var finTarget = target + mod;
            difVector = finTarget - transform.position;
            distance = difVector.magnitude;
            var normalVector = difVector / distance;
			Debug.DrawLine (transform.position, transform.position + normalVector);
			body.Move(normalVector * Mathf.Min(Speed, distance), false, false);
			Debug.DrawLine (transform.position, transform.position + normalVector * Mathf.Min(Speed, distance), Color.red);
            NearTarget = false;
        }
        else
        {
            body.Move(Vector3.zero, false, false);
            NearTarget = true;
        }
    }

	public void Clear(bool yes)
	{
		target = transform.position;
		OKDistance = 1;
	}


}
