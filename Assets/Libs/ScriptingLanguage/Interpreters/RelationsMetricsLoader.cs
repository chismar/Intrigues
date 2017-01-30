using InternalDSL;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class RelationsMetricsLoader : ScriptInterpreter
{
    CodeNamespace cNamespace = new CodeNamespace();
    EventFunctionOperators functionOperators;
    ExpressionInterpreter exprInter;
    CodeTypeDeclaration codeType;
    MethodInfo delegateMethod;
    public RelationsMetricsLoader(string namespaceName, string typeName, Type targetFunc, ScriptEngine engine) : base (engine)
	{
        cNamespace.Name = namespaceName;
        exprInter = engine.GetPlugin<ExpressionInterpreter>();
        functionOperators = engine.GetPlugin<EventFunctionOperators>();
        codeType = new CodeTypeDeclaration();
        codeType.Name = typeName;
        cNamespace.Types.Add(codeType);
        delegateMethod = targetFunc.GetMethod("Invoke");
    }

    public override void Interpret(Script script)
    {
        MaxProgress = script.Entries.Count;
        for (int i = 0; i < script.Entries.Count; i++)
        {
            if (!Engine.Working)
                System.Threading.Thread.CurrentThread.Abort();
            CurProgress = i;
            var entry = script.Entries[i];

            DeclareVariableStatement relationVal = new DeclareVariableStatement();
            relationVal.IsReturn = true;
            relationVal.Name = "relation";
            relationVal.Type = typeof(float);
            relationVal.InitExpression = "0";
            CreateEventFunction(entry.Identifier as string, entry.Context, codeType, delegateMethod, relationVal);

        }
        CurProgress = MaxProgress;

        CSharpCodeProvider provider = new CSharpCodeProvider();
        CodeGeneratorOptions options = new CodeGeneratorOptions();
        var writer = new StringWriter();
        provider.GenerateCodeFromNamespace(cNamespace, writer, options);
        Engine.GetPlugin<ScriptCompiler>().AddSource(writer.ToString());

    }
    

    void CreateEventFunction(string name, object context, CodeTypeDeclaration codeType, MethodInfo baseMethod, params object[] initStatements)
    {
        CodeMemberMethod method = new CodeMemberMethod();
        method.Name = NameTranslator.CSharpNameFromScript(name);
        method.Attributes = MemberAttributes.Public;
        method.ReturnType = new CodeTypeReference(baseMethod.ReturnType);
        var args = baseMethod.GetParameters();
        FunctionBlock block = new FunctionBlock(null, method, codeType);
        block.Statements.Add("var root = this.root;");
        //block.Statements.Add ("UnityEngine.Debug.Log(root.ToString() + IfStatement.AntiMergeValue++);");
        var externVar = new DeclareVariableStatement()
        {
            Name = "External",
            IsArg = true,
            Type = Engine.GetType("External")
        };
        block.Statements.Add(externVar);
        block.Statements.Add(new ContextStatement()
        {
            ContextVar = externVar,
            InterpretInContext = Engine.GetPlugin<ExternalFunctionsPlugin>().Ctx.InterpretInContext
        });
        foreach (var initStmt in initStatements)
            block.Statements.Add(initStmt);
        //bool hasRoot = false;
        foreach (var arg in args)
        {
            //if (arg.Name == "root")
            //	hasRoot = true;
            method.Parameters.Add(new CodeParameterDeclarationExpression(arg.ParameterType, arg.Name));
            var paramVar = new DeclareVariableStatement();
            paramVar.Name = arg.Name;
            paramVar.Type = arg.ParameterType;
            paramVar.IsArg = true;
            block.Statements.Add(paramVar);
        }
        var rootVar = new DeclareVariableStatement();
        rootVar.Name = "root";
        rootVar.Type = typeof(GameObject);
        rootVar.IsArg = true;

        block.Statements.Add(rootVar);


        foreach (var member in codeType.Members)
        {
            var field = member as CodeMemberField;
            if (field != null)
            {
                var cachedVar = new DeclareVariableStatement();
                cachedVar.Name = field.Name;
                cachedVar.Type = field.UserData["type"] as Type;
                cachedVar.IsArg = true;

                block.Statements.Add(cachedVar);
            }
        }
        //if (!hasRoot)
        //{
        //	Debug.LogFormat ("Method {0} in {1} has no root arg", baseMethod.Name, codeType.Name);
        //	return;
        //}

        codeType.Members.Add(method);
        var table = context as Table;
        if (table != null)
        {
            foreach (var entry in table.Entries)
            {
                Operator op = entry as Operator;
                var inter = functionOperators.GetInterpreter(op, block);
                if (inter == null)
                {
                    Debug.LogFormat("Can't find interpreter for operator {0} in {1} of {2}", op.Identifier, baseMethod.Name, codeType.Name);
                    continue;
                }
                inter.Interpret(op, block);
            }
            var retVal = block.FindStatement<DeclareVariableStatement>(v => v.IsReturn);
            if (retVal != null)
                block.Statements.Add(String.Format("return {0};", retVal.Name));
        }
        else
        {
            var expr = context as Expression;

            var retVal = block.FindStatement<DeclareVariableStatement>(v => v.IsReturn);
            //retVal.IsArg = true;
            block.Statements.Add(String.Format("return ({1}){0};", exprInter.InterpretExpression(expr, block).ExprString, TypeName.NameOf(retVal.Type)));
        }

        method.Statements.Add(new CodeSnippetStatement(block.ToString()));
    }
}
