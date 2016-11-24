using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InternalDSL;
using System;

public abstract class FunctionOperatorInterpreter
{
	public ScriptEngine Engine;
	protected bool interpret = false;

	public abstract void Interpret (Operator op, FunctionBlock block);

	public abstract bool Match (Operator op, FunctionBlock block);
}

public class EventFunctionOperators : ScriptEnginePlugin
{
	Dictionary<string, FunctionOperatorInterpreter> interpreters = new Dictionary<string, FunctionOperatorInterpreter> ();
	ExpressionInterpreter exprInter;
	ContextSwitchesPlugin switches;

	public override void Init ()
	{
		switches = Engine.GetPlugin<ContextSwitchesPlugin> ();
		exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
	}

	public void AddInterpreter (string name, FunctionOperatorInterpreter inter)
	{
		if (interpreters.ContainsKey (name))
		{
			Debug.LogWarning ("Already has an interpreter " + name);
			return;
		}
		inter.Engine = Engine;
		interpreters.Add (name, inter);
	}

	public FunctionOperatorInterpreter GetInterpreter (Operator op, FunctionBlock block)
	{
		FunctionOperatorInterpreter inter = null;
		if (op.Identifier as string == null)
		{
			exprInter.TransformScopedOperator (op, block);
            if (ScriptEngine.AnalyzeDebug)
                Debug.Log ("Transformed op " + op.ToString ());
		}
		interpreters.TryGetValue (op.Identifier as string, out inter);

		if (inter == null)
		{
			var customVar = block.FindStatement<DeclareVariableStatement> (v => v.Name == (op.Identifier as string));
			if (customVar == null)
			{
				foreach (var interPair in interpreters)
				{
					if (interPair.Value.Match (op, block))
						return interPair.Value;
				}
				var context = block.FindStatement<ContextStatement> (c => (inter = c.InterpretInContext (op, block)) != null);
                if (ScriptEngine.AnalyzeDebug)
                {
                    if (context != null)
                        Debug.LogFormat("{0} is not an operator of context, found one {1}", op.Identifier, context.ContextVar);
                    else
                        Debug.LogWarningFormat("{0} is not an operator of context, not found one", op.Identifier);
                }
                    
//				if (context != null)
//					inter = context.InterpretInContext (op, block);
				if (inter == null && op.Context is Expression)
				{
					VarDeclareInterpreter declInter = new VarDeclareInterpreter ();
					declInter.Inter = exprInter;
					inter = declInter;
				}
			} else
			{
				if (op.Context is Expression)
				{
					VarAssignInterpreter varInter = new VarAssignInterpreter ();
					varInter.Var = customVar;
					varInter.Inter = exprInter;
					inter = varInter;
				} else
				{
					inter = switches.GetInterByType (customVar.Type);



				}
				//if(op.Context is Expression)
					
			}
		}

        if (ScriptEngine.AnalyzeDebug)
            Debug.LogFormat ("{0} - {1}", op, inter);
		return inter;
	}

}

public class VarAssignInterpreter : FunctionOperatorInterpreter
{
	public DeclareVariableStatement Var;
	public ExpressionInterpreter Inter;

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}

	public override void Interpret (Operator op, FunctionBlock block)
	{
		block.Statements.Add (String.Format ("{0} = {1};", Var.Name, Inter.InterpretExpression (op.Context as Expression, block).ExprString));
	}
}

public class VarDeclareInterpreter : FunctionOperatorInterpreter
{
	public ExpressionInterpreter Inter;

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}

	public override void Interpret (Operator op, FunctionBlock block)
	{
		DeclareVariableStatement stmt = new DeclareVariableStatement ();
		stmt.Name = op.Identifier as string;
		var expr = Inter.InterpretExpression (op.Context as Expression, block);
		stmt.InitExpression = expr.ExprString;
		stmt.Type = expr.Type;
        if(ScriptEngine.AnalyzeDebug)
		    Debug.Log (stmt);
		block.Statements.Add (stmt);
	}
}

public class CommonOperatorInterpretators : ScriptEnginePlugin
{
	public override void Init ()
	{
		var types = Engine.FindTypesWithAttribute<CommonFunctionOperatorAttribute> ();
		var operators = Engine.GetPlugin<EventFunctionOperators> ();
		foreach (var type in types)
		{
			operators.AddInterpreter (type.Attribute.Name, Activator.CreateInstance (type.Type) as FunctionOperatorInterpreter);
		}
	}
}


public class CommonFunctionOperatorAttribute : Attribute
{
	public string Name { get; internal set; }

	public CommonFunctionOperatorAttribute (string name)
	{
		Name = name;
	}
}


