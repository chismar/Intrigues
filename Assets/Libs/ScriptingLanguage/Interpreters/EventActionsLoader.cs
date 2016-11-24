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


public abstract class EventAction
{
	public abstract bool Filter ();

	public abstract float Utility ();

	protected GameObject root;

	public GameObject Root { get { return root; } set { root = value; } }
    public EventActionAttribute Meta { get; set;  }
    public virtual void Init ()
	{
		
	}

	public virtual void Action ()
	{

	}
}

public class EventActionAttribute : Attribute
{
    public string Category { get; set; }
    public bool ShouldHaveMaxUtility { get; set; }
    public bool IsInteraction { get; set; }
    public bool OncePerObject { get; set; }
    public bool OncePerTurn { get; set; }
    public bool OnceInCategory { get; set; }
    public string Tooltip { get; set; }
}

public class EventActionsLoader : ScriptInterpreter
{
	List<CodeTypeDeclaration> codeTypes = new List<CodeTypeDeclaration> ();
	FiltersPlugin filters;
	CodeNamespace cNamespace = new CodeNamespace ();
	EventFunctionOperators functionOperators;
	ExpressionInterpreter exprInter;

	public EventActionsLoader (string namespaceName, ScriptEngine engine) : base (engine)
	{
		cNamespace.Name = namespaceName;
		exprInter = engine.GetPlugin<ExpressionInterpreter> ();
		filters = engine.GetPlugin<FiltersPlugin> ();
		functionOperators = engine.GetPlugin<EventFunctionOperators> ();
	}

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
			codeType.BaseTypes.Add (new CodeTypeReference (typeof(EventAction)));
			codeType.Name = entry.Identifier as string;
			codeTypes.Add (codeType);

            if (ScriptEngine.AnalyzeDebug)
                Debug.LogWarning((entry.Identifier as string).ToUpper());

            var ctx = entry.Context as Context;
			if (ctx == null)
				continue;
			var actionMethod = typeof(EventAction).GetMethod ("Action");
			var utMethod = typeof(EventAction).GetMethod ("Utility");
			var scopeMethod = typeof(EventAction).GetMethod ("Filter");
            CodeAttributeDeclaration attr = new CodeAttributeDeclaration("EventActionAttribute");
            codeType.CustomAttributes.Add(attr);
            CodeAttributeArgument maxArg = new CodeAttributeArgument("ShouldHaveMaxUtility", new CodeSnippetExpression("false"));
            CodeAttributeArgument catArg = new CodeAttributeArgument("Category", new CodeSnippetExpression("\"basic\""));
            CodeAttributeArgument onceArg = new CodeAttributeArgument("OncePerObject", new CodeSnippetExpression("false"));
            CodeAttributeArgument oncePerTurnArg = new CodeAttributeArgument("OncePerTurn", new CodeSnippetExpression("false"));
            CodeAttributeArgument interactionArg = new CodeAttributeArgument("IsInteraction", new CodeSnippetExpression("false"));
            CodeAttributeArgument tooltipArg = new CodeAttributeArgument("Tooltip", new CodeSnippetExpression("\"\""));
            CodeAttributeArgument onceInCategory = new CodeAttributeArgument("OnceInCategory", new CodeSnippetExpression("false"));
            attr.Arguments.Add(maxArg);
            attr.Arguments.Add(catArg);
            attr.Arguments.Add(onceArg);
            attr.Arguments.Add(oncePerTurnArg);
            attr.Arguments.Add(interactionArg);
            attr.Arguments.Add(tooltipArg);
            attr.Arguments.Add(onceInCategory);
            for (int j = 0; j < ctx.Entries.Count; j++)
			{
				var op = ctx.Entries [j] as Operator;
				if (op == null)
					continue;
                if (op.Identifier as string == "tooltip")
                {
                    tooltipArg.Value = new CodeSnippetExpression((op.Context as InternalDSL.Expression).Operands[0].ToString());

                } else if (op.Identifier as string == "is_interaction")
                {
                    interactionArg.Value = new CodeSnippetExpression("true");

                }
                else if (op.Identifier as string == "once_per_category")
                {
                    onceInCategory.Value = new CodeSnippetExpression("true");

                }
                else if (op.Identifier as string == "only_max_utility")
                {
                    maxArg.Value = new CodeSnippetExpression((op.Context as InternalDSL.Expression).Operands[0].ToString());
                    
                }
                else if(op.Identifier as string == "category")
                {
                    catArg.Value = new CodeSnippetExpression(String.Format("\"{0}\"", (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts[0]));
                }
                else if (op.Identifier as string == "once_per_object")
                {
                    onceArg.Value = new CodeSnippetExpression("true");
                }
                else if (op.Identifier as string == "once_per_turn")
                {
                    oncePerTurnArg.Value = new CodeSnippetExpression("true");
                }
                else if (op.Identifier as string == "scope")
				{
                    //It's a filter function
                    //					Debug.Log (op.Context.GetType ());
                    if (ScriptEngine.AnalyzeDebug)
                        Debug.Log ((op.Context as Expression).Operands [0].GetType ());

					(((op.Context as Expression).Operands [0] as ExprAtom).Content as Scope).Parts.Add ("true");
					DeclareVariableStatement retVal = new DeclareVariableStatement ();
					retVal.IsReturn = true;
					retVal.Name = "applicable";
					retVal.Type = typeof(bool);
					retVal.InitExpression = "false";

					CreateEventFunction ("Filter", op.Context, codeType, scopeMethod, retVal);
					//CreateFilterFunction (op.Context as Expression, codeType);

				} else if (op.Identifier as string == "action")
				{
					//It's an action function
					CreateEventFunction (op.Identifier as string, op.Context, codeType, actionMethod);
				} else if (op.Identifier as string == "utility")
				{
					DeclareVariableStatement utVal = new DeclareVariableStatement ();
					utVal.IsReturn = true;
					utVal.Name = "ut";
					utVal.Type = typeof(float);
					utVal.InitExpression = "0";
					CreateEventFunction (op.Identifier as string, op.Context, codeType, utMethod, utVal);
				} else
				{
					//No idea
				}
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
		Engine.GetPlugin<ScriptCompiler> ().AddSource (writer.ToString ());

	}

	void CreateFilterFunction (Expression expr, CodeTypeDeclaration codeType)
	{
		if (expr.Operands.Length != 1)
		{
			//Something is wrong
			Debug.LogFormat ("Wrong amount of operands in scope function in {0}", codeType.Name);
			return;
		}
		Scope scope = (expr.Operands [0] as ExprAtom).Content as Scope;
		if (scope == null)
		{
			Debug.LogFormat ("Scope function doesn't contain scope function in {0}", codeType.Name);
			return;
		}
		CodeMemberMethod method = new CodeMemberMethod ();
		method.ReturnType = new CodeTypeReference (typeof(bool));
		method.Parameters.Add (new CodeParameterDeclarationExpression (typeof(GameObject), "go"));

		method.Name = "Filter";
		method.Attributes = MemberAttributes.Override | MemberAttributes.Public;
		for (int i = 0; i < scope.Parts.Count; i++)
		{
			var part = scope.Parts [i];
			if (part is FunctionCall)
			{
				var call = part as FunctionCall;
				var filter = filters.GetFilter (call.Name);
				filter.Interpret (call.Args, method);
			} else
			{

				var filter = filters.GetFilter (part as string);
				filter.Interpret (null, method);
			}
		}
		method.Statements.Add (new CodeSnippetStatement ("return true;"));
		codeType.Members.Add (method);
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

		block.Statements.Add (rootVar);

        
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
		var table = context as Context;
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
