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
using CSharpCompiler;

public abstract class LocalisationTag
{
    protected GameObject root;
    public GameObject Root { get { return root; } set { root = value; } }
    protected GameObject from;
    public GameObject From { get { return from; } set { from = value; } }
    public abstract bool Filter();
    public virtual float Utility()
    {
        return 1;
    }
    public abstract string Value();
}

public class LocalisationTagAttribute : Attribute
{
    public string Type { get; set; }
}

public class LocalisationTagsLoader : ScriptInterpreter
{
	List<CodeTypeDeclaration> codeTypes = new List<CodeTypeDeclaration> ();
	FiltersPlugin filters;
	CodeNamespace cNamespace = new CodeNamespace ();
	EventFunctionOperators functionOperators;
	ExpressionInterpreter exprInter;
    ScriptsLoader loader;
    
    public LocalisationTagsLoader(string namespaceName, ScriptEngine engine) : base (engine)
    {
        loader = UnityEngine.Object.FindObjectOfType<ScriptsLoader>();
        cNamespace.Name = namespaceName;
		exprInter = engine.GetPlugin<ExpressionInterpreter> ();
		filters = engine.GetPlugin<FiltersPlugin> ();
		functionOperators = engine.GetPlugin<EventFunctionOperators> ();
	}
    StringBuilder builder = new StringBuilder();
	public override void Interpret (Script script)
	{
		MaxProgress = script.Entries.Count;
		for (int i = 0; i < script.Entries.Count; i++)
		{
			if (!Engine.Working)
				Thread.CurrentThread.Abort ();
			CurProgress = i;
			var entry = script.Entries [i];
			CodeTypeDeclaration codeType = new CodeTypeDeclaration ();
            //codeType.CustomAttributes.
			codeType.BaseTypes.Add (new CodeTypeReference (typeof(LocalisationTag)));
			codeType.Name = entry.Identifier as string + i;
			codeTypes.Add (codeType);

            if (ScriptEngine.AnalyzeDebug)
                Debug.LogWarning((entry.Identifier as string).ToUpper());

            var ctx = entry.Context as Table;
            bool hasValue = false;
            var utMethod = typeof(LocalisationTag).GetMethod("Utility");
            var scopeMethod = typeof(LocalisationTag).GetMethod("Filter");
            var valMethod = typeof(LocalisationTag).GetMethod("Value");
            CodeAttributeDeclaration attr = new CodeAttributeDeclaration("LocalisationTagAttribute");
            codeType.CustomAttributes.Add(attr);
            CodeAttributeArgument typeArg = new CodeAttributeArgument("Type", new CodeSnippetExpression("\"{0}\"".Fmt(entry.Identifier as string)));
            attr.Arguments.Add(typeArg);
            FunctionBlock dependenciesBlock = new FunctionBlock(null, null, codeType);
            if (ctx != null)
            {
                
                for (int j = 0; j < ctx.Entries.Count; j++)
                {
                    var op = ctx.Entries[j] as Operator;
                    if (op != null)
                    {

                        if (op.Identifier as string == "scope")
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

                            CreateEventFunction("Filter", op.Context, codeType, scopeMethod, retVal);
                            //CreateFilterFunction (op.Context as Expression, codeType);

                        }
                        else if (op.Identifier as string == "value")
                        {
                            hasValue = true;
                            DeclareVariableStatement utVal = new DeclareVariableStatement();
                            utVal.IsReturn = true;
                            utVal.Name = "val";
                            utVal.Type = typeof(string);
                            utVal.InitExpression = "\"\"";
                            CreateEventFunction(op.Identifier as string, op.Context, codeType, valMethod, utVal);

                        }
                        else if (op.Identifier as string == "utility")
                        {
                            DeclareVariableStatement utVal = new DeclareVariableStatement();
                            utVal.IsReturn = true;
                            utVal.Name = "ut";
                            utVal.Type = typeof(float);
                            utVal.InitExpression = "0";
                            CreateEventFunction(op.Identifier as string, op.Context, codeType, utMethod, utVal);
                        }
                        else
                        {
                            //No idea
                        }
                    }
                }
            }
            else
            {

                (((entry.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts.Add("true");
                DeclareVariableStatement retVal = new DeclareVariableStatement();
                retVal.IsReturn = true;
                retVal.Name = "applicable";
                retVal.Type = typeof(bool);
                retVal.InitExpression = "false";

                CreateEventFunction("Filter", entry.Context, codeType, scopeMethod, retVal);
            }
            if (!hasValue)
            {
                CodeMemberMethod method = new CodeMemberMethod();
                method.Name = "Value";
                method.Attributes = MemberAttributes.Override | MemberAttributes.Public;
                method.ReturnType = new CodeTypeReference(typeof(string));
                method.Statements.Add(new CodeSnippetStatement("return \"" + entry.Args[0].ToString().ClearFromBraces().Trim(' ') + "\";"));
                codeType.Members.Add(method);
            }
        }
              
		CurProgress = MaxProgress;
		foreach (var type in codeTypes)
		{
			cNamespace.Types.Add (type);
		}
        
		CSharpCodeProvider provider = new CSharpCodeProvider ();
		CodeGeneratorOptions options = new CodeGeneratorOptions ();
		var writer = new StringWriter ();
		provider.GenerateCodeFromNamespace (cNamespace, writer, options);
        Debug.Log(writer.ToString());
        var asm =loader.Load(new string[] { writer.ToString() }, "LocalisationTags");
        if (ScriptEngine.AnalyzeDebug)
            Debug.LogWarning(asm.FullName);
        Engine.AddAssembly(asm);
    }
    

	void CreateEventFunction (string name, object context, CodeTypeDeclaration codeType, MethodInfo baseMethod, params object[] initStatements)
	{
		CodeMemberMethod method = new CodeMemberMethod ();
		method.Name = NameTranslator.CSharpNameFromScript (name);
		method.Attributes = MemberAttributes.Override | MemberAttributes.Public;
		method.ReturnType = new CodeTypeReference (baseMethod.ReturnType);
		var args = baseMethod.GetParameters ();
		FunctionBlock block = new FunctionBlock (null, method, codeType);
		block.Statements.Add ("var root = this.root;");

        block.Statements.Add("var from = this.from;");
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
			block.Statements.Add (initStmt);
		//bool hasRoot = false;
		foreach (var arg in args)
		{
			//if (arg.Name == "root")
			//	hasRoot = true;
			method.Parameters.Add (new CodeParameterDeclarationExpression (arg.ParameterType, arg.Name));
			var paramVar = new DeclareVariableStatement ();
			paramVar.Name = arg.Name;
			paramVar.Type = arg.ParameterType;
			paramVar.IsArg = true;
			block.Statements.Add (paramVar);
		}
		var rootVar = new DeclareVariableStatement ();
		rootVar.Name = "root";
		rootVar.Type = typeof(GameObject);
		rootVar.IsArg = true;
        rootVar.IsContext = true;

        block.Statements.Add (rootVar);
        var fromVar = new DeclareVariableStatement();
        fromVar.Name = "from";
        fromVar.Type = typeof(GameObject);
        fromVar.IsArg = true;
        fromVar.IsContext = false;

        block.Statements.Add(fromVar);

        foreach (var member in codeType.Members)
		{
			var field = member as CodeMemberField;
			if (field != null)
			{
				var cachedVar = new DeclareVariableStatement ();
				cachedVar.Name = field.Name;
				cachedVar.Type = field.UserData ["type"] as Type;
				cachedVar.IsArg = true;

				block.Statements.Add (cachedVar);
			}
		}
		//if (!hasRoot)
		//{
		//	Debug.LogFormat ("Method {0} in {1} has no root arg", baseMethod.Name, codeType.Name);
		//	return;
		//}

		codeType.Members.Add (method);
		var table = context as Table;
		if (table != null)
		{
			foreach (var entry in table.Entries)
			{
				Operator op = entry as Operator;
				var inter = functionOperators.GetInterpreter (op, block);
				if (inter == null)
				{
					Debug.LogFormat ("Can't find interpreter for operator {0} in {1} of {2}", op.Identifier, baseMethod.Name, codeType.Name);
					continue;
				}
				inter.Interpret (op, block);
			}	
			var retVal = block.FindStatement<DeclareVariableStatement> (v => v.IsReturn);
			if (retVal != null)
				block.Statements.Add (String.Format ("return {0};", retVal.Name));
		} else
		{
			var expr = context as Expression;

			var retVal = block.FindStatement<DeclareVariableStatement> (v => v.IsReturn);
			//retVal.IsArg = true;
			block.Statements.Add (String.Format ("return ({1}){0};", exprInter.InterpretExpression (expr, block).ExprString, TypeName.NameOf (retVal.Type)));
		}
        method.Statements.Add (new CodeSnippetStatement (block.ToString ()));

        
    }
}
