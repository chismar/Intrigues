using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;




namespace CSharpCompiler
{

	public class ScriptsLoader : MonoBehaviour
	{

		DeferredSynchronizeInvoke synchronizedInvoke;
		CSharpCompiler.ScriptBundleLoader loader;

		void Awake ()
		{
			synchronizedInvoke = new DeferredSynchronizeInvoke ();

			loader = new CSharpCompiler.ScriptBundleLoader (synchronizedInvoke);

			loader.logWriter = new UnityLogTextWriter ();
		}


		public Assembly Load (string[] sources, string asmName)
		{
			var bundle = loader.LoadScriptsBundle (sources, asmName);
			return bundle.assembly;
		

		}



	}
}

