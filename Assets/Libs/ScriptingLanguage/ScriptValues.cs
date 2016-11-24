using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptValues
{
	public void BlackboardSetInt (IScriptData target, string key, int value)
	{
		var values = target.Blackboard.IntValues;
		if (values.ContainsKey (key))
			values [key] = value;
		else
			values.Add (key, value);
	}

	public int BlackboardGetInt (IScriptData target, string key)
	{
		int value;
		if (target.Blackboard.IntValues.TryGetValue (key, out value))
			return value;
		return int.MinValue;
	}

	public void BlackboardSetFloat (IScriptData target, string key, float value)
	{

		var values = target.Blackboard.FloatValues;
		if (values.ContainsKey (key))
			values [key] = value;
		else
			values.Add (key, value);
	}

	public float BlackboardGetFloat (IScriptData target, string key)
	{
		float value;
		if (target.Blackboard.FloatValues.TryGetValue (key, out value))
			return value;
		return float.NaN;
	}

	public void BlackboardSetString (IScriptData target, string key, string value)
	{
		var values = target.Blackboard.StringValues;
		if (values.ContainsKey (key))
			values [key] = value;
		else
			values.Add (key, value);
	}

	public string BlackboardGetString (IScriptData target, string key)
	{
		string value;
		if (target.Blackboard.StringValues.TryGetValue (key, out value))
			return value;
		return null;
	}




}

public interface IScriptData
{
	ScriptData Blackboard { get; set; }
}

public class ScriptData
{
	Dictionary<string, int> intValues;

	public Dictionary<string, int> IntValues {
		get
		{
			if (intValues == null)
				intValues = new Dictionary<string, int> (2);
			return intValues;
		}
		internal set { intValues = value; }
	}

	Dictionary<string, float> floatValues;

	public Dictionary<string, float> FloatValues {
		get
		{
			if (floatValues == null)
				floatValues = new Dictionary<string, float> (2);
			return floatValues;
		}
		internal set { floatValues = value; }
	}

	Dictionary<string, string> stringValues;

	public Dictionary<string, string> StringValues {
		get
		{
			if (stringValues == null)
				stringValues = new Dictionary<string, string> (2);
			return stringValues;
		}
		internal set{ stringValues = value; }
	}

}