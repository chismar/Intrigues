using System.Collections.Generic;
using UnityEngine;

public class Penalties
{

	Dictionary<System.Type, Penalties> penaltiesByType = new Dictionary<System.Type, Penalties>();
	class Penalty
	{
		public float StartTime { get; set;}
		public float Duration { get;set;}
		public float Value {get;set;}
		public bool Expired { get { return StartTime + Duration < Time.realtimeSinceStartup; } }
	}
	Dictionary<object, Penalty> penalties = new Dictionary<object, Penalty>();
	static List<object> timedOutObjects = new List<object>();
	public bool ClearSelf { get { return penalties.Count == 0 && penaltiesByType.Count == 0; } }
	static ObjectPool<List<System.Type>> clearLists = new ObjectPool<List<System.Type>>();
	public void ClearFromHere()
	{
		Update ();
		Clear ();
	}
	void Clear()
	{

		var clearList = clearLists.Get ();
		clearList.Clear ();

		foreach (var penalties in penaltiesByType) {
			penalties.Value.Clear ();
			if (penalties.Value.ClearSelf)
				clearList.Add (penalties.Key);	
		}
		for (int i = 0; i < clearList.Count; i++)
			penaltiesByType.Remove (clearList [i]);
		clearList.Clear ();
		clearLists.Return (clearList);

	}
	public void Update()
	{
		foreach (var penalties in penaltiesByType)
			penalties.Value.Update ();
		timedOutObjects.Clear ();
		foreach (var penalty in penalties) {
			if (penalty.Value.Expired)
				timedOutObjects.Add (penalty.Key);
		}
		for (int i = 0; i < timedOutObjects.Count; i++) {
			penalties.Remove (timedOutObjects [i]);
		}
		timedOutObjects.Clear ();


	}

	public void SetPenalty(object obj, float duration, float value)
	{
		Penalty p = null;
		if (!penalties.TryGetValue (obj, out p)) {
			p = new Penalty ();
			penalties.Add (obj, p);
		}
		p.StartTime = Time.realtimeSinceStartup;
		p.Duration = duration;
		p.Value = value;
	}

	public void AddPenalty(object obj, float duration, float value)
	{
		Penalty p = null;
		if (!penalties.TryGetValue (obj, out p)) {
			p = new Penalty ();
			penalties.Add (obj, p);
		}
		p.StartTime = Time.realtimeSinceStartup;
		p.Duration = duration;
		p.Value += value;
	}

	public float GetPenalty(object obj)
	{
		var p = penalties.TryGet (obj);
		if (p == null)
			return 0f;
		else if (p.Expired) {
			penalties.Remove (obj);
			return 0f;
		}
		return p.Value;
	}

	public void Init(Behaviour b)
	{
		var type = b.GetType ();
		var p = penaltiesByType.TryGet (type);
		if (p == null) {

			p = new Penalties ();
			penaltiesByType.Add (type, p);
		}
	}
}