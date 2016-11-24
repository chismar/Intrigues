using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class KeysHolder
{
	static Dictionary<string, Key> keys = new Dictionary<string, Key> ();


	public static Key GetKey (string name)
	{
		Key key = null;
		if (keys.TryGetValue (name, out key))
			return key;
		else
		{
			key = new Key (name);
			keys.Add (name, key);
			return key;
		}
	}
}

public class Key
{
	public string Name { get; internal set; }

	public Key (string name)
	{
		Name = name;
	}

	public override string ToString ()
	{
		return string.Format ("[Key: Name={0}]", Name);
	}
}