using System;
using System.CodeDom;
using InternalDSL;
using UnityEngine;
public partial class AITasksLoader : ScriptInterpreter
{

	void Init(CodeTypeDeclaration taskType)
	{

		CodeMemberMethod initOverrideMethod = new CodeMemberMethod();
		initOverrideMethod.Name = "Init";
		initOverrideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		taskType.Members.Add(initOverrideMethod);
		builder.Length = 0;
		builder.Append("base.Init();").AppendLine();
		foreach (var member in taskType.Members)
		{
			var field = member as CodeMemberField;
			if (field != null)
			{
				builder.Append("this.").Append(field.Name).Append(" = ").Append("default(").Append((field.UserData["type"] as Type).FullName).Append(");").AppendLine();

			}
		}
		initOverrideMethod.Statements.Add(new CodeSnippetStatement(builder.ToString()));
	}

	void InterruptionType(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var iOp = taskOp.Get ("interruption");
		if (iOp == null) {
		}
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

	void OnUpdate(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("update");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnUpdate", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnUpdate"), true);
	}

	void Terminated(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("terminated");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("Terminated", upOp.Context, taskType, typeof(Task).GetMethod("Terminated"), true);
	}

	void Finished(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("finished");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("Finished", upOp.Context, taskType, typeof(Task).GetMethod("Finished"), true);
	}

	void OnStart(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("start");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnStart", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnStart"), "base.OnStart();");	
	}

	void OnFinish(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("finish");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnFinish", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnFinish"), "base.OnFinish();");
	}

	void OnTerminate(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("terminate");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnTerminate", upOp.Context, taskType, typeof(PrimitiveTask).GetMethod("OnTerminate"), "base.OnTerminate();");
	}

	void OnInterrupt(Operator taskOp, CodeTypeDeclaration taskType)
	{
		var upOp = taskOp.Get ("interrupt");
		if (upOp == null) {
			return;
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
			return;
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

