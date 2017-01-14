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

public enum TaskState { None, Impossible, Active, Paused, Waits, Failed, Finished }
public abstract class Task
{
	public TaskState State {get;set;}
	public GameObject Root { get { return root; } set { root = value; } }
	protected GameObject root;
	public abstract bool Filter();
	public virtual float Utility(){
		return 1;
	}

	public virtual void Init () {
	}

}
public abstract class ComplexTask : Task
{
	public abstract void Perform();
}

public abstract class RecurrentTask : Task
{
	public abstract void Do();
	public abstract bool Finished ();
	public abstract bool Terminated ();
	public virtual void Start ();
}
public abstract class PrimitiveTask : Task
{
	public GameObject Root { get { return root; } set { root = value; } }
	protected GameObject root;
	public virtual void OnStart(){ State = TaskState.Active; }
	public virtual void OnTerminate (){ State = TaskState.Failed; }
	public virtual void OnFinish(){ State = TaskState.Finished; }
	public virtual void OnInterrupt(){ State = AfterInterruptState(); }
	public virtual void OnResume(){ State = TaskState.Active; }
	public abstract void Update();
	public virtual List<NewCondition> Dependencies() { return null; }
	public virtual List<Constraint> Constraints() { return null; }

	public virtual TaskState AfterInterruptState()
	{
		return TaskState.Paused;
	}

}

public class AITasksLoader : ScriptInterpreter
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
			var actionMethod = typeof(EventAction).GetMethod ("Action");
			var utMethod = typeof(EventAction).GetMethod ("Utility");
			var scopeMethod = typeof(EventAction).GetMethod ("Filter");
			var interMethod = typeof(EventAction).GetMethod("Interaction");
			CodeAttributeDeclaration attr = new CodeAttributeDeclaration("EventActionAttribute");
			codeType.CustomAttributes.Add(attr);
			CodeAttributeArgument maxArg = new CodeAttributeArgument("ShouldHaveMaxUtility", new CodeSnippetExpression("false"));
			CodeAttributeArgument onceArg = new CodeAttributeArgument("OncePerObject", new CodeSnippetExpression("false"));
			CodeAttributeArgument oncePerTurnArg = new CodeAttributeArgument("OncePerTurn", new CodeSnippetExpression("false"));
			CodeAttributeArgument aiActionArg = new CodeAttributeArgument("IsAIAction", new CodeSnippetExpression("false"));
			CodeAttributeArgument interactionArg = new CodeAttributeArgument("IsInteraction", new CodeSnippetExpression("false"));
			CodeAttributeArgument tooltipArg = new CodeAttributeArgument("Tooltip", new CodeSnippetExpression("\"\""));
			CodeAttributeArgument onceInCategory = new CodeAttributeArgument("OnceInCategory", new CodeSnippetExpression("false"));
			attr.Arguments.Add(maxArg);
			attr.Arguments.Add(onceArg);
			attr.Arguments.Add(oncePerTurnArg);
			attr.Arguments.Add(aiActionArg);
			attr.Arguments.Add(tooltipArg);
			attr.Arguments.Add(onceInCategory);
			attr.Arguments.Add(interactionArg);
			FunctionBlock dependenciesBlock = new FunctionBlock(null, null, codeType);
			List<string> deps = new List<string>();
			for (int j = 0; j < ctx.Entries.Count; j++)
			{
				var op = ctx.Entries [j] as Operator;
				if (op == null)
					continue;
				try
				{
					Scope (op, codeType);
					Utility (op, codeType);
					if(op.Get("update"))
					{
						Update(op, codeType);
						OnStart(op, codeType);
						OnFinish(op, codeType);
						OnTerminate(op, codeType);
						OnInterrupt(op, codeType);
						OnResume(op, codeType);
						Dependencies(op, codeType);
						Constraints(op, codeType);
						Animation(op, codeType);
					}
					else
					{
						Perform(op, codeType);
					}
				
				}
				catch(Exception e) {
					Debug.Log (e.Message);
				}

				if (op.Identifier as string == "tooltip")
				{
					tooltipArg.Value = new CodeSnippetExpression((op.Context as InternalDSL.Expression).Operands[0].ToString());

				}
				else if (op.Identifier as string == "ai_action")
				{
					aiActionArg.Value = new CodeSnippetExpression("true");

				}
				else if (op.Identifier as string == "once_per_category")
				{
					onceInCategory.Value = new CodeSnippetExpression("true");

				}
				else if (op.Identifier as string == "only_max_utility")
				{
					maxArg.Value = new CodeSnippetExpression((op.Context as InternalDSL.Expression).Operands[0].ToString());

				}
				else if (op.Identifier as string == "category")
				{
					var cat = (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts[0].ToString();
					var type = Engine.FindType("ScriptedTypes." + cat);
					if (type == null)
						type = Engine.FindType(NameTranslator.CSharpNameFromScript(cat));
					if (type != null)
					{
						var props = type.GetProperties();
						codeType.BaseTypes.Add(type);

						foreach (var propInfo in props)
						{
							var prop = new CodeMemberProperty();
							prop.HasGet = true;
							prop.HasSet = true;
							prop.Name = propInfo.Name;
							prop.Type = new CodeTypeReference(propInfo.PropertyType);
							var fieldName = NameTranslator.ScriptNameFromCSharp(prop.Name);
							prop.GetStatements.Add(new CodeSnippetStatement(String.Format("return {0}; ", fieldName)));
							prop.SetStatements.Add(new CodeSnippetStatement(String.Format("{0} = value; ", fieldName)));
							prop.PrivateImplementationType = new CodeTypeReference(type);
							if (!codeType.UserData.Contains(fieldName))
							{
								var field = new CodeMemberField();
								field.Name = fieldName;
								field.Type = new CodeTypeReference(propInfo.PropertyType);
								codeType.Members.Add(field);
								codeType.UserData.Add(fieldName, field);
								field.UserData.Add("type", propInfo.PropertyType);
							}
							codeType.Members.Add(prop);
						}
					}
					else
					{

						if (!cNamespace.UserData.Contains(cat))
						{
							CodeTypeDeclaration catInterface = new CodeTypeDeclaration(cat);
							catInterface.IsInterface = true;
							cNamespace.Types.Add(catInterface);
							cNamespace.UserData.Add(cat, catInterface);
						}
						codeType.BaseTypes.Add(cat);
					}
				}
				else if (op.Identifier as string == "once_per_object")
				{
					onceArg.Value = new CodeSnippetExpression("true");
				}
				else if (op.Identifier as string == "once_per_turn")
				{
					oncePerTurnArg.Value = new CodeSnippetExpression("true");
				}
				else if (op.Identifier as string == "interaction")
				{
					//It's a filter function
					//					Debug.Log (op.Context.GetType ());
					if (ScriptEngine.AnalyzeDebug)
						Debug.Log((op.Context as Expression).Operands[0].GetType());

					(((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts.Add("true");
					DeclareVariableStatement retVal = new DeclareVariableStatement();
					retVal.IsReturn = true;
					retVal.Name = "applicable";
					retVal.Type = typeof(bool);
					retVal.InitExpression = "false";

					CreateEventFunction("Interaction", op.Context, codeType, interMethod, false, retVal);
					interactionArg.Value = new CodeSnippetExpression("true");
					//CreateFilterFunction (op.Context as Expression, codeType);

					var type = typeof(EventInteraction);
					var props = type.GetProperties();
					codeType.BaseTypes.Add(type);

					foreach (var propInfo in props)
					{
						var prop = new CodeMemberProperty();
						prop.HasGet = true;
						prop.HasSet = true;
						prop.Name = propInfo.Name;
						prop.Type = new CodeTypeReference(propInfo.PropertyType);
						var fieldName = NameTranslator.ScriptNameFromCSharp(prop.Name);
						prop.GetStatements.Add(new CodeSnippetStatement(String.Format("return {0}; ", fieldName)));
						prop.SetStatements.Add(new CodeSnippetStatement(String.Format("{0} = value; ", fieldName)));
						prop.PrivateImplementationType = new CodeTypeReference(type);
						if (!codeType.UserData.Contains(fieldName))
						{
							var field = new CodeMemberField();
							field.Name = fieldName;
							field.Type = new CodeTypeReference(propInfo.PropertyType);
							codeType.Members.Add(field);
							codeType.UserData.Add(fieldName, field);
							field.UserData.Add("type", propInfo.PropertyType);
						}
						codeType.Members.Add(prop);
					}


				}
				else if (op.Identifier as string == "action")
				{
					//It's an action function
				}
				else if (op.Identifier as string == "depends")
				{
					//Debug.Log(op);
					//Debug.Log(((op.Context as Expression).Operands[0] as ExprAtom).Content.GetType().Name);

				}
				else
				{
					//No idea
				}
			}

			CodeMemberMethod initOverrideMethod = new CodeMemberMethod();
			initOverrideMethod.Name = "Init";
			initOverrideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			codeType.Members.Add(initOverrideMethod);
			builder.Length = 0;
			builder.Append("base.Init();").AppendLine();
			foreach (var member in codeType.Members)
			{
				var field = member as CodeMemberField;
				if (field != null)
				{
					builder.Append("this.").Append(field.Name).Append(" = ").Append("default(").Append((field.UserData["type"] as Type).FullName).Append(");").AppendLine();

				}
			}
			initOverrideMethod.Statements.Add(new CodeSnippetStatement(builder.ToString()));

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


	void Scope(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var scopeOp = taskOp.Get ("scope");
		if (scopeOp == null) {
			throw new Exception ("No scope in task {0}".Fmt (taskType.Name));
		}
		try {
			scopeOp.Scope().Parts.Add("true");
			DeclareVariableStatement retVal = new DeclareVariableStatement();
			retVal.IsReturn = true;
			retVal.Name = "applicable";
			retVal.Type = typeof(bool);
			retVal.InitExpression = "false";
			CreateEventFunction("Filter", scopeOp.Context, taskType, typeof(Task).GetMethod("Filter"), false, retVal);
		}
		catch(Exception e) {
			Debug.LogError ("Scope exception in task {0}: {1}".Fmt (taskType.Name, e));
			throw e;		
		}
	}

	void Utility(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var utOp = taskOp.Get ("utility");
		if (utOp == null) {
			return;
		}
		try {
			DeclareVariableStatement retVal = new DeclareVariableStatement();
			retVal.IsReturn = true;
			retVal.Name = "ut";
			retVal.Type = typeof(float);
			retVal.InitExpression = "0";
			CreateEventFunction("Utility", utOp.Context, taskType, typeof(Task).GetMethod("Utility"), false, retVal);
		}
		catch(Exception e) {
			Debug.LogError ("Utility exception in task {0}: {1}".Fmt (taskType.Name, e));
			throw e;		
		}
	}

	void Perform(Operator taskOp, CodeTypeDeclaration taskType)
	{

		var upOp = taskOp.Get ("perform");
		if (upOp == null) {
			throw new Exception ("No perform in {0}", taskType.Name);
		}

		CreateEventFunction("Perform", upOp.Context, taskType, typeof(ComplexTask).GetMethod("Perform"), true);
	}
	void Update(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("update");
		if (upOp == null) {
			throw new Exception ("No update in {0}", taskType.Name);
		}

		CreateEventFunction("Update", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("Update"), true);
	}


	void OnStart(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("start");
		if (upOp == null) {
			throw new Exception ("No start in {0}", taskType.Name);
		}

		CreateEventFunction("OnStart", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnStart"), "base.OnStart();");	
	}

	void OnFinish(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("finish");
		if (upOp == null) {
			throw new Exception ("No finish in {0}", taskType.Name);
		}

		CreateEventFunction("OnFinish", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnFinish"), "base.OnFinish();");
	}

	void OnTerminate(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("terminate");
		if (upOp == null) {
			throw new Exception ("No terminate in {0}", taskType.Name);
		}

		CreateEventFunction("OnTerminate", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnTerminate"), "base.OnTerminate();");
	}

	void OnInterrupt(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("interrupt");
		if (upOp == null) {
			throw new Exception ("No interrupt in {0}", taskType.Name);
		}
		if (upOp.Value () == "terminate") {
			var resumeFunction = new CodeMemberMethod ();
			resumeFunction.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			resumeFunction.Name = "OnResume";
			resumeFunction.Statements.Add (new CodeSnippetStatement ("OnTerminate();"));
			taskType.Members.Add (resumeFunction);
			return;
		}

		CreateEventFunction("OnInterrupt", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnInterrupt"), "base.OnInterrupt();");
	}

	void OnResume(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("resume");
		if (upOp == null) {
			throw new Exception ("No resume in {0}", taskType.Name);
		}
		if (upOp.Value () == "restart") {
			var resumeFunction = new CodeMemberMethod ();
			resumeFunction.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			resumeFunction.Name = "OnResume";
			resumeFunction.Statements.Add (new CodeSnippetStatement ("OnStart();"));
			taskType.Members.Add (resumeFunction);

			var afterInterruptFunction = new CodeMemberMethod ();
			afterInterruptFunction.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			afterInterruptFunction.Name = "AfterInerruptState";
			afterInterruptFunction.Statements.Add (new CodeSnippetStatement ("return TaskType.None;"));
			taskType.Members.Add (afterInterruptFunction);
			return;
		}
		CreateEventFunction("OnResume", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnResume"), "base.OnResume();");
	}

	void Constraints(Operator taskOp, CodeTypeDeclaration taskType)
	{
		List<object> deps = new List<object> ();
		FunctionBlock dependenciesBlock = new FunctionBlock (null, null, taskType);
		foreach (var op in taskOp.GetAll("depends")) {
			var ctor = op.Call ();
			var type = Engine.FindType(NameTranslator.CSharpNameFromScript(ctor.Name));
			MethodInfo initMethod = type.GetMethod("Init");
			var args = initMethod.GetParameters();
			bool hasInteractable = false;
			bool hasInitiator = false;
			foreach (var param in args)
			{
				if (param.Name == "interactable")
				{
					hasInteractable = true;
				}
				else if (param.Name == "initiator")
				{
					hasInitiator = true;
				}
			}
			builder.Length = 0;
			builder.Append("new ");
			builder.Append(type.FullName);
			builder.Append("().Init");
			builder.Append("(");
			if (hasInteractable)
			{
				builder.Append("this.root");
				builder.Append(",");
			}
			if (hasInitiator)
			{
				builder.Append("this.initiator");
				builder.Append(",");
			}

			foreach ( var funcArg in ctor.Args)
			{
				builder.Append(exprInter.InterpretExpression(funcArg, dependenciesBlock).ExprString);
				builder.Append(",");
			}
			if (builder[builder.Length - 1] == ',')
				builder.Length = builder.Length - 1;
			builder.Append(")");
			deps.Add(builder.ToString());
		}

		if(deps.Count > 0)
		{
			CodeMemberMethod getDepsOverride = new CodeMemberMethod();
			getDepsOverride.ReturnType = new CodeTypeReference(typeof(List<Condition>));
			getDepsOverride.Name = "Constraints";
			getDepsOverride.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			taskType.Members.Add(getDepsOverride);
			string listName = "list" + DeclareVariableStatement.VariableId++;
			string listOp = String.Format("var {0} = new System.Collections.Generic.List<Dependency>({1});", listName, deps.Count);
			dependenciesBlock.Statements.Add(listOp);
			var addToListBlock = new FunctionBlock(dependenciesBlock);
			foreach (var newDep in deps)
			{
				addToListBlock.Statements.Add(String.Format("{0}.Add({1});", listName, newDep));
			}
			dependenciesBlock.Statements.Add(addToListBlock);
			dependenciesBlock.Statements.Add(String.Format("return {0};", listName));
			getDepsOverride.Statements.Add(new CodeSnippetStatement(dependenciesBlock.ToString()));

		}
	}

	void Dependencies(Operator taskOp, CodeTypeDeclaration taskType)
	{
		List<object> deps = new List<object> ();
		FunctionBlock dependenciesBlock = new FunctionBlock (null, null, taskType);
		foreach (var op in taskOp.GetAll("depends")) {
			var ctor = op.Call ();
			var type = Engine.FindType(NameTranslator.CSharpNameFromScript(ctor.Name));
			MethodInfo initMethod = type.GetMethod("Init");
			var args = initMethod.GetParameters();
			bool hasInteractable = false;
			bool hasInitiator = false;
			foreach (var param in args)
			{
				if (param.Name == "interactable")
				{
					hasInteractable = true;
				}
				else if (param.Name == "initiator")
				{
					hasInitiator = true;
				}
			}
			builder.Length = 0;
			builder.Append("new ");
			builder.Append(type.FullName);
			builder.Append("().Init");
			builder.Append("(");
			if (hasInteractable)
			{
				builder.Append("this.root");
				builder.Append(",");
			}
			if (hasInitiator)
			{
				builder.Append("this.initiator");
				builder.Append(",");
			}

			foreach ( var funcArg in ctor.Args)
			{
				builder.Append(exprInter.InterpretExpression(funcArg, dependenciesBlock).ExprString);
				builder.Append(",");
			}
			if (builder[builder.Length - 1] == ',')
				builder.Length = builder.Length - 1;
			builder.Append(")");
			deps.Add(builder.ToString());
		}

		if(deps.Count > 0)
		{
			CodeMemberMethod getDepsOverride = new CodeMemberMethod();
			getDepsOverride.ReturnType = new CodeTypeReference(typeof(List<Condition>));
			getDepsOverride.Name = "Dependencies";
			getDepsOverride.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			taskType.Members.Add(getDepsOverride);
			string listName = "list" + DeclareVariableStatement.VariableId++;
			string listOp = String.Format("var {0} = new System.Collections.Generic.List<Dependency>({1});", listName, deps.Count);
			dependenciesBlock.Statements.Add(listOp);
			var addToListBlock = new FunctionBlock(dependenciesBlock);
			foreach (var newDep in deps)
			{
				addToListBlock.Statements.Add(String.Format("{0}.Add({1});", listName, newDep));
			}
			dependenciesBlock.Statements.Add(addToListBlock);
			dependenciesBlock.Statements.Add(String.Format("return {0};", listName));
			getDepsOverride.Statements.Add(new CodeSnippetStatement(dependenciesBlock.ToString()));

		}
	}

	void Animation(Operator taskOp, CodeTypeDeclaration taskType)
	{
	}

}


public static class OperatorExtensions
{
	public static Operator Get(this Operator op, string id)
	{
		var ctx = op.Context as Context;
		if (ctx == null)
			return null;
		for (int j = 0; j < ctx.Entries.Count; j++)
		{
			var subOp = ctx.Entries [j] as Operator;
			if (subOp.Identifier as string == id)
				return subOp;
		}
		return null;
	}

	public static List<Operator> GetAll(this Operator op, string id)
	{
		var ctx = op.Context as Context;
		if (ctx == null)
			return null;
		List<Operator> ops = new List<Operator> ();
		for (int j = 0; j < ctx.Entries.Count; j++)
		{
			var subOp = ctx.Entries [j] as Operator;
			if (subOp.Identifier as string == id)
				ops.Add(subOp);
		}
		return ops;
	}

	public static string Value(this Operator op)
	{
		var expr = op.Context as Expression;
		if (expr == null)
			return null;
		return expr.ToString ().ClearFromBraces ().Trim ();
	}

	public static string GetValue(this Operator op, string id)
	{
		var subOp = op.Get (id);
		if (subOp == null)
			return null;
		else
			return subOp.Value ();
	}
	public static ExprAtom Atom(this Operator op)
	{
		var expr = op.Context as Expression;
		if (expr == null)
			return null;
		if (expr.Operands.Length == 0)
			return null;
		var atom = expr.Operands [0] as ExprAtom;
		return atom;
	}
	public static Scope Scope(this Operator op)
	{
		var atom = op.Atom ();
		if (atom == null)
			return null;
		return atom.Content as Scope;
	}

	public static FunctionCall Call(this Operator op)
	{
		var scope = op.Scope ();
		if (scope == null)
			return null;
		if (scope.Parts.Count == 0)
			return null;
		var ctor = scope.Parts[0] as FunctionCall;
	}
}