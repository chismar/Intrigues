using UnityEngine;
using System.Collections;
using InternalDSL;
using System;
using System.CodeDom;

[CommonFunctionOperator("wait")]
public class WaitOperator : FunctionOperatorInterpreter
{
    ExpressionInterpreter exprInter;
    

    public override void Interpret(Operator op, FunctionBlock block)
    {


        if (exprInter == null)
            exprInter = Engine.GetPlugin<ExpressionInterpreter>();
        if (op.Args.Count == 2)
        {
            block.Method.ReturnType = new CodeTypeReference(typeof(IEnumerator));
            block.Method.Attributes = MemberAttributes.Public;
            block.Method.Name = "ActionCoroutine";
            if(!block.Method.UserData.Contains("has_transformed_action"))
            {
                var newActionMethod = new CodeMemberMethod();
                newActionMethod.Name = "Action";
                newActionMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
                newActionMethod.Statements.Add(new CodeSnippetStatement("Coroutine = ActionCoroutine(); state = ActionState.Started;"));
                block.Type.Members.Add(newActionMethod);
                block.Method.UserData.Add("has_transformed_action", "has_transformed_action");
            }
            var whileArg = exprInter.InterpretExpression(op.Args[0], block);
            var failArg = exprInter.InterpretExpression(op.Args[1], block);
            string operatorString = null;
            operatorString = string.Format("while({0}){{ if({1}) {{ this.state = EventAction.ActionState.Failed; yield break; }} yield return null; }}",
            whileArg.ExprString, failArg.ExprString);
            if (op.Context is Expression)
            {

                var timeArg = exprInter.InterpretExpression(op.Context as Expression, block);
                if(timeArg.Type != typeof(bool))
                {
                    operatorString =
                    string.Format("float time{2} = UnityEngine.Time.realtimeSinceStartup; while({0}){{ if ((UnityEngine.Time.RealtimeSinceStartup - time{2} > {3}) || ({1})) {{ this.state = EventAction.ActionState.Failed; yield break; }} yield return null; }}",
                    whileArg.ExprString, failArg.ExprString, DeclareVariableStatement.VariableId++, timeArg.ExprString);
                }
                
            }
            if(operatorString != null)
                block.Statements.Add(operatorString);
        }
        

    }
    

    public override bool Match(Operator op, FunctionBlock block)
    {
        return false;
    }
}
