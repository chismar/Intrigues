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
		InterruptionType (type, table);
		AtScope (type, table);

	}
	CodeTypeDeclaration GeneratePrimitiveTask (string typeName,Table table)
	{
		CodeTypeDeclaration type = new CodeTypeDeclaration ();
		type.Name = typeName;
		var baseType = new CodeTypeReference (typeof(PrimitiveTask));
		type.BaseTypes.Add (baseType);
		Interaction (type, table, baseType);
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
		Finished (type, table);
		Terminated (type, table);
		return type;

	}

	CodeTypeDeclaration GenerateComplexTask (string typeName, Table table)
	{
		CodeTypeDeclaration type = new CodeTypeDeclaration ();
		type.Name = typeName;
		type.BaseTypes.Add (new CodeTypeReference (typeof(ComplexTask)));
		GenerateTask (type, table);
		Tasks (type, table);
		Finished (type, table);
		Terminated (type, table);
		return type;
	}


	void Category(CodeTypeDeclaration type, Table table)
	{
		var catOp = table.Get ("category");
		if (catOp == null)
			return;
		var cat = catOp.Context.ToString ().ClearFromBraces ().Trim ();
		type.OverridePropConst (typeof(Task), "Category", "\"{0}\"".Fmt(cat));
		//TODO - interface

		type.AddCategoryInterface(cat, Engine, cNamespace);
		type.UserData.Add ("category", cat);
	}
	void Interaction(CodeTypeDeclaration type, Table table, CodeTypeReference baseType)
	{
		var interOp = table.Get ("interaction");
		if (interOp == null)
			return;
		interOp.Scope().Parts.Add("true");
		type.BaseTypes.Remove (baseType);
		type.UserData.Add ("is_interaction", true);
		type.BaseTypes.Add (new CodeTypeReference (typeof(InteractionTask)));
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





	void InterruptionType (CodeTypeDeclaration type, Table table)
	{
		var iOp = table.Get ("interruption");
		if (iOp == null) {
			return;
		}
		var val = iOp.Value ();
		if (val == "restart")
			type.OverridePropConst (typeof(Task), "Interruption", "InterruptionType.Restartable");
		else if (val == "terminate")
			type.OverridePropConst (typeof(Task), "Interruption", "InterruptionType.Terminal");
			
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
			CreateEventFunction("Filter", scopeOp.Context, type, typeof(Task).GetMethod("Filter"), retVal);
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
			CreateEventFunction("Utility", utOp.Context, type, typeof(Task).GetMethod("Utility"), retVal);
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

		CreateEventFunction("OnUpdate", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnUpdate"));
	}

	void Terminated (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("terminated");
		if (upOp == null) {
			return;
		}

		DeclareVariableStatement retVal = new DeclareVariableStatement();
		retVal.IsReturn = true;
		retVal.Name = "should";
		retVal.Type = typeof(bool);
		retVal.InitExpression = "false";
		CreateEventFunction("Terminated", upOp.Context, type, typeof(Task).GetMethod("Terminated"), retVal);
	}

	void Finished (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("finished");
		if (upOp == null) {
			return;
		}

		DeclareVariableStatement retVal = new DeclareVariableStatement();
		retVal.IsReturn = true;
		retVal.Name = "should";
		retVal.Type = typeof(bool);
		retVal.InitExpression = "false";
		CreateEventFunction("Finished", upOp.Context, type, typeof(Task).GetMethod("Finished"), retVal);
	}

	void OnStart (CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("start");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnStart", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnStart"));	
	}

	void OnFinish(CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("finish");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnFinish", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnFinish"));
	}

	void OnTerminate(CodeTypeDeclaration type, Table table)
	{
		var upOp = table.Get ("terminate");
		if (upOp == null) {
			return;
		}

		CreateEventFunction("OnTerminate", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnTerminate"));
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

		CreateEventFunction("OnInterrupt", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnInterrupt"));
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
		CreateEventFunction("OnResume", upOp.Context, type, typeof(PrimitiveTask).GetMethod("OnResume"));
	}



	void Animation (CodeTypeDeclaration type, Table table)
	{
		var catOp = table.Get ("animation");
		if (catOp == null)
			return;
		var cat = catOp.Context.ToString ().ClearFromBraces ().Trim ();
		type.OverridePropConst(typeof(PrimitiveTask), "Animation","\"{0}\"".Fmt(cat));
	}

	void OtherAnimation (CodeTypeDeclaration type, Table table)
	{
		var catOp = table.Get ("other_animation");
		if (catOp == null)
			return;
		var cat = catOp.Context.ToString ().ClearFromBraces ().Trim ();
		type.OverridePropConst(typeof(InteractionTask), "OtherAnimation","\"{0}\"".Fmt(cat));
	}
	/*
	 * during(condition_name) = {
	 * param1 = value   
	 * param2 = value
	 * other\root are filled automatically
	 * }
	 */
	void Constraints (CodeTypeDeclaration type, Table table)
	{
		var cons = table.AllThat ("during");
		foreach (var con in cons) {
			var call = con.Call ();

		}
	}
	/*
	 * before(condition_name) = {
	 * param1 = value   
	 * param2 = value
	 * other\root are filled automatically
	 * }
	 */
	int depCounter = 0;
	void Dependencies (CodeTypeDeclaration type, Table table)
	{
		var deps = table.AllThat ("before");
		if (deps.Count > 0) {
			type.CreateProp (typeof(List<TaskWrapper>), "deps");
			type.OverridePropConst (typeof(PrimitiveTask), "Dependencies", "deps");
			var ctor = type.GetShared<CodeConstructor> ("ctor");
			ctor.Statements.Add ("deps = new System.Collections.Generic.List<TaskWrapper>();".St());
			FunctionBlock initMethodBlock = null;
			if (type.UserData.Contains ("init_method")) {
				initMethodBlock = type.UserData ["init_method"] as FunctionBlock;
			} else {
				var initMethod = type.GetShared<CodeMemberMethod> ("init");
				initMethod.Name = "Init";
				initMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
				initMethodBlock = initMethod.InitialBlock (type, Engine);
				type.UserData.Add ("init_method", initMethodBlock);
				initMethod.Statements.Add ("base.Init();".St());
			}
			foreach (var dep in deps) {
				var call = dep.Call ();
				if (call != null) {
					var conditionTypeName = dep.ArgValue (0);
					ctor.Statements.Add ("deps.Add(new ScriptedTypes.{0}())".Fmt (type.Name).St ());
					InitForCondition (initMethodBlock, conditionTypeName, dep.Context as Table, depCounter++, "deps", type);
				} 
			}
		}
	}
	/*
	 * engage_in(task_category) = {
	 *   param1 = value
	 *   other\root are filled automatically
	 * }
	 */
	void Engagement(CodeTypeDeclaration type, Table table)
	{
		var engageOp = table.Get("engage");
		if (engageOp == null)
			return;

		type.CreateProp (typeof(TaskWrapper), "engagement");
		type.OverridePropConst (typeof(PrimitiveTask), "EnagegeIn", "engagement");
		var ctor = type.GetShared<CodeConstructor> ("ctor");
		var wrapperType = GenerateTaskWrapper (type.Name, engageOp.ArgValue(0), null, engageOp.Context as Table, type, type.UserData.Contains("category")?type.UserData["category"] as string: null);
		ctor.Statements.Add ("engagement = new {0}();".Fmt(wrapperType).St());
		FunctionBlock initMethodBlock = null;
		if (type.UserData.Contains ("init_method")) {
			initMethodBlock = type.UserData ["init_method"] as FunctionBlock;
		} else {
			var initMethod = type.GetShared<CodeMemberMethod> ("init");
			initMethod.Name = "Init";
			initMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			initMethodBlock = initMethod.InitialBlock (type, Engine);
			type.UserData.Add ("init_method", initMethodBlock);
		}


	}
	/*
	 * [target(root, other, at, whatever that is gameobject)].task_category\name = {
	 *  param1 = value
	 *  param2 = value
	 *  other = other (no manual substitution)
	 * 
	 * }
	 */

	void Tasks(CodeTypeDeclaration type, Table table)
	{
		//foreach table
		//create condition type
		//init it
		int taskCounter = 0;
		var hostTaskName = type.Name;
		int id = 0;

		foreach (var e in table.Entries) {
			var op = e as Operator;
			if(!op.HasBeenInterpreted && (op.Context is Table || (op.Value() == "yes") ))
			{
				var taskType = op.Identifier as string;
				string forAgent = "root";
				if (taskType == null) {
					//this is probably a scope with a specific target agent
					var scope = op.Identifier as Scope;
					forAgent = scope.Parts [0].ToString ().ClearFromBraces ().Trim ();
					taskType = scope.Parts [1].ToString ().ClearFromBraces ().Trim ();

				}
				var hostCategory = type.UserData.Contains ("category") ? type.UserData ["category"] as string : null;
				var wrapperType = GenerateTaskWrapper (hostTaskName, taskType, forAgent, op.Context as Table, type, hostCategory, id++.ToString());

				var ctor = type.GetShared<CodeConstructor> ("ctor");
				if (!ctor.UserData.Contains ("decompositionList")) {
					ctor.UserData.Add ("decompositionList", true);
					ctor.Statements.Add ("decomposition = new System.Collections.Generic.List<TaskWrapper>();".St ());
					var prop = type.CreateProp (typeof(List<TaskWrapper>), "decomposition");
					prop.Attributes = MemberAttributes.Public | MemberAttributes.Override;
					prop.SetStatements.Clear ();
					prop.HasSet = false;
				}
				FunctionBlock initMethodBlock = null;
				if (type.UserData.Contains ("init_method")) {
					initMethodBlock = type.UserData ["init_method"] as FunctionBlock;
				} else {
					var initMethod = type.GetShared<CodeMemberMethod> ("init");
					initMethod.Name = "Init";
					initMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
					initMethodBlock = initMethod.InitialBlock (type, Engine);
					type.UserData.Add ("init_method", initMethodBlock);
				}


				ctor.Statements.Add ("decomposition.Add(new ScriptedTypes.{0}());".Fmt(wrapperType).St());
				initMethodBlock.Statements.Add ("decomposition[{0}].FromTask = this;".Fmt (taskCounter++));
			}
		}

	}


	string GenerateTaskWrapper(string fromTask, string engagement, string forAgent, Table table, CodeTypeDeclaration fromType, string category, string wrapperName = null)
	{
		CodeTypeDeclaration decl = new CodeTypeDeclaration ();
		if (wrapperName == null)
			decl.Name = fromTask + "Engagement";
		else
			decl.Name = fromTask + wrapperName;
		decl.BaseTypes.Add (typeof(TaskWrapper));
		cNamespace.Types.Add (decl);
		decl.OverridePropConst (typeof(TaskWrapper), "TaskCategory", "typeof(ScriptedTypes.{0})".Fmt(engagement));

		decl.OverrideMethodConst (typeof(TaskCondition), "Satisfied", "true"); //для engagementa, иначе там when должен быть
		CodeMemberMethod initTask = null;
		var initTaskMethod = decl.OverrideMethod(typeof(TaskWrapper), "InitTask", Engine, out initTask);
		var exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		initTaskMethod.Statements.Add ("var properTask = task as ScriptedTypes.{0};".Fmt(engagement));
		if (category != null) {
			var rootVar = new DeclareVariableStatement ();
			rootVar.Name = "fromTask";
			rootVar.InitExpression = "FromTask as ScriptedTypes.{0}".Fmt (category);
			rootVar.IsArg = false;
			rootVar.IsContext = true;
			rootVar.Type = Engine.GetType (category);
			if (rootVar.Type != null)
				initTaskMethod.Statements.Add (rootVar);

			if (fromType.UserData.Contains ("is_interaction")) {
				rootVar = new DeclareVariableStatement ();
				rootVar.Name = "Other";
				rootVar.InitExpression = "(FromTask as InteractionTask).Other";
				rootVar.IsArg = false;
				rootVar.IsContext = false;
				rootVar.Type = typeof(GameObject);
				initTaskMethod.Statements.Add (rootVar);

				rootVar = new DeclareVariableStatement ();
				rootVar.Name = "Root";
				rootVar.InitExpression = "FromTask.Root";
				rootVar.IsArg = false;
				rootVar.IsContext = true;
				rootVar.Type = typeof(GameObject);
				initTaskMethod.Statements.Add (rootVar);

				rootVar = new DeclareVariableStatement ();
				rootVar.Name = "At";
				rootVar.InitExpression = "FromTask.At";
				rootVar.IsArg = false;
				rootVar.IsContext = false;
				rootVar.Type = typeof(GameObject);
				initTaskMethod.Statements.Add (rootVar);
			}
			
		}
		foreach (var entry in table.Entries) {
			var op = entry as Operator;
			var paramName = (op.Identifier as string).CSharp();

			var expr = exprInter.InterpretExpression (op.Context as Expression, initTaskMethod);

			var assignStatement = "properTask.{0} = ({2}){1};".Fmt(paramName, expr.ExprString, expr.Type);
			initTaskMethod.Statements.Add (assignStatement);
		}
		initTask.Statements.Add (initTaskMethod.ToString ().St ());
		return decl.Name;
	}

	void InitForCondition(FunctionBlock block, string typeName, Table table, int listIndex, string listName, CodeTypeDeclaration type)
	{
		block.Statements.Add ("var indexedWrapper{0} = {1}[{0}] as ScriptedTypes.{2};".Fmt (listIndex, listName, typeName));
		var exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		bool hadOther = false;
		foreach (var entry in table.Entries) {
			var op = entry as Operator;
			if (op.Identifier as string == "other")
				hadOther = true;
			var expr = exprInter.InterpretExpression (op.Context as Expression, block);
			block.Statements.Add ("indexedWrapper{0}.{1} = ({3})({2})".Fmt(listIndex, (op.Identifier as string).CSharp (), expr.ExprString, expr.Type));
		}
		block.Statements.Add ("indexedWrapper{0}.Root = this.Root".Fmt (listIndex));
		if (!hadOther && type.UserData.Contains ("other"))
			block.Statements.Add ("indexedWrapper{0}.Other = this.Other".Fmt (listIndex));
	}

}

