using UnityEngine;
using System.Collections;
using InternalDSL;
using System;


[CommonFunctionOperator ("repeat")]
public class RepeatOperator : FunctionOperatorInterpreter
{
	ExpressionInterpreter exprInterpreter;
	EventFunctionOperators ops;

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}

	public override void Interpret (Operator op, FunctionBlock block)
	{
		if (exprInterpreter == null)
		{

			exprInterpreter = Engine.GetPlugin<ExpressionInterpreter> ();
			ops = Engine.GetPlugin<EventFunctionOperators> ();
		}
		if (op.Args.Count == 1)
		{
			ForStatement stmt = new ForStatement ();
			stmt.RepeatBlock = new FunctionBlock (block, block.Method, block.Type);
			stmt.InsideExpr = String.Format ("int i = 0; i < {0}; i++", exprInterpreter.InterpretExpression (op.Args [0], block).ExprString);

			block.Statements.Add (stmt);
			foreach (var entry in (op.Context as Context).Entries)
			{
				var subOp = entry as Operator;
			
				if (subOp == null)
					continue;
				var subInter = ops.GetInterpreter (subOp, stmt.RepeatBlock);

				if (subInter == null)
				{
					Debug.LogFormat ("Can't interpret operator {0} in {1}", subOp.Identifier, block.Method.Name);
					continue;
				}
				//Debug.Log (subOp.Identifier);
				subInter.Interpret (subOp, stmt.RepeatBlock);
			}

		} else
		{
			Debug.Log ("Error in repeat definion - more or less than one argument");

		}
	}
}

