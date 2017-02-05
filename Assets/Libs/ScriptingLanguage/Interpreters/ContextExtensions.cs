using UnityEngine;
using System.Collections;
using InternalDSL;
using System.Collections.Generic;


public static class ContextExtensions
{ 

	public static bool Has(this Table c, string value)
	{
		return c.Get (value) != null;
	}
	public static Operator Get(this Table c, string value)
	{
		for (int i = 0; i < c.Entries.Count; i++)
			if ((c.Entries [i] as Operator).Identifier as string == value)
				return c.Entries[i] as Operator;
		return null;
	}
	public static List<Operator> AllThat(this Table c, string value)
	{
		var list = new List<Operator> ();
		FunctionCall call;
		for (int i = 0; i < c.Entries.Count; i++)
			if ((c.Entries [i] as Operator).Identifier as string == value ||(
				(call = (c.Entries [i] as Operator).Call ()) != null && call.Name == value))
				list.Add (c.Entries [i] as Operator);
				
		return list;
	}
}

