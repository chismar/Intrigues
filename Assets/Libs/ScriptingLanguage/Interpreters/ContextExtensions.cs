using UnityEngine;
using System.Collections;
using InternalDSL;
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

}

