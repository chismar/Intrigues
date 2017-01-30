using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.IO;
using System.Linq;

public class ObjectsLoader<T> where T : ScriptableObject
{

	Type dataType = typeof(T);
	string dir;

	delegate void LoadFromNodeContentDelegate (ScriptableObject data, object content);

	Dictionary<string, LoadFromNodeContentDelegate> properties = new Dictionary<string, LoadFromNodeContentDelegate> ();

	Dictionary<string, T> loadedObjects = new Dictionary<string, T> ();

	struct Weight
	{
		public T Obj;
		public float Value;
	}

	T[] loadedObjectsArray;
	Weight[] weightedArray;

	public void Init (Type dataType, string dir)
	{
		this.dir = dir;
		this.dataType = dataType;
		var props = dataType.GetProperties ();
		foreach (var prop in props)
		{
			
			var dataArg = Expression.Parameter (typeof(T), "data");
			var contentArg = Expression.Parameter (typeof(object), "content");
			var conDataArg = Expression.Convert (dataArg, dataType);
			var conContentArg = Expression.Convert (contentArg, prop.PropertyType);
			var assignProp = Expression.Call (conDataArg, prop.GetSetMethod (), conContentArg);
			var lambda = Expression.Lambda<LoadFromNodeContentDelegate> (assignProp, dataArg, contentArg);
			var call = lambda.Compile ();
			properties.Add (NameTranslator.ScriptNameFromCSharp (prop.Name), call);
		}
	}

	public void Load ()
	{
		var files = Directory.GetFiles ((Application.isEditor ? "Assets/" : BasicLoader.ProjectPrefix + "_Data/") + "StreamingAssets/Mods/" + dir);
		Script dataScript = new Script ("data");
		foreach (var file in files)
		{
			dataScript.LoadFile (file);
		}

		loadedObjectsArray = new T[dataScript.Entries.Count];
		weightedArray = new Weight[dataScript.Entries.Count];
		int arrayIndex = 0;
		if (properties.Count == 1)
		{

			var propCall = properties.First ().Value;
			foreach (var entry in dataScript.Entries)
			{
				var dataObject = (T)ScriptableObject.CreateInstance (dataType);
				var content = (((entry.Context as InternalDSL.Expression).Operands [0] as InternalDSL.ExprAtom).Content as InternalDSL.Scope).Parts [0];
				propCall (dataObject, content);
				loadedObjects.Add (entry.Identifier as string, dataObject);
				loadedObjectsArray [arrayIndex++] = dataObject;
			}

		} else
			foreach (var entry in dataScript.Entries)
			{
				var dataObject = (T)ScriptableObject.CreateInstance (dataType);
				var table = entry.Context as InternalDSL.Table;
				foreach (var fieldEntry in table.Entries)
				{
					var field = fieldEntry as InternalDSL.Operator;
					var propCall = properties [field.Identifier as string];
					var content = (((field.Context as InternalDSL.Expression).Operands [0] as InternalDSL.ExprAtom).Content as InternalDSL.Scope).Parts [0];
					propCall (dataObject, content);
				}
				loadedObjectsArray [arrayIndex++] = dataObject;
				loadedObjects.Add (entry.Identifier as string, dataObject);
			}
	}

	public T GetObject (string name)
	{
		T obj = null;
		loadedObjects.TryGetValue (name, out obj);
		return obj;
	}

	System.Random random = new System.Random ();

	public ScriptableObject GetRandom ()
	{
		return loadedObjectsArray [random.Next (0, loadedObjectsArray.Length)];
	}

	public T GetRandomByWeight (Func<T, float> weight)
	{
		T obj = null;
		int objCount = 0;
		for (int i = 0; i < loadedObjectsArray.Length; i++)
		{
			float w = weight (loadedObjectsArray [i]);
			if (w > 0)
			{
				weightedArray [objCount].Obj = loadedObjectsArray [i];
				weightedArray [objCount].Value = w;
				objCount++;
			}
		}
		var num = (float)random.NextDouble ();
		for (int i = 1; i < objCount; i++)
		{
			if (weightedArray [i - 1].Value <= num && weightedArray [i].Value > num)
			{
				obj = weightedArray [i - 1].Obj;
				break;
			}
		}
		if (obj == null && objCount > 0)
			obj = weightedArray [objCount - 1].Obj;
		return obj;
	}

	public T GetMostWeighted (Func<T, float> weight)
	{
		T maxObj = null;
		float maxWeight = float.MinValue;
		for (int i = 0; i < loadedObjectsArray.Length; i++)
		{
			float w = weight (loadedObjectsArray [i]);
			if (w > maxWeight)
			{
				maxWeight = w;
				maxObj = loadedObjectsArray [i];
			}
		}
		return maxObj;
	}




}

