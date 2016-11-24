using UnityEngine;
using System.Collections;
using InternalDSL;
using System.Collections.Generic;
using System;

[CommonFunctionOperator ("create")]
public class CreationInterpreter : FunctionOperatorInterpreter
{
	EventFunctionOperators ops;
	ContextSwitchesPlugin switches;
	Dictionary<string, Type> components = new Dictionary<string, Type> ();



	public override void Interpret (Operator op, FunctionBlock block)
	{
		if (ops == null)
		{
			ops = Engine.GetPlugin<EventFunctionOperators> ();
			switches = Engine.GetPlugin<ContextSwitchesPlugin> ();
			var cmps = Engine.FindTypesCastableTo<MonoBehaviour> ();
			foreach (var cmp in cmps)
				components.Add (NameTranslator.ScriptNameFromCSharp (cmp.Name), cmp);
		}
		//add = cmp_type - no args, context is Expression
		//add(var) = cmp_type - 1 arg, context is Expression
		//add(cmp_type) = { ... } - 1 arg, context is Context
		//add(var, cmp_type) = { ... } - 2 args, context is Context
		DeclareVariableStatement cmpVar = null;
		DeclareVariableStatement contextVar = block.FindStatement<DeclareVariableStatement> (v => (v.IsContext | v.IsArg) && v.Type == typeof(GameObject));
		string ctxVar = contextVar == null ? "root" : contextVar.Name;
		if (op.Args.Count == 0)
		{
			var expr = op.Context as Expression;
			if (expr != null)
			{
				var cmpType = (((op.Context as Expression).Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
				block.Statements.Add (string.Format ("{0}.AddComponent<{1}>();", ctxVar, components [cmpType]));
			}
		} else if (op.Args.Count == 1)
		{
			var ctx = op.Context as Context;
			var expr = op.Context as Expression;
			if (expr != null)
			{

				var cmpTypeName = (((op.Context as Expression).Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
				var varName = ((op.Args [0].Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
				var cmpType = components [cmpTypeName];
				cmpVar = new DeclareVariableStatement ();
				cmpVar.InitExpression = string.Format ("{0}.AddComponent<{1}>();", ctxVar, cmpType);
				cmpVar.Type = cmpType;
				cmpVar.Name = varName;
				cmpVar.IsNew = true;
				cmpVar.IsContext = true;
				block.Statements.Add (cmpVar);
			} else if (ctx != null)
			{
				var cmpTypeName = ((op.Args [0].Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
				var cmpType = components [cmpTypeName];
				cmpVar = new DeclareVariableStatement ();
				cmpVar.InitExpression = string.Format ("{0}.AddComponent<{1}>();", ctxVar, cmpType);
				cmpVar.Type = cmpType;
				cmpVar.IsContext = true;
				cmpVar.IsNew = true;
				cmpVar.Name = "ContextVar" + DeclareVariableStatement.VariableId++;
				block.Statements.Add (cmpVar);
				switches.GetInterByType (cmpType).Interpret (op, block);

			}
		} else if (op.Args.Count == 2)
		{

			var ctx = op.Context as Context;
			if (ctx != null)
			{
				var cmpTypeName = ((op.Args [1].Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
				var varName = ((op.Args [0].Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
				var cmpType = components [cmpTypeName];
				cmpVar = new DeclareVariableStatement ();
				cmpVar.InitExpression = string.Format ("{0}.AddComponent<{1}>();", ctxVar, cmpType);
				cmpVar.Type = cmpType;
				cmpVar.IsContext = true;
				cmpVar.IsNew = true;
				cmpVar.Name = varName;
				block.Statements.Add (cmpVar);
				switches.GetInterByType (cmpType).Interpret (op, block);

			}
		}


		var entVar = block.FindStatement<DeclareVariableStatement> (v => v.ctxEntity == ctxVar && v.Type == typeof(Entity));
		if (entVar == null)
		{
			entVar = new DeclareVariableStatement ();
			entVar.Name = "EntVar" + DeclareVariableStatement.VariableId++;
			entVar.Type = typeof(Entity);
			entVar.ctxEntity = ctxVar;

			entVar.InitExpression = String.Format ("(Entity){0}.GetComponent(typeof(Entity));", ctxVar);
			block.Statements.Add (entVar);
			var updateSt = new StatementStringContainer (String.Format ("if({0} != null) {0}.ComponentAdded();", entVar.Name));
			entVar.Cnt = updateSt;
			block.Statements.Add (updateSt);
		} else
		{
			var updateSt = new StatementStringContainer (entVar.Cnt.Data);
			entVar.Cnt.Data = "";
			entVar.Cnt = updateSt;
			block.Statements.Add (updateSt);
		}

		if (cmpVar != null)
			cmpVar.IsContext = false;



	}

	public override bool Match (InternalDSL.Operator op, FunctionBlock block)
	{
		return false;
	}
}

public class StatementStringContainer
{
	public string Data;

	public StatementStringContainer (string data)
	{
		Data = data;
	}

	public override string ToString ()
	{
		return Data;
	}
}

