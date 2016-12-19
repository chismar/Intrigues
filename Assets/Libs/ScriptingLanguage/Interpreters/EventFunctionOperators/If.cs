using UnityEngine;
using System.Collections;
using InternalDSL;


[CommonFunctionOperator ("if")]
public class IfOperator : FunctionOperatorInterpreter
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
			//Shouldn't declare variable
			IfStatement ifStatement = new IfStatement ();
			ifStatement.CheckExpression = exprInterpreter.InterpretExpression (op.Args [0], block).ExprString;
			ifStatement.TrueBlock = new FunctionBlock (block, block.Method, block.Type);

			block.Statements.Add (ifStatement);
			foreach (var entry in (op.Context as Context).Entries)
			{
				var subOp = entry as Operator;
				if (subOp == null)
					continue;
				var subInter = ops.GetInterpreter (subOp, ifStatement.TrueBlock);
				if (subInter == null)
				{
					Debug.LogFormat ("Can't interpret operator {0} in {1}", subOp.Identifier, block.Method.Name);
					continue;
				}
				subInter.Interpret (subOp, ifStatement.TrueBlock);
			}

		} else if (op.Args.Count == 2)
		{
			DeclareVariableStatement declareVar = new DeclareVariableStatement ();
			if (op.Args [1].Operands [0] is IdWrapper)
			{

				var id = ((IdWrapper)op.Args [1].Operands [0]).ToString();
				declareVar.Name = id;
				declareVar.Type = typeof(bool);
				declareVar.InitExpression = "false";
			} else
			{
				Debug.Log ("Wrong definition of an if operator with a variable - variable is not an identifier");
				return;
			}

			block.Statements.Add (declareVar);

			//Should declare variable

		}
	}
}
