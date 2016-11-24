using UnityEngine;
using System.Collections;
using InternalDSL;
using System;


[CommonFunctionOperator ("add_to")]
public class AddToListOperator : FunctionOperatorInterpreter
{
	ExpressionInterpreter exprInter;

	public override void Interpret (Operator op, FunctionBlock block)
	{

		if (exprInter == null)
			exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		if (op.Args.Count > 0 && op.Args [0].Operands [0] is ExprAtom &&
		    (op.Args [0].Operands [0] as ExprAtom).Content is Scope &&
		    ((op.Args [0].Operands [0] as ExprAtom).Content as Scope).Parts.Count == 1)
		{
			var part = ((op.Args [0].Operands [0] as ExprAtom).Content as Scope).Parts [0];
			if (!(part is string))
			{
				Debug.Log ("Wrong add_to definition");
				return;
			}
			var listName = NameTranslator.CSharpNameFromScript (part as string);
			DeclareVariableStatement declareVar = block.FindStatement<DeclareVariableStatement> (v => v.IsContext && v.Type.GetProperty (listName) != null);
			//Debug.Log (declareVar.DebugString ());
			if (declareVar == null)
			{
				Debug.Log ("add_to operator can't find context variable");
			} else
			{
				if (op.Context is Expression)
				{
					var exprValue = exprInter.InterpretExpression (op.Context as Expression, block);
					//block = exprValue.NotNullBlock;
					block.Statements.Add (String.Format ("{0}.{1}.Add({2});", declareVar.Name, listName, exprValue.ExprString));
				} 
			}

		} else
		{
			Debug.Log ("Wrong add_to definition");
		}

	}

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}
}

[CommonFunctionOperator("remove_from")]
public class RemoveFromListOperator : FunctionOperatorInterpreter
{
    ExpressionInterpreter exprInter;

    public override void Interpret(Operator op, FunctionBlock block)
    {

        if (exprInter == null)
            exprInter = Engine.GetPlugin<ExpressionInterpreter>();
        if (op.Args.Count > 0 && op.Args[0].Operands[0] is ExprAtom &&
            (op.Args[0].Operands[0] as ExprAtom).Content is Scope &&
            ((op.Args[0].Operands[0] as ExprAtom).Content as Scope).Parts.Count == 1)
        {
            var part = ((op.Args[0].Operands[0] as ExprAtom).Content as Scope).Parts[0];
            if (!(part is string))
            {
                Debug.Log("Wrong remove_from definition");
                return;
            }
            var listName = NameTranslator.CSharpNameFromScript(part as string);
            DeclareVariableStatement declareVar = block.FindStatement<DeclareVariableStatement>(v => v.IsContext && v.Type.GetProperty(listName) != null);
            //Debug.Log (declareVar.DebugString ());
            if (declareVar == null)
            {
                Debug.Log("remove_from operator can't find context variable");
            }
            else
            {
                if (op.Context is Expression)
                {
                    var exprValue = exprInter.InterpretExpression(op.Context as Expression, block);
                    //block = exprValue.NotNullBlock;
                    block.Statements.Add(String.Format("{0}.{1}.Remove({2});", declareVar.Name, listName, exprValue.ExprString));
                }
            }

        }
        else
        {
            Debug.Log("Wrong remove_from definition");
        }

    }

    public override bool Match(Operator op, FunctionBlock block)
    {
        return false;
    }
}