using System.Collections.Generic;
using System.Reflection;
using System.CodeDom.Compiler;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System;
using System.Text;

namespace CSharpCompiler
{
	public class ScriptBundleLoader
	{

		public TextWriter logWriter = Console.Out;

		ISynchronizeInvoke synchronizedInvoke;
		List<ScriptBundle> allFilesBundle = new List<ScriptBundle> ();

		public ScriptBundleLoader (ISynchronizeInvoke synchronizedInvoke)
		{
			this.synchronizedInvoke = synchronizedInvoke;
		}


		public ScriptBundle LoadScriptsBundle (IEnumerable<string> sources, string DLLName)
		{
			var bundle = new ScriptBundle (this, sources, DLLName);
			allFilesBundle.Add (bundle);
			return bundle;
		}

		/// <summary>
		/// Manages a bundle of files which form one assembly, if one file changes entire assembly is recompiled.
		/// </summary>
		public class ScriptBundle
		{
			public Assembly assembly;
			IEnumerable<string> sources;
			ScriptBundleLoader manager;

			string[] assemblyReferences;
			public string DLLName;

			public ScriptBundle (ScriptBundleLoader manager, IEnumerable<string> sources, string dllName)
			{
				DLLName = dllName;
				this.sources = sources;
				this.manager = manager;


				var domain = System.AppDomain.CurrentDomain;
				var asms = domain.GetAssemblies ();
				List<string> locs = new List<string> ();
				foreach (var asm in asms)
				{
					try
					{
						locs.Add (asm.Location);
					} catch
					{
						
						locs.Add (asm.GetName ().Name);
					}
				}
				this.assemblyReferences = locs.ToArray ();

//				manager.logWriter.WriteLine ("loading " + string.Join (", ", sources.ToArray ()));
				CompileFiles ();
			}

			void CompileFiles ()
			{

				var options = new CompilerParameters ();
				options.GenerateExecutable = false;
				options.GenerateInMemory = false;
				options.ReferencedAssemblies.AddRange (assemblyReferences);
				options.CompilerOptions = "/target:library /optimize";
				options.OutputAssembly = DLLName + ".dll";

				//options.
				var compiler = new CodeCompiler ();
				var result = compiler.CompileAssemblyFromSourceBatch (options, sources.ToArray ());

				foreach (var err in result.Errors)
				{
					manager.logWriter.WriteLine (err);
				}

				this.assembly = result.CompiledAssembly;
				var name = this.assembly.GetName ();
			}


		}


	}

}