using UnityEngine;
using System.Collections;
using System.CodeDom;
using InternalDSL;
using System;
public partial class AITasksLoader : ScriptInterpreter
{
	// wrapper_name = {
	//   param1 = float
	//   param2 = float
	//   other = yes
	//   internalProp = some_func(param1)
	//	 task(category) = {
	//      task_param1 = param1
	//      task_param2 = internalProp
	//
	//   }
    //   satisfaction = internalProp > 1
	//   serialization = format("wrapper_name_def", who = root, target = other, param1 = param1, param2 = param2)
	// }
	void Parameters (CodeTypeDeclaration type, Table table)
	{
		foreach (var entry in table.Entries) {
			var eOp = entry as Operator;
			if (eOp == null)
				continue;
			var value = eOp.Value ();
			Type propType = null;
			if (value == "float") {
				propType = typeof(float);
			} else if (value == "int") {
				propType = typeof(int);
			} else if (value == "bool") {
				propType = typeof(bool);
			} else if (value == "gameobject") {
				propType = typeof(GameObject);
			} else {
				continue;
			}
			eOp.HasBeenInterpreted = true;
			type.CreateProp (propType, eOp.Identifier as string);

		}
	}
	void Other (CodeTypeDeclaration type, Table table)
	{
		var otherOp = table.Get ("other");
		if (otherOp == null)
			return;
		if (otherOp.Value () != "yes")
			return;
		type.CreateProp (typeof(GameObject), "other");
	}
	void InternalProperties (CodeTypeDeclaration type, Table table)
	{
		CodeMemberMethod initMethod = new CodeMemberMethod ();
		initMethod.Name = "Init";
		initMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		bool hasInternalProps = false;
		FunctionBlock block = initMethod.InitialBlock (type, Engine);
		var exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		foreach (var entry in table.Entries) {
			var propOp = entry as Operator;
			var entryId = propOp.Identifier as string;
			if (propOp.HasBeenInterpreted)
				continue;
			if (propOp.Context is Table)
				continue;
			if (propOp.Identifier as string == "serialization" || propOp.Identifier as string == "satisfaction" || 
				propOp.Identifier as string == "is_interruptive" || propOp.Identifier as string == "when" || 
				propOp.Identifier as string == "attempts")
				continue;
			propOp.HasBeenInterpreted = true;
			hasInternalProps = true;
			var propBlock = new FunctionBlock (block);
			var expr = exprInter.InterpretExpression (propOp.Context as Expression, propBlock);
			type.CreateProp (expr.Type, propOp.Identifier as string);
			block.Statements.Add ("{0} = {1};".Fmt(propOp.Identifier as string, expr.ExprString));
		}
		initMethod.Statements.Add (new CodeSnippetStatement (block.ToString()));
		if (hasInternalProps)
			type.Members.Add (initMethod);
	}
	void SatisfactionTask (CodeTypeDeclaration type, Table table)
	{
		var satOp = table.Get ("task");
		if (satOp == null)
			return;
		satOp.HasBeenInterpreted = true;
		type.OverridePropConst (typeof(TaskWrapper), "TaskCategory", "typeof(ScriptedTypes.{0})".Fmt(satOp.ArgValue(0)));

		var exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		CodeMemberMethod method = new CodeMemberMethod ();
		method.Name = "InitTask";
		method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		type.Members.Add (method);
		var initTaskTable = satOp.Context as Table;
		FunctionBlock block = method.InitialBlock (type, Engine);
		block.Statements.Add ("var properTask = task as ScriptedTypes.{1};".Fmt(satOp.ArgValue(0)));
		foreach (var val in initTaskTable.Entries) {
			var op = val as Operator;
			FunctionBlock opBlock = new FunctionBlock (block);
			var expr = exprInter.InterpretExpression (op.Context as Expression, opBlock);
			method.Statements.Add(new CodeSnippetStatement(opBlock.ToString()));
			method.Statements.Add ("properTask.{0} = {1};".Fmt((op.Identifier as string), expr.ExprString).St());
			
		}

	}
	void SatisfactionCondition (CodeTypeDeclaration type, Table table)
	{
		var satOp = table.Get ("satisfaction");
		if (satOp == null)
			return;

		satOp.HasBeenInterpreted = true;
		satOp.Scope().Parts.Add("true");
		DeclareVariableStatement retVal = new DeclareVariableStatement();
		retVal.IsReturn = true;
		retVal.Name = "satisfied";
		retVal.Type = typeof(bool);
		retVal.InitExpression = "false";
		CreateEventFunction ("Satisfied", satOp.Context, type, typeof(TaskWrapper).GetMethod ("Satisfied"), retVal);
	}

	void Serialization(CodeTypeDeclaration type, Table table)
	{
		var serOp = table.Get ("serialization");
		if (serOp == null)
			return;
		serOp.HasBeenInterpreted = true;
		type.CreatePropFunc (typeof(TaskWrapper), "Serialize", serOp.Context, Engine);
	}

	void IsInterruptive (CodeTypeDeclaration type, Table table)
	{
		var interOp = table.Get ("is_interruptive");
		if (interOp == null)
			return;
		interOp.HasBeenInterpreted = true;
		type.OverridePropConst (typeof(TaskWrapper), "Interruptive", interOp.Value ()); 
	}
	void When (CodeTypeDeclaration type, Table table)
	{
		var whenOp = table.Get ("when");
		if (whenOp == null)
			return;
		whenOp.HasBeenInterpreted = true;

		whenOp.Scope().Parts.Add("true");
		DeclareVariableStatement retVal = new DeclareVariableStatement();
		retVal.IsReturn = true;
		retVal.Name = "should";
		retVal.Type = typeof(bool);
		retVal.InitExpression = "false";
		CreateEventFunction ("Satisfied", whenOp.Context, type, typeof(TaskWrapper).GetMethod ("Satisfied"), retVal);
	}
	void Attempts (CodeTypeDeclaration type, Table table)
	{
		var aOp = table.Get ("attempts");
		if (aOp == null)
			return;
		aOp.HasBeenInterpreted = true;
		type.OverridePropConst (typeof(TaskWrapper), "MaxAttempts", aOp.Value ()); 
	}


	//root.specific_task\task_category = {
	//	param1 = value
	//  param2 = value
	//  param3 = value
	//  when = expr
	//  attempts = 3 (only if task_category)
	//  (I attempt to change only if the root task doesn't have at scope)
	//  
	//
	//
	//}
}

