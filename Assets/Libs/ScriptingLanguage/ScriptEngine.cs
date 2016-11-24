using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.CodeDom.Compiler;
using System.Text;
using System.Linq;

public class ScriptEngine
{
	public bool Working = true;
	public static bool ParseDebug = false;
	public static bool AnalyzeDebug = false;
	public static bool CompileDebug = true;
	List<Type> allTypes = new List<Type> ();

	public IEnumerable<Assembly> Addons { get; internal set; }

	Dictionary<Type, ScriptEnginePlugin> plugins = new Dictionary<Type, ScriptEnginePlugin> ();

	public Dictionary<Type, ScriptEnginePlugin>.ValueCollection Plugins { get { return plugins.Values; } }

	public ScriptEngine ()
	{
		


	}

	public void Init (IEnumerable<Assembly> addons)
	{
		this.Addons = addons;
		foreach (var plugin in Addons)
		{
			var asm = AppDomain.CurrentDomain.Load (plugin.GetName ());
			var pluginTypes = asm.GetTypes ();
			for (int i = 0; i < pluginTypes.Length; i++)
				allTypes.Add (pluginTypes [i]);
		}

		var coreTypes = Assembly.GetExecutingAssembly ().GetTypes ();
		for (int i = 0; i < coreTypes.Length; i++)
			allTypes.Add (coreTypes [i]);

		var enginePlugins = FindTypesCastableTo<ScriptEnginePlugin> ();
		for (int i = 0; i < enginePlugins.Count; i++)
		{
			var pluginInstance = Activator.CreateInstance (enginePlugins [i]) as ScriptEnginePlugin;
			pluginInstance.SetEngine (this);
			plugins.Add (enginePlugins [i], pluginInstance);
		}
	}

	public void InitPlugins ()
	{
		foreach (var pluginPair in plugins)
		{
			pluginPair.Value.Kickstart ();
		}
	}

	public int PluginsCount { get { return plugins.Count; } }

	public T GetPlugin<T> () where T : ScriptEnginePlugin
	{
		ScriptEnginePlugin plugin = null;
		plugins.TryGetValue (typeof(T), out plugin);
		return plugin as T;
	}

	public Type GetType (string name)
	{
		return allTypes.Find (x => x.Name == name);
	}

	public struct TypeAttributePair<T> where T : Attribute
	{
		public Type Type;
		public T Attribute;

		public TypeAttributePair (Type t, T a)
		{
			Type = t;
			Attribute = a;
		}
	}

	public List<TypeAttributePair<T>> FindTypesWithAttribute<T> () where T : Attribute
	{
		Type attrType = typeof(T);
		List<TypeAttributePair<T>> pairs = new List<TypeAttributePair<T>> ();
		for (int i = 0; i < allTypes.Count; i++)
		{
			Type curType = allTypes [i];
			var attrs = curType.GetCustomAttributes (attrType, false);
			if (attrs.Length == 1)
				pairs.Add (new TypeAttributePair<T> (curType, attrs [0] as T));
		}
		return pairs;
	}

	public List<Type> FindTypesCastableTo<T> ()
	{
		Type castTo = typeof(T);
		var types = new List<Type> ();
		for (int i = 0; i < allTypes.Count; i++)
		{
			Type curType = allTypes [i];
//			Debug.LogFormat ("Test {0} {1} {2}", allTypes [i], castTo, castTo.IsAssignableFrom (curType));
			if (castTo.IsAssignableFrom (curType) && curType != castTo && !curType.IsAbstract && !curType.IsGenericType)
				types.Add (curType);
		}
		return types;
	}

	public Type FindType (string name)
	{
		foreach (var type in allTypes)
			if (type.FullName == name)
				return type;
		return null;
	}

	int count = 0;

	public void AddAssembly (Assembly asm)
	{
		//Debug.LogWarning (count++);
		try
		{
			//asm = Assembly.LoadFile (asm.GetName ().Name + ".dll");
			//asm = Assembly.ReflectionOnlyLoad (asm.GetName ().Name);
			//asm = AppDomain.CurrentDomain.Load (asm.GetName ());
		} catch
		{
			
		}
		//var asmName = asm.GetName ().Name;
		//var domainAsm = AppDomain.CurrentDomain.GetAssemblies ().First (a => a.GetName ().Name == asmName);
		var	types = asm.GetTypes ();
		for (int i = 0; i < types.Length; i++)
		{
//			Debug.Log (types [i]);

			allTypes.Add (types [i]);
		}

		var asms = AppDomain.CurrentDomain.GetAssemblies ();
		StringBuilder builder = new StringBuilder ();
		foreach (var a in asms)
			builder.AppendLine (a.GetName ().Name);
		Debug.LogWarning (builder.ToString ());
	}


}

