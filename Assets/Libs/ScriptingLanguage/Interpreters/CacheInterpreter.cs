using UnityEngine;
using System.Collections;
using InternalDSL;
using System.CodeDom;
using System;

[CommonFunctionOperator ("cache")]
public class CacheInterpreter : FunctionOperatorInterpreter
{
	EventFunctionOperators ops;
	ExpressionInterpreter exprInter;
	ContextSwitchesPlugin ctxs;

	public override void Interpret (InternalDSL.Operator op, FunctionBlock block)
	{
		if (ops == null)
		{
			ctxs = Engine.GetPlugin<ContextSwitchesPlugin> ();
			ops = Engine.GetPlugin<EventFunctionOperators> ();
			exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		}
		if (op.Args.Count > 0)
		{
			var varName = ((op.Args [0].Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
			if (op.Context is Expression)
			{
				//cache(some_name) = expression
//				var varDecl = block.FindStatement<DeclareVariableStatement> (v => v.Name == varName);
//				varDecl.IsArg = true;

				var exprValue = exprInter.InterpretExpression (op.Context as Expression, block);
				Debug.Log (exprValue.ExprString);
				var field = new CodeMemberField (exprValue.Type, varName);
				field.UserData.Add ("type", exprValue.Type);
				block.Type.Members.Add (field);
				block.Statements.Add (String.Format ("{0} = {1};", varName, exprValue.ExprString));
                block.Statements.Add(new DeclareVariableStatement() {Name = varName, IsArg = true, Type = exprValue.Type });
				//var varDecl = block.FindStatement<DeclareVariableStatement> (v => v.Name == varName);
			} else
			{
				//cache(some_name, scope) = { ... }
				var exprValue = exprInter.InterpretExpression (op.Args [1], block);
				var field = new CodeMemberField (exprValue.Type, varName);
				field.UserData.Add ("type", exprValue.Type);
				block.Type.Members.Add (field);
				DeclareVariableStatement cachedVar = new DeclareVariableStatement ();
				cachedVar.Name = varName;
				cachedVar.IsContext = true;
				cachedVar.Type = exprValue.Type;
				cachedVar.IsArg = true;
				block.Statements.Add (cachedVar);
				block.Statements.Add (String.Format ("{0} = {1};", varName, exprValue.ExprString));
                block.Statements.Add(new DeclareVariableStatement() { Name = varName, IsArg = true, Type = exprValue.Type });
                var inter = ctxs.GetInterByType (exprValue.Type);
				inter.Interpret (op, block);

			}
		} else
		{
			//cache = some_name

			var varName = (((op.Context as Expression).Operands [0] as ExprAtom).Content as Scope).Parts [0] as string;
			var varDecl = block.FindStatement<DeclareVariableStatement> (v => v.Name == varName);
			//varDecl.IsArg = true;
			varDecl.IsDeclaration = false;

			var field = new CodeMemberField (varDecl.Type, varDecl.Name);
			field.UserData.Add ("type", varDecl.Type);
			block.Type.Members.Add (field);
			//block.Statements.Add (String.Format ("this.{0} = {0};", varName));
		}

		//new CodeMemberField()
		//block.Type.Members.Add ();
	}

	public override bool Match (InternalDSL.Operator op, FunctionBlock block)
	{
		return false;
	}
}

