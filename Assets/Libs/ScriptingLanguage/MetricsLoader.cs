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

public abstract class Metric
{
    protected GameObject root;
    protected GameObject other;
    public GameObject Root {  get { return root; } set { root = value; } }
    public GameObject Other { get { return other;  } set { other = value; } }
    public virtual void Init()
    {

    }
    public abstract bool RootFilter();
    public abstract float Value();
    public bool OtherFilterFull()
    {
        GameObject cachedRoot = root;
        root = other;
        bool returnValue = OtherFilter();
        root = cachedRoot;
        return returnValue;
    }
    public abstract bool OtherFilter();
    public MetricAttribute Meta { get; set; }

}

public class MetricAttribute : Attribute
{
    public string Category { get; set; }
    public float Weight { get; set; }
}

public class MetricsLoader : ScriptInterpreter
{
    List<CodeTypeDeclaration> codeTypes = new List<CodeTypeDeclaration>();
    FiltersPlugin filters;
    CodeNamespace cNamespace = new CodeNamespace();
    EventFunctionOperators functionOperators;
    ExpressionInterpreter exprInter;

    public MetricsLoader(string namespaceName, ScriptEngine engine) : base(engine)
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
            CodeTypeDeclaration codeType = new CodeTypeDeclaration();
            //codeType.CustomAttributes.
            codeType.BaseTypes.Add(new CodeTypeReference(typeof(Metric)));
            codeType.Name = entry.Identifier as string;
            codeTypes.Add(codeType);

            if (ScriptEngine.AnalyzeDebug)
                Debug.LogWarning((entry.Identifier as string).ToUpper());

            var ctx = entry.Context as Context;
            if (ctx == null)
                continue;
            var scopeMethod = typeof(Metric).GetMethod("RootFilter");
            var otherScopeMethod = typeof(Metric).GetMethod("OtherFilter");
            var valueMethod = typeof(Metric).GetMethod("Value");
            CodeAttributeDeclaration attr = new CodeAttributeDeclaration("MetricAttribute");
            codeType.CustomAttributes.Add(attr);
            CodeAttributeArgument weightArg = new CodeAttributeArgument("Weight", new CodeSnippetExpression("1"));
            attr.Arguments.Add(weightArg);
            FunctionBlock dependenciesBlock = new FunctionBlock(null, null, codeType);
            List<string> deps = new List<string>();
            for (int j = 0; j < ctx.Entries.Count; j++)
            {
                var op = ctx.Entries[j] as Operator;
                if (op == null)
                    continue;
                if (op.Identifier as string == "weight")
                {
                    weightArg.Value = new CodeSnippetExpression((op.Context as InternalDSL.Expression).Operands[0].ToString());

                }
                else if (op.Identifier as string == "category")
                {
                    var cat = (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts[0].ToString();
                    var type = Engine.FindType("ScriptedTypes." + cat);
                    if (type != null)
                    {
                        var props = type.GetProperties();
                        codeType.BaseTypes.Add(type);

                        foreach (var propInfo in props)
                        {
                            var prop = new CodeMemberProperty();
                            prop.HasGet = true;
                            prop.HasSet = true;
                            prop.Name = propInfo.Name;
                            prop.Type = new CodeTypeReference(propInfo.PropertyType);
                            var fieldName = NameTranslator.ScriptNameFromCSharp(prop.Name);
                            prop.GetStatements.Add(new CodeSnippetStatement(String.Format("return {0}; ", fieldName)));
                            prop.SetStatements.Add(new CodeSnippetStatement(String.Format("{0} = value; ", fieldName)));
                            prop.PrivateImplementationType = new CodeTypeReference(type);
                            if (!codeType.UserData.Contains(fieldName))
                            {
                                var field = new CodeMemberField();
                                field.Name = fieldName;
                                field.Type = new CodeTypeReference(propInfo.PropertyType);
                                codeType.Members.Add(field);
                                codeType.UserData.Add(fieldName, field);
                                field.UserData.Add("type", propInfo.PropertyType);
                            }
                            codeType.Members.Add(prop);
                        }
                    }
                    else
                    {

                        if (!cNamespace.UserData.Contains(cat))
                        {
                            CodeTypeDeclaration catInterface = new CodeTypeDeclaration(cat);
                            catInterface.IsInterface = true;
                            cNamespace.Types.Add(catInterface);
                            cNamespace.UserData.Add(cat, catInterface);
                        }
                        codeType.BaseTypes.Add(cat);
                    }
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

                    CreateEventFunction("RootFilter", op.Context, codeType, scopeMethod, false, retVal);
                    //CreateFilterFunction (op.Context as Expression, codeType);

                }
                else if (op.Identifier as string == "other_scope")
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
                    //Debug.Log(otherScopeMethod);
                    CreateEventFunction("OtherFilter", op.Context, codeType, otherScopeMethod, false, retVal);
                    //CreateFilterFunction (op.Context as Expression, codeType);

                }
                else if (op.Identifier as string == "value")
                {
                    DeclareVariableStatement utVal = new DeclareVariableStatement();
                    utVal.IsReturn = true;
                    utVal.Name = "val";
                    utVal.Type = typeof(float);
                    utVal.InitExpression = "0";
                    CreateEventFunction(op.Identifier as string, op.Context, codeType, valueMethod, false, utVal);
                }
                
                else
                {
                    //No idea
                }
            }
            if (deps.Count > 0)
            {
                CodeMemberMethod getDepsOverride = new CodeMemberMethod();
                getDepsOverride.ReturnType = new CodeTypeReference(typeof(List<Dependency>));
                getDepsOverride.Name = "GetDependencies";
                getDepsOverride.Attributes = MemberAttributes.Public | MemberAttributes.Override;
                codeType.Members.Add(getDepsOverride);
                string listName = "list" + DeclareVariableStatement.VariableId++;
                string listOp = String.Format("var {0} = new System.Collections.Generic.List<Dependency>({1});", listName, deps.Count);
                dependenciesBlock.Statements.Add(listOp);
                var addToListBlock = new FunctionBlock(dependenciesBlock);
                foreach (var newDep in deps)
                {
                    addToListBlock.Statements.Add(String.Format("{0}.Add({1});", listName, newDep));
                }
                dependenciesBlock.Statements.Add(addToListBlock);
                dependenciesBlock.Statements.Add(String.Format("return {0};", listName));
                getDepsOverride.Statements.Add(new CodeSnippetStatement(dependenciesBlock.ToString()));

            }
            CodeMemberMethod initOverrideMethod = new CodeMemberMethod();
            initOverrideMethod.Name = "Init";
            initOverrideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            codeType.Members.Add(initOverrideMethod);
            builder.Length = 0;
            builder.Append("base.Init();").AppendLine();
            foreach (var member in codeType.Members)
            {
                var field = member as CodeMemberField;
                if (field != null)
                {
                    builder.Append("this.").Append(field.Name).Append(" = ").Append("default(").Append((field.UserData["type"] as Type).FullName).Append(");").AppendLine();

                }
            }
            initOverrideMethod.Statements.Add(new CodeSnippetStatement(builder.ToString()));

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


    void CreateEventFunction(string name, object context, CodeTypeDeclaration codeType, MethodInfo baseMethod, bool isAction, params object[] initStatements)
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
        block.Statements.Add("var other = this.other;");

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
        rootVar.IsContext = true;

        block.Statements.Add(rootVar);

        var otherVar = new DeclareVariableStatement();
        otherVar.Name = "other";
        otherVar.Type = typeof(GameObject);
        otherVar.IsArg = true;

        block.Statements.Add(otherVar);


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
