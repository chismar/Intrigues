using UnityEngine;
using System.Collections;
using InternalDSL;
using System;
using System.CodeDom;
using System.Reflection;
using System.Collections.Generic;
[CommonFunctionOperator("do")]
public class DoOperator: FunctionOperatorInterpreter
{
    ExpressionInterpreter exprInter;

    Dictionary<string, PropertyInfo> propsDict = new Dictionary<string, PropertyInfo>();
    public override void Interpret(Operator op, FunctionBlock block)
    {

        if (exprInter == null)
            exprInter = Engine.GetPlugin<ExpressionInterpreter>();

        block.Method.ReturnType = new CodeTypeReference(typeof(IEnumerator));
        block.Method.Attributes = MemberAttributes.Public;
        block.Method.Name = "ActionCoroutine";
        if (!block.Method.UserData.Contains("has_transformed_action"))
        {
            var newActionMethod = new CodeMemberMethod();
            newActionMethod.Name = "Action";
            newActionMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            newActionMethod.Statements.Add(new CodeSnippetStatement("Coroutine = ActionCoroutine(); state = ActionState.Started;"));
            block.Type.Members.Add(newActionMethod);
            block.Method.UserData.Add("has_transformed_action", "has_transformed_action");
        }

        var contextVar = block.FindStatement<DeclareVariableStatement>(v => (v.IsContext) && v.Type == typeof(Actor));
        if(contextVar == null)
            contextVar = block.FindStatement<DeclareVariableStatement>(v => (v.IsContext) && v.Type == typeof(GameObject));
        int aId = 0;
        if (op.Args.Count == 1)
        {
            if(op.Context is Expression)
            {
                //do(interaction_type) = target
                var interTypeArg = op.Args[0].ToString().ClearFromBraces();
                var targetArg = exprInter.InterpretExpression(op.Context as Expression, block);
                aId = DeclareVariableStatement.VariableId++;
                block.Statements.Add(String.Format("var a{0} = Actions.Instance.GetAction(typeof(ScriptedTypes.{1}));", aId, interTypeArg));
                block.Statements.Add(String.Format("a{0}.Init();", aId));
                block.Statements.Add(String.Format("(a{0} as EventInteraction).Initiator = {1};", aId, (contextVar.Type == typeof(GameObject)? contextVar.Name : (contextVar.Name + ".gameObject"))));
                if(targetArg.Type == typeof(GameObject))
                    block.Statements.Add(String.Format("a{0}.Root = {1};", aId, targetArg.ExprString));
                else
                    block.Statements.Add(String.Format("a{0}.Root = {1}.gameObject;", aId, targetArg.ExprString));
                block.Statements.Add(String.Format("UnityEngine.Debug.Log(a{0}.Root);", aId));
                block.Statements.Add(String.Format("UnityEngine.Debug.Log((a{0} as EventInteraction).Initiator);", aId));
                if (contextVar.Type == typeof(GameObject))
                    block.Statements.Add(String.Format("({0}.GetComponent(typeof(Actor)) as Actor).Act(a{1});", contextVar.Name, aId));
                else
                    block.Statements.Add(String.Format("{0}.Act(a{1});", contextVar.Name, aId));

            }
            else
            {
                //do(interaction_type) = { target = some_object some_argument = some_value }
                var interTypeArg = op.Args[0].ToString().ClearFromBraces();
                aId = DeclareVariableStatement.VariableId++;
                block.Statements.Add(String.Format("var a{0} = Actions.Instance.GetAction(typeof(ScriptedTypes.{1}));", aId, interTypeArg));
                block.Statements.Add(String.Format("a{0}.Init();", aId));
                block.Statements.Add(String.Format("(a{0} as EventInteraction).Initiator = {1};", aId, (contextVar.Type == typeof(GameObject) ? contextVar.Name : (contextVar.Name + ".gameObject"))));
                var type = Engine.FindType(interTypeArg);
                var props = type.GetProperties();
                propsDict.Clear();
                foreach (var prop in props)
                    propsDict.Add(NameTranslator.ScriptNameFromCSharp(prop.Name), prop);
                foreach ( var subOpObject in (op.Context as Table).Entries)
                {
                    PropertyInfo prop;
                    var subOp = subOpObject as Operator;
                    if(subOp.Identifier as string == "target")
                    {

                        var targetArg = exprInter.InterpretExpression(subOp.Context as Expression, block);
                        if (targetArg.Type == typeof(GameObject))
                            block.Statements.Add(String.Format("a{0}.Root = {1};", aId, targetArg.ExprString));
                        else
                            block.Statements.Add(String.Format("a{0}.Root = {1}.gameObject;", aId, targetArg.ExprString));

                    }
                    else if(propsDict.TryGetValue(subOp.Identifier as string, out prop))
                    {
                        var propArg = exprInter.InterpretExpression(subOp.Context as Expression, block).ExprString;
                        block.Statements.Add(String.Format("(a{0} as EventInteraction).{1} = ({3}){2};", aId, prop.Name, propArg, prop.PropertyType));
                    }

                }
                var propExpr = exprInter.InterpretExpression(op.Args[0], block).ExprString;
                //block.Statements.Add(String.Format("(a{0} as ScriptedTypes.{1}).{2} = ({4}){3}", aId, interTypeArg, prop.Name, propExpr));
                if (contextVar.Type == typeof(GameObject))
                    block.Statements.Add(String.Format("({0}.GetComponent(typeof(Actor)) as Actor).Act(a{1});", contextVar.Name, aId));
                else
                    block.Statements.Add(String.Format("{0}.Act(a{1});", contextVar.Name, aId));
            }
        }
        else if(op.Args.Count == 2)
        {
            //do(interaction_type, possible_one_argument) = target
            var interTypeArg = op.Args[0].ToString().ClearFromBraces();
            var targetArg = exprInter.InterpretExpression(op.Context as Expression, block);
            aId = DeclareVariableStatement.VariableId++;
            block.Statements.Add(String.Format("var a{0} = Actions.Instance.GetAction(typeof(ScriptedTypes.{1}));", aId, interTypeArg));
            block.Statements.Add(String.Format("a{0}.Init();", aId));
            var type = Engine.FindType(interTypeArg);
            var props = type.GetProperties();
            if (ScriptEngine.AnalyzeDebug)
                if (props.Length != 1)
                    Debug.LogErrorFormat("Wrong number of properties for DO statement in ", block.Type.Name);
            var prop = props[0];
            var propExpr = exprInter.InterpretExpression(op.Args[0], block).ExprString;
            block.Statements.Add(String.Format("(a{0} as EventInteraction).Initiator = {1};", aId, (contextVar.Type == typeof(GameObject) ? contextVar.Name : (contextVar.Name + ".gameObject"))));
            if(targetArg.Type == typeof(GameObject))
                block.Statements.Add(String.Format("a{0}.Root = {1};", aId, targetArg.ExprString));
            else
                block.Statements.Add(String.Format("a{0}.Root = {1}.gameObject;", aId, targetArg.ExprString));
            block.Statements.Add(String.Format("(a{0} as ScriptedTypes.{1}).{2} = {3}", aId, interTypeArg, prop.Name, propExpr));
            if (contextVar.Type == typeof(GameObject))
                block.Statements.Add(String.Format("({0}.GetComponent(typeof(Actor)) as Actor).Act(a{1});", contextVar.Name, aId));
            else
                block.Statements.Add(String.Format("{0}.Act(a{1});", contextVar.Name, aId));

        }
        string operatorString = null;
        

        if (operatorString != null)
            block.Statements.Add(operatorString);
        var waitString = string.Format("while(a{0}.State != EventAction.ActionState.Finished){{ if(a{0}.State == EventAction.ActionState.Failed) {{ this.state = EventAction.ActionState.Failed; yield break; }} yield return null; }}",
            aId);
        block.Statements.Add(waitString);

    }

    public override bool Match(Operator op, FunctionBlock block)
    {
        return false;
    }
}
