using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using CSharpCompiler;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Threading;

public class ExternalFunctionsPlugin : ScriptEnginePlugin
{
	ScriptsLoader loader;

	public void Load ()
	{
		loader = UnityEngine.Object.FindObjectOfType<ScriptsLoader> ();
	}

	class ProviderData
	{
		public object Instance;
		public string[] Members;
		public string Name;
	}

	List<ProviderData> providers = new List<ProviderData> ();

	int memberID = 0;

	public void AddProvider (object provider, params string[] members)
	{

		providers.Add (new ProviderData () {
			Instance = provider,
			Members = members,
			Name = provider.GetType ().Name + memberID
		});
	}

	StringBuilder builder = new StringBuilder ();
	Action onCompiled;

	public void Setup (Action onCompiled)
	{
		this.onCompiled = onCompiled;
		CodeTypeDeclaration decl = new CodeTypeDeclaration ("External");
		CodeMemberMethod init = new CodeMemberMethod ();
		init.Attributes = MemberAttributes.Public | MemberAttributes.Static;
		init.Name = "Init";
		init.Statements.Add (new CodeSnippetStatement ("UnityEngine.Debug.LogWarning(\"External functions class initialization\");"));
		decl.Members.Add (init);
		decl.Members.Add (new CodeSnippetTypeMember ("static External(){UnityEngine.Debug.LogWarning(\"CTOR\" + BasicLoader0);}"));
//		CodeConstructor ctor = new CodeConstructor ();
//		ctor.Attributes = MemberAttributes.Static;
//		ctor.Statements.Add (new CodeSnippetStatement (""));
//		decl.Members.Add (ctor);
		decl.Attributes = MemberAttributes.Public | MemberAttributes.Static;
		MaxProgress = (from p in providers
		               select p.Members.Length).Sum ();
		foreach (var provider in providers)
		{
			if (!Engine.Working)
				Thread.CurrentThread.Abort ();
			var providerType = provider.Instance.GetType ();
			var providerName = provider.Name;
			var field = new CodeMemberField (providerType, providerName);
			field.Attributes = MemberAttributes.Private | MemberAttributes.Static;
			decl.Members.Add (field);
			foreach (var member in provider.Members)
			{
				CurProgress++;
				var methodInfo = providerType.GetMethod (member, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
				if (methodInfo != null)
				{
					CodeMemberMethod method = new CodeMemberMethod ();
					method.Name = member;
					method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
					method.ReturnType = new CodeTypeReference (methodInfo.ReturnType);
					var args = methodInfo.GetParameters ();
					builder.Length = 0;
					if (methodInfo.ReturnType != null && methodInfo.ReturnType != typeof(void))
						builder.Append ("return ");
                    if(methodInfo.IsStatic)
                    {
                        builder.Append(methodInfo.DeclaringType).Append('.');
                        provider.Instance = null;
                    }
                    else
                        builder.Append(providerName).Append('.');
                    builder.Append(member).Append('(');
                    foreach (var arg in args)
					{
						builder.Append (arg.Name).Append (',');
						method.Parameters.Add (new CodeParameterDeclarationExpression (arg.ParameterType, arg.Name));
					}
					if (args.Length > 0)
						builder.Length -= 1;
					builder.Append (");");
					method.Statements.Add (new CodeSnippetStatement (builder.ToString ()));
					decl.Members.Add (method);
				} else
				{
					var propInfo = providerType.GetProperty (member);
					if (propInfo != null)
					{
						CodeMemberProperty prop = new CodeMemberProperty ();
						prop.Attributes = MemberAttributes.Public | MemberAttributes.Static;
						prop.Name = member;
						prop.Type = new CodeTypeReference (propInfo.PropertyType);
						prop.GetStatements.Add (new CodeSnippetStatement (String.Format ("return {0}.{1};", providerName, member)));
                        if(propInfo.CanWrite && propInfo.GetSetMethod() != null && propInfo.GetSetMethod().IsPublic)
                        prop.SetStatements.Add(new CodeSnippetStatement(String.Format(" {0}.{1} = value;", providerName, member)));
                        decl.Members.Add (prop);
					} else
					{
						Debug.LogFormat ("No such member {0} in {1}", member, providerType);
					}

				}
			}
		}
		CurProgress = MaxProgress;
		CSharpCodeProvider codeProvider = new CSharpCodeProvider ();
		CodeGeneratorOptions options = new CodeGeneratorOptions ();
		var writer = new StringWriter ();
		codeProvider.GenerateCodeFromType (decl, writer, options);
		Debug.Log (writer.ToString ());
		OnCompiled (loader.Load (new string[]{ writer.ToString () }, "ExternalCode"));
		//onCompiled ();
	}

	public ContextSwitchInterpreter Ctx { get; internal set; }

	public void OnCompiled (Assembly asm)
	{
		//AppDomain.CurrentDomain.Load (asm.GetName ());
		//asm.GetName ().SetPublicKeyToken (new byte[]{ 12, 13, 48, 2 });

		Debug.LogWarning (asm.FullName);
		Engine.AddAssembly (asm);

		//asm.GetName().
		var type = Engine.GetType ("External");
		type.GetMethod ("Init").Invoke (null, null);
		foreach (var provider in providers)
		{
			Debug.LogWarning (provider.Name);
			//Debug.LogWarning (provider.Instance);
                type.GetField(provider.Name, BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, provider.Instance);
            
			//Debug.LogWarning (type.GetField (provider.Name, BindingFlags.NonPublic | BindingFlags.Static).GetValue (null));
		}

		Ctx = new ContextSwitchInterpreter (type, Engine);
		if (onCompiled != null)
			onCompiled ();
	}

}

