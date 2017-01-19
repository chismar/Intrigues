using UnityEngine;
using System.Collections;
using System.CodeDom;
using System.Collections.Generic;
using InternalDSL;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using System;
using System.Threading;
using System.Text;

public enum TaskState { None, Active, Paused, Failed, Finished }
public abstract class Task
{
	public Penalties Penalties { get;set;}
	public TaskState State {get;set;}
	public GameObject Root { get { return root; } set { root = value; } }
	protected GameObject root;
	public abstract bool Filter();
	public virtual float Utility(){
		return 0.5;
	}

	public virtual void Init () {
		State = TaskState.None;
	}
	public virtual InterruptionType Interruption()
	{
		return InterruptionType.Resumable;
	}

	public virtual bool Finished ()
	{
		return true;
	}

	public virtual bool Terminated ()
	{
		return false;
	}
}
public abstract class ComplexTask : Task
{

	public abstract List<NewCondition> Decomposition ();
	public virtual void Start () {}
	public override InterruptionType Interruption ()
	{
		return InterruptionType.Restartable;
	}
}
public enum InterruptionType { Terminal, Resumable, Restartable }

public abstract class PrimitiveTask : Task
{
	public abstract void OnStart ();
	public abstract void OnTerminate ();
	public abstract void OnFinish ();
	public abstract void OnInterrupt ();
	public abstract void OnResume ();
	public abstract void OnUpdate();
	public virtual List<NewCondition> Dependencies() { return null; }
	public virtual List<Constraint> Constraints() { return null; }

}
public abstract class InteractionTask : PrimitiveTask
{
	public GameObject Other { get { return other; } set { other = value; } }
	protected GameObject other;
	public abstract bool OtherFilter();
	//Используется для авторитарности действия. Если OtherUtility < полезности того, чем занят объект взаимодействия,
	//это значит, что данное взаимодействие сейчас невозможно. 
	//может использоваться, например, для разговора с кем-то. Мол "Я занят", не прерываясь на отдельное действие.
	public virtual float OtherUtility()
	{
		return 1;
	}
}

public partial class AITasksLoader : ScriptInterpreter
{
	List<CodeTypeDeclaration> codeTypes = new List<CodeTypeDeclaration> ();
	FiltersPlugin filters;
	CodeNamespace cNamespace = new CodeNamespace ();
	EventFunctionOperators functionOperators;
	ExpressionInterpreter exprInter;

	public AITasksLoader (string namespaceName, ScriptEngine engine) : base (engine)
	{
		cNamespace.Name = namespaceName;
		exprInter = engine.GetPlugin<ExpressionInterpreter> ();
		filters = engine.GetPlugin<FiltersPlugin> ();
		functionOperators = engine.GetPlugin<EventFunctionOperators> ();
	}
	StringBuilder builder = new StringBuilder();


	public override void Interpret (Script script)
	{
		MaxProgress = script.Entries.Count;
		for (int i = 0; i < script.Entries.Count; i++)
		{
			if (!Engine.Working)
				Thread.CurrentThread.Abort ();
			CurProgress = i;
			var entry = script.Entries [i];
			CodeTypeDeclaration codeType = new CodeTypeDeclaration ();
			//codeType.CustomAttributes.
			codeType.BaseTypes.Add (new CodeTypeReference (typeof(EventAction)));
			codeType.Name = entry.Identifier as string;
			codeTypes.Add (codeType);

			if (ScriptEngine.AnalyzeDebug)
				Debug.LogWarning((entry.Identifier as string).ToUpper());

			var ctx = entry.Context as Context;
			if (ctx == null)
				continue;
			
			try
			{
				Scope (entry, codeType);
				Utility (entry, codeType);
				InterruptionType(entry, codeType);
				Terminated(entry, codeType);
				Finished(entry, codeType);
				if(entry.Has("update") || entry.Has("animation"))
				{
					//this is a primitive task, or an interaction task
					OnUpdate(entry, codeType);
					OnStart(entry, codeType);
					OnFinish(entry, codeType);
					OnTerminate(entry, codeType);
					OnInterrupt(entry, codeType);
					OnResume(entry, codeType);
					Dependencies(entry, codeType);
					Constraints(entry, codeType);
					Animation(entry, codeType);
					//OtherAnimation(entry, codeType);
					//Wait(entry, codeType);

				}
				else
				{
					//Decomposition(entry, codeType);
				}

				Init(codeType);
			}
			catch(Exception e) {
				Debug.Log (e.Message);
			}



		}
		CurProgress = MaxProgress;
		foreach (var type in codeTypes)
		{
			cNamespace.Types.Add (type);
		}

		CSharpCodeProvider provider = new CSharpCodeProvider ();
		CodeGeneratorOptions options = new CodeGeneratorOptions ();
		var writer = new StringWriter ();
		provider.GenerateCodeFromNamespace (cNamespace, writer, options);
		Engine.GetPlugin<ScriptCompiler> ().AddSource (writer.ToString ());

	}


	void CreateEventFunction (string name, object context, CodeTypeDeclaration codeType, MethodInfo baseMethod, params object[] initStatements)
	{
		CodeMemberMethod method = new CodeMemberMethod ();
		method.Name = NameTranslator.CSharpNameFromScript (name);
		method.Attributes = MemberAttributes.Override | MemberAttributes.Public;
		method.ReturnType = new CodeTypeReference (baseMethod.ReturnType);
		var args = baseMethod.GetParameters ();
		FunctionBlock block = new FunctionBlock (null, method, codeType);
		block.Statements.Add ("var root = this.root;");

		//block.Statements.Add ("UnityEngine.Debug.Log(root.ToString() + IfStatement.AntiMergeValue++);");
		var externVar = new DeclareVariableStatement()
		{
			Name = "External",
			IsArg = true,
			Type = Engine.GetType("External")
		};
		block.Statements.Add(externVar);
		block.Statements.Add(new ContextStatement()
			{
				ContextVar = externVar,
				InterpretInContext = Engine.GetPlugin<ExternalFunctionsPlugin>().Ctx.InterpretInContext
			});
		foreach (var initStmt in initStatements)
			block.Statements.Add (initStmt);
		//bool hasRoot = false;
		foreach (var arg in args)
		{
			//if (arg.Name == "root")
			//	hasRoot = true;
			method.Parameters.Add (new CodeParameterDeclarationExpression (arg.ParameterType, arg.Name));
			var paramVar = new DeclareVariableStatement ();
			paramVar.Name = arg.Name;
			paramVar.Type = arg.ParameterType;
			paramVar.IsArg = true;
			block.Statements.Add (paramVar);
		}
		var rootVar = new DeclareVariableStatement ();
		rootVar.Name = "root";
		rootVar.Type = typeof(GameObject);
		rootVar.IsArg = true;
		rootVar.IsContext = true;

		block.Statements.Add (rootVar);


		foreach (var member in codeType.Members)
		{
			var field = member as CodeMemberField;
			if (field != null)
			{
				var cachedVar = new DeclareVariableStatement ();
				cachedVar.Name = field.Name;
				cachedVar.Type = field.UserData ["type"] as Type;
				cachedVar.IsArg = true;

				block.Statements.Add (cachedVar);
			}
		}
		//if (!hasRoot)
		//{
		//	Debug.LogFormat ("Method {0} in {1} has no root arg", baseMethod.Name, codeType.Name);
		//	return;
		//}

		codeType.Members.Add (method);
		var table = context as Context;
		if (table != null)
		{
			foreach (var entry in table.Entries)
			{
				Operator op = entry as Operator;
				var inter = functionOperators.GetInterpreter (op, block);
				if (inter == null)
				{
					Debug.LogFormat ("Can't find interpreter for operator {0} in {1} of {2}", op.Identifier, baseMethod.Name, codeType.Name);
					continue;
				}
				inter.Interpret (op, block);
			}	
			var retVal = block.FindStatement<DeclareVariableStatement> (v => v.IsReturn);
			if (retVal != null)
				block.Statements.Add (String.Format ("return {0};", retVal.Name));
		} else
		{
			var expr = context as Expression;

			var retVal = block.FindStatement<DeclareVariableStatement> (v => v.IsReturn);
			//retVal.IsArg = true;
			block.Statements.Add (String.Format ("return ({1}){0};", exprInter.InterpretExpression (expr, block).ExprString, TypeName.NameOf (retVal.Type)));
		}
		method.Statements.Add (new CodeSnippetStatement (block.ToString ()));


	}

}

