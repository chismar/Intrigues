using UnityEngine;
using System.Collections;
using System.CodeDom;
using System.Collections.Generic;
using InternalDSL;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using System;
using System.Threading;
using System.Text;

public abstract class Reaction
{
    public abstract Event Root { get; set; }
    public abstract bool Filter();
    public abstract void Action();
    public ReactionAttribute Meta { get; set; }
}

public abstract class PersonalReaction
{
    protected GameObject root;
    public GameObject Root { get { return root; } set { root = value; } }
    public abstract Event Event { get; set; }
    public abstract bool RootFilter();
    public virtual bool EventFilter() { return true; }
    public abstract void Action();
    public ReactionAttribute Meta { get; set; }
}

public class ReactionAttribute : Attribute
{
    public bool IsRepeatable { get; set; }
    public Type EventFeed { get; set; }
    public Type EventType { get; set; }
}
public class ReactionsLoader : ScriptInterpreter
{
    List<CodeTypeDeclaration> codeTypes = new List<CodeTypeDeclaration>();
    FiltersPlugin filters;
    CodeNamespace cNamespace = new CodeNamespace();
    EventFunctionOperators functionOperators;
    ExpressionInterpreter exprInter;

    public ReactionsLoader(string namespaceName, ScriptEngine engine) : base(engine)
    {
        cNamespace.Name = namespaceName;
        exprInter = engine.GetPlugin<ExpressionInterpreter>();
        filters = engine.GetPlugin<FiltersPlugin>();
        functionOperators = engine.GetPlugin<EventFunctionOperators>();
    }
    StringBuilder builder = new StringBuilder();
    public override void Interpret(Script script)
    {
        MaxProgress = script.Entries.Count;
        for (int i = 0; i < script.Entries.Count; i++)
        {

            if (!Engine.Working)
                Thread.CurrentThread.Abort();
            CurProgress = i;
            var entry = script.Entries[i];

            var eTypeName = NameTranslator.CSharpNameFromScript(entry.Args[0].ToString().ClearFromBraces()).TrimEnd(' ');
            //Debug.Log(eTypeName);
            //Engine.ListTypes();
            var eType = Engine.GetType(eTypeName);
            //Debug.Log(eType);
            CodeTypeDeclaration codeType = new CodeTypeDeclaration();
            //codeType.CustomAttributes.
            codeType.BaseTypes.Add(new CodeTypeReference(typeof(Reaction)));
            codeType.Name = entry.Identifier as string;
            codeTypes.Add(codeType);

            if (ScriptEngine.AnalyzeDebug)
                Debug.LogWarning((entry.Identifier as string).ToUpper());

            var ctx = entry.Context as Context;
            if (ctx == null)
                continue;
            var actionMethod = typeof(Reaction).GetMethod("Action");
            var scopeMethod = typeof(Reaction).GetMethod("Filter");
            var personalScopeMethod = typeof(PersonalReaction).GetMethod("RootFilter");
            var eventScopeMethod = typeof(PersonalReaction).GetMethod("EventFilter");

            CodeAttributeDeclaration attr = new CodeAttributeDeclaration("ReactionAttribute");
            codeType.CustomAttributes.Add(attr);
            CodeAttributeArgument repeatableArg = new CodeAttributeArgument("IsRepeatable", new CodeSnippetExpression("false"));
            CodeAttributeArgument eventFeedArg;
            CodeAttributeArgument eventTypeArg = new CodeAttributeArgument("EventType", new CodeSnippetExpression("\"\""));
            attr.Arguments.Add(repeatableArg);
            attr.Arguments.Add(eventTypeArg);
            FunctionBlock dependenciesBlock = new FunctionBlock(null, null, codeType);
            List<string> deps = new List<string>();
            bool isPersonal = false;
            for (int j = 0; j < ctx.Entries.Count; j++)
            {
                var op = ctx.Entries[j] as Operator;
                if (op == null)
                    continue;
                if (op.Identifier as string == "feed")
                {
                    var feedTypeName = (op.Context as InternalDSL.Expression).Operands[0].ToString().ClearFromBraces().TrimEnd(' ');
                    var type = Engine.FindType(NameTranslator.CSharpNameFromScript(feedTypeName));
                    eventFeedArg = new CodeAttributeArgument("EventFeed",
                        new CodeSnippetExpression("typeof({0})".Fmt(type.Name)));

                    attr.Arguments.Add(eventFeedArg);
                    //here I should change the reaction to personal one
                    codeType.BaseTypes.Clear();
                    codeType.BaseTypes.Add(typeof(PersonalReaction));
                    isPersonal = true;
                }
                else if (op.Identifier as string == "is_repeatable")
                {

                    repeatableArg.Value = new CodeSnippetExpression("true");

                }
                else if (op.Identifier as string == "scope")
                {
                    //It's a filter function
                    //					Debug.Log (op.Context.GetType ());
                    if (ScriptEngine.AnalyzeDebug)
                        Debug.Log((op.Context as Expression).Operands[0].GetType());

                    (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts.Add("true");
                    DeclareVariableStatement retVal = new DeclareVariableStatement();
                    retVal.IsReturn = true;
                    retVal.Name = "applicable";
                    retVal.Type = typeof(bool);
                    retVal.InitExpression = "false";

                    if (isPersonal)
                    {
                        DeclareVariableStatement eventField = new DeclareVariableStatement();
                        eventField.Name = "e";
                        eventField.Type = eType;
                        eventField.InitExpression = "false";
                        eventField.IsArg = true;
                        string eventVar = "var e = this.e;";
                        CreateEventFunction("RootFilter", op.Context, typeof(GameObject), codeType, personalScopeMethod, false, retVal, eventField, eventVar);

                    }
                    else
                        CreateEventFunction("Filter", op.Context, eType, codeType, scopeMethod, false, retVal);
                    //CreateFilterFunction (op.Context as Expression, codeType);

                }
                else if (op.Identifier as string == "event_scope")
                {
                    //It's a filter function
                    //					Debug.Log (op.Context.GetType ());
                    if (ScriptEngine.AnalyzeDebug)
                        Debug.Log((op.Context as Expression).Operands[0].GetType());

                    (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts.Add("true");
                    DeclareVariableStatement retVal = new DeclareVariableStatement();
                    retVal.IsReturn = true;
                    retVal.Name = "applicable";
                    retVal.Type = typeof(bool);
                    retVal.InitExpression = "false";
                    DeclareVariableStatement eventField = new DeclareVariableStatement();
                    eventField.Name = "e";
                    eventField.Type = eType;
                    eventField.InitExpression = "false";
                    eventField.IsArg = true;
                    string eventVar = "var e = this.e;";
                    CreateEventFunction("EventFilter", op.Context, typeof(GameObject), codeType, eventScopeMethod, false, retVal, eventField, eventVar);

                    //CreateFilterFunction (op.Context as Expression, codeType);

                }
                else if (op.Identifier as string == "action")
                {
                    //It's an action function
                    if(isPersonal)
                    {
                        DeclareVariableStatement eventField = new DeclareVariableStatement();
                        eventField.Name = "e";
                        eventField.Type = eType;
                        eventField.InitExpression = "false";
                        eventField.IsArg = true;
                        string eventVar = "var e = this.e;";
                        CreateEventFunction(op.Identifier as string, op.Context, typeof(GameObject), codeType, actionMethod, false, eventField, eventVar);
                    }
                    else
                    CreateEventFunction(op.Identifier as string, op.Context, eType, codeType, actionMethod, false);

                }
            }
            CodeMemberProperty eventRootProp = new CodeMemberProperty();
            eventRootProp.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            CodeMemberField eventRootField = new CodeMemberField();
            eventRootProp.Type = new CodeTypeReference(typeof(Event));
            eventTypeArg.Value = new CodeSnippetExpression("typeof({0})".Fmt(eTypeName));
            eventRootField.Type = new CodeTypeReference(eType);
            codeType.Members.Add(eventRootField);
            codeType.Members.Add(eventRootProp);
            if(isPersonal)
            {
                eventRootProp.Name = "Event";
                eventRootField.Name = "e";
                eventRootProp.GetStatements.Add(new CodeSnippetStatement("return e;"));
                eventRootProp.SetStatements.Add(new CodeSnippetStatement("e = value as {0};".Fmt(eTypeName)));
            }
            else
            {
                eventRootProp.Name = "Root";
                eventRootField.Name = "root";
                eventRootProp.GetStatements.Add(new CodeSnippetStatement("return root;"));
                eventRootProp.SetStatements.Add(new CodeSnippetStatement("root = value as {0};".Fmt(eTypeName)));
            }
        }
       
        CurProgress = MaxProgress;
        foreach (var type in codeTypes)
        {
            cNamespace.Types.Add(type);
        }

        CSharpCodeProvider provider = new CSharpCodeProvider();
        CodeGeneratorOptions options = new CodeGeneratorOptions();
        var writer = new StringWriter();
        provider.GenerateCodeFromNamespace(cNamespace, writer, options);
        Engine.GetPlugin<ScriptCompiler>().AddSource(writer.ToString());

    }


    void CreateEventFunction(string name, object context, Type rootType, CodeTypeDeclaration codeType, MethodInfo baseMethod, bool isAction, params object[] initStatements)
    {
        CodeMemberMethod method = new CodeMemberMethod();
        method.Name = NameTranslator.CSharpNameFromScript(name);
        method.Attributes = MemberAttributes.Override | MemberAttributes.Public;
        method.ReturnType = new CodeTypeReference(baseMethod.ReturnType);
        var args = baseMethod.GetParameters();
        FunctionBlock block = new FunctionBlock(null, method, codeType);
        if (isAction)
            block.Statements.Add("this.state = EventAction.ActionState.Started;");
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
        rootVar.Type = rootType;
        rootVar.IsArg = true;
        rootVar.IsContext = true;

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
        var table = context as Context;
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
        if (isAction)
            block.Statements.Add("this.state = EventAction.ActionState.Finished;");
        method.Statements.Add(new CodeSnippetStatement(block.ToString()));


    }
}


public static class StringFormatExt
{
    public static string Fmt(this string str, params object[] args)
    {
        return string.Format(str, args);
    }
}