using System;
using System.CodeDom;
using InternalDSL;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;


public partial class AITasksLoader : ScriptInterpreter
{




	public bool IsPrimitive(Table table)
	{
		return table.Has ("update") || table.Has ("wait");
	}

	public bool IsComplex(Table table)
	{
		return !IsPrimitive (table);

	}



	void GenerateTask(CodeTypeDeclaration type, Table table)
	{
		Category (type, table);
		Scope (type, table);
		Utility (type, table);
		Finished (type, table);
		Terminated (type, table);
		InterruptionType (type, table);
		AtScope (type, table);
		Init (type, table);

	}
	void GeneratePrimitiveTask (string typeName,Table table)
	{
		CodeTypeDeclaration type = null;
		Interaction (type, table);
		GenerateTask (type, table);

		OnStart (type, table);
		OnFinish (type, table);
		OnInterrupt (type, table);
		OnResume (type, table);
		OnTerminate (type, table);
		OnUpdate (type, table);

		Dependencies (type, table);
		Constraints (type, table);
		Animation (type, table);

		Engagement (type, table);

	}

	void GenerateComplexTask (string typeName, Table table)
	{
		CodeTypeDeclaration type = null;
		GenerateTask (type, table);
		Tasks (type, table);
	}


	void Category(CodeTypeDeclaration type, Table table)
	{
		var catOp = table.Get ("category");
		if (catOp == null)
			return;
		var cat = catOp.Context.ToString ().ClearFromBraces ().Trim ();
		CodeMemberMethod catMet = new CodeMemberMethod ();
		catMet.Name = "Category";
		catMet.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		catMet.Statements.Add (new CodeSnippetStatement ("return {0};".Fmt(cat)));
		type.Members.Add (catMet);
	}
	void Interaction(CodeTypeDeclaration type, Table table)
	{
		var interOp = table.Get ("interaction");

		interOp.Scope().Parts.Add("true");
		DeclareVariableStatement retVal = new DeclareVariableStatement();
		retVal.IsReturn = true;
		retVal.Name = "applicable";
		retVal.Type = typeof(bool);
		retVal.InitExpression = "false";
		CreateEventFunction ("OtherFilter", interOp.Context, type, typeof(InteractionTask).GetMethod ("OtherFilter"), retVal);
	}
	void AtScope(CodeTypeDeclaration type, Table table)
	{
		var atOp = table.Get ("at");
		if (atOp == null)
			return;
		var metricName = atOp.Args [0].ToString ().ClearFromBraces ().Trim ();
		var attempts = int.Parse (atOp.Args [1].ToString ().ClearFromBraces ().Trim ());
		DeclareVariableStatement retVal = new DeclareVariableStatement();
		retVal.IsReturn = true;
		retVal.Name = "scope";
		retVal.Type = typeof(List<GameObject>);
		retVal.InitExpression = "null";

		CreateEventFunction ("OtherFilter", atOp.Context, type, typeof(Task).GetMethod ("AtScope"), retVal);
	}



	void Init (CodeTypeDeclaration type, Table table)
	{

		CodeMemberMethod initOverrideMethod = new CodeMemberMethod();
		initOverrideMethod.Name = "Init";
		initOverrideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		type.Members.Add(initOverrideMethod);
		builder.Length = 0;
		builder.Append("base.Init();").AppendLine();
		foreach (var member in type.Members)
		{
			var field = member as CodeMemberField;
			if (field != null)
			{
				builder.Append("this.").Append(field.Name).Append(" = ").Append("default(").Append((field.UserData["type"] as Type).FullName).Append(");").AppendLine();

			}
		}
		initOverrideMethod.Statements.Add(new CodeSnippetStatement(builder.ToString()));
	}

	void InterruptionType (CodeTypeDeclaration type, Table table)
	{
		var iOp = table.Get ("interruption");
		if (iOp == null) {
		}
	}
	void Scope (CodeTypeDeclaration type, Table table)
	{
		var scopeOp = table.Get ("scope");
		if (scopeOp == null) {
			throw new Exception ("No scope in task {0}".Fmt (type.Name));
		}
		try {
			scopeOp.Scope().Parts.Add("true");
			DeclareVariableStatement retVal = new DeclareVariableStatement();
			retVal.IsReturn = true;
			retVal.Name = "applicable";
			retVal.Type = typeof(bool);
			retVal.InitExpression = "false";
			CreateEventFunction("Filter", scopeOp.Context, type, typeof(Task).GetMethod("Filter"), false, retVal);
		}
		catch(Exception e) {
			Debug.LogError ("Scope exception in task {0}: {1}".Fmt (type.Name, e));
			throw e;		
		}
	}

	void Utility (CodeTypeDeclaration type, Table table)
	{
		var utOp = table.Get ("utility");
		if (utOp == null) {
			return;
		}
		try {
			DeclareVariableStatement retVal = new DeclareVariableStatement();
			retVal.IsReturn = true;
			retVal.Name = "ut";
			retVal.Type = typeof(float);
			retVal.InitExpression = "0";
			CreateEventFunction("Utility", utOp.Context, type, typeof(Task).GetMethod("Utility"), false, retVal);
		}
		catch(Exception e) {
			Debug.LogError ("Utility exception in task {0}: {1}".Fmt (type.Name, e));
			throw e;		
		}
	}

	void OnUpdate (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("update");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnUpdate", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnUpdate"), true);
	}

	void Terminated (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("terminated");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("Terminated", upOp.Context, type, typeof(Task).GetMethod("Terminated"), true);
	}

	void Finished (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("finished");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("Finished", upOp.Context, type, typeof(Task).GetMethod("Finished"), true);
	}

	void OnStart (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("start");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnStart", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnStart"), "base.OnStart();");	
	}

	void OnFinish(CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("finish");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnFinish", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnFinish"), "base.OnFinish();");
	}

	void OnTerminate(CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("terminate");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnTerminate", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnTerminate"), "base.OnTerminate();");
	}

	void OnInterrupt (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("interrupt");
		if (upOp == null) {
			return;
		}
		if (upOp.Value () == "terminate") {
			var resumeFunction = new CodeMemberMethod ();
			resumeFunction.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			resumeFunction.Name = "OnResume";
			resumeFunction.Statements.Add (new CodeSnippetStatement ("OnTerminate();"));
			type.Members.Add (resumeFunction);
			return;
		}

		CreateEventFunction("OnInterrupt", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnInterrupt"), "base.OnInterrupt();");
	}

	void OnResume (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("resume");
		if (upOp == null) {
			return;
		}
		if (upOp.Value () == "restart") {
			var resumeFunction = new CodeMemberMethod ();
			resumeFunction.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			resumeFunction.Name = "OnResume";
			resumeFunction.Statements.Add (new CodeSnippetStatement ("OnStart();"));
			type.Members.Add (resumeFunction);

			var afterInterruptFunction = new CodeMemberMethod ();
			afterInterruptFunction.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			afterInterruptFunction.Name = "AfterInerruptState";
			afterInterruptFunction.Statements.Add (new CodeSnippetStatement ("return type.None;"));
			type.Members.Add (afterInterruptFunction);
			return;
		}
		CreateEventFunction("OnResume", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnResume"), "base.OnResume();");
	}



	void Animation (CodeTypeDeclaration type, Table table)
	{
		var catOp = table.Get ("animation");
		if (catOp == null)
			return;
		var cat = catOp.Context.ToString ().ClearFromBraces ().Trim ();
		CodeMemberMethod anMet = new CodeMemberMethod ();
		anMet.Name = "Animation";
		anMet.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		anMet.Statements.Add (new CodeSnippetStatement ("return {0};".Fmt(cat)));
		type.Members.Add (anMet);
	}

	void OtherAnimation (CodeTypeDeclaration type, Table table)
	{
		var catOp = table.Get ("other_animation");
		if (catOp == null)
			return;
		var cat = catOp.Context.ToString ().ClearFromBraces ().Trim ();
		CodeMemberMethod anMet = new CodeMemberMethod ();
		anMet.Name = "OtherAnimation";
		anMet.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		anMet.Statements.Add (new CodeSnippetStatement ("return {0};".Fmt(cat)));
		type.Members.Add (anMet);
	}

	void Constraints (CodeTypeDeclaration type, Table table)
	{

	}

	void Dependencies (CodeTypeDeclaration type, Table table)
	{

	}
	void Engagement(CodeTypeDeclaration type, Table table)
	{

	}
	void Tasks(CodeTypeDeclaration type, Table table)
	{

	}
}

