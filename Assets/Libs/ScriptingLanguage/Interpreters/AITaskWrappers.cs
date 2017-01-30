using UnityEngine;
using System.Collections;
using System.CodeDom;
using InternalDSL;
using System;
public partial class AITasksLoader : ScriptInterpreter
{

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
		foreach (var entry in table.Entries) {
			var propOp = entry as Operator;
			var entryId = propOp.Identifier as string;
			if (propOp.HasBeenInterpreted)
				continue;
		}
	}
	void SatisfactionTask (CodeTypeDeclaration type, Table table)
	{
		var satOp = table.Get ("task");
		if (satOp == null)
			return;
		satOp.HasBeenInterpreted = true;
		type.OverridePropConst (typeof(TaskWrapper), "TaskCategory", "typeof(ScriptedTypes.{0})".Fmt(satOp.ArgValue(0)));

		foreach (var entry in (satOp.Context as Table).Entries) {
			
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
}

