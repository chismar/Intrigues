using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using InternalDSL;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Text;



public class ContextSwitchesPlugin : ScriptEnginePlugin
{
	//Dictionary<string, ContextSwitchInterpreter> inters = new Dictionary<string, ContextSwitchInterpreter> ();
	Dictionary<string, Type> components = new Dictionary<string, Type> ();
	Dictionary<Type, FunctionOperatorInterpreter> intersByType = new Dictionary<Type, FunctionOperatorInterpreter> ();

	public void AddInterToType (Type type, FunctionOperatorInterpreter inter)
	{
		if (!intersByType.ContainsKey (type))
			intersByType.Add (type, inter);
        if(type == typeof(GameObject) && inter.GetType() == typeof(ContextSwitchInterpreter))
        {
            if (!intersByType.ContainsKey(type))
                intersByType.Add(type, inter);
            else
                intersByType[type] = inter;
        }
            
    }

	public FunctionOperatorInterpreter GetInterByType (Type type)
	{
		if (intersByType.ContainsKey (type))
			return intersByType [type];
		return null;
	}

	public Type GetContext (string name)
	{
		Type contextType = null;
		components.TryGetValue (name, out contextType);
		return contextType;
	}

	EventFunctionOperators ops;

	public void AddCmp (Type cmp)
	{
		ContextSwitchInterpreter inter = new ContextSwitchInterpreter (cmp, Engine);
		Debug.Log ("context " + inter.Engine);
		ops.AddInterpreter (NameTranslator.ScriptNameFromCSharp (cmp.Name), inter);
	}

	public override void Init ()
	{
		ops = Engine.GetPlugin<EventFunctionOperators> ();
		var components = Engine.FindTypesCastableTo<MonoBehaviour> ();
		MaxProgress = components.Count;
		foreach (var cmp in components)
		{
			CurProgress++;
			ContextSwitchInterpreter inter = new ContextSwitchInterpreter (cmp, Engine);
            //if (ScriptEngine.AnalyzeDebug)
            //    Debug.Log ("context " + inter.Engine);
			ops.AddInterpreter (NameTranslator.ScriptNameFromCSharp (cmp.Name), inter);
		}
		CurProgress = MaxProgress;
		var goInter = new ContextSwitchInterpreter (typeof(GameObject), Engine);
	}
}

public class ContextStatement
{
	public DeclareVariableStatement ContextVar;
	public Func<Operator, FunctionBlock, FunctionOperatorInterpreter> InterpretInContext;

	public override string ToString ()
	{
		if (ContextVar != null)
			return String.Format ("//ContextStatement {0} {1} {2}", ContextVar.Type, ContextVar.Name, InterpretInContext.Target);
		else
			return String.Format ("//ContextStatement {0}", InterpretInContext.Target);
	}
}

public class ContextSwitchInterpreter : FunctionOperatorInterpreter
{
	EventFunctionOperators ops;

	public override void Interpret (Operator op, FunctionBlock block)
	{
		if (ops == null)
			ops = Engine.GetPlugin<EventFunctionOperators> ();
		FunctionBlock contextBlock = new FunctionBlock (block, block.Method, block.Type);
		block.Statements.Add (contextBlock);
		DeclareVariableStatement addVar = block.FindStatement<DeclareVariableStatement> (v => v.Name == op.Identifier as string);
        bool setContext = false;
		if (addVar != null && !addVar.IsContext)
			setContext = addVar.IsContext = true;
		if (addVar == null)
			addVar = block.FindStatement<DeclareVariableStatement> (v => v.IsContext && v.Type == contextType);
		//TODO: probably will fail
		DeclareVariableStatement contextVar = contextType == typeof(GameObject)? addVar : block.FindStatement<DeclareVariableStatement> (v => v.IsContext && v.Type == typeof(GameObject) && v != addVar);
		DeclareVariableStatement declareVar = null;
		if (addVar == null)
		{
			declareVar = new DeclareVariableStatement ();
			declareVar.Type = contextType;
			declareVar.Name = "subContext" + DeclareVariableStatement.VariableId++;
			declareVar.IsContext = true;

			if (contextVar == null)
				declareVar.InitExpression = String.Format ("({0})root.GetComponent(typeof({0}))", contextType);
			else
				declareVar.InitExpression = String.Format ("({0}){1}.GetComponent(typeof({0}))", contextType, contextVar.Name);
			contextBlock.Statements.Add (declareVar);

		} else
			declareVar = addVar;

		contextBlock.Statements.Add (new ContextStatement () {
			ContextVar = declareVar,
			InterpretInContext = InterpretInContext
		});
		IfStatement isNotNull = new IfStatement ();
		isNotNull.CheckExpression = String.Format ("{0} != null", declareVar.Name);
		isNotNull.TrueBlock = new FunctionBlock (contextBlock);
        contextBlock.Statements.Add(isNotNull);
		contextBlock = isNotNull.TrueBlock;
        contextBlock.Statements.Add(new DeclareVariableStatement() { Name = declareVar.Name, IsArg = true, IsContext = true, Type = declareVar.Type});
		foreach (var entry in (op.Context as Context).Entries)
		{
			var subOp = entry as Operator;
			if (subOp == null)
				continue;
			FunctionOperatorInterpreter opInter = null;

			if ((opInter = ops.GetInterpreter (subOp, contextBlock)) == null)
			if (!contextSwitches.TryGetValue (subOp.Identifier as string, out opInter))
			if (!functions.TryGetValue (subOp.Identifier as string, out opInter))
			if (!properties.TryGetValue (subOp.Identifier as string, out opInter))
			{
				Debug.LogWarningFormat ("Can't interpret context operator {1} in {0}", block.Method.Name, subOp.Identifier);
				continue;
                        }
            if (ScriptEngine.AnalyzeDebug)
                Debug.LogFormat ("Interpret {0} via {1}", subOp.Identifier, opInter);
			opInter.Interpret (subOp, contextBlock);
		}

		if (setContext)
			addVar.IsContext = false;

	}

	public FunctionOperatorInterpreter InterpretInContext (Operator op, FunctionBlock block)
    {
        if (ScriptEngine.AnalyzeDebug)
            Debug.Log ("interpret in context");
		FunctionOperatorInterpreter opInter = null;
		if (!contextSwitches.TryGetValue (op.Identifier as string, out opInter))
		if (!functions.TryGetValue (op.Identifier as string, out opInter))
		if (!properties.TryGetValue (op.Identifier as string, out opInter))
		{
            if(ScriptEngine.AnalyzeDebug)
			Debug.LogWarningFormat ("Can't interpret context operator {1} in {0} by switch - {2}", block.Method.Name, op.Identifier, contextType);
			return null;
		}
		return opInter;
	}

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}

	Type contextType;

	Dictionary<string, FunctionOperatorInterpreter> contextSwitches = new Dictionary<string, FunctionOperatorInterpreter> ();
	Dictionary<string, FunctionOperatorInterpreter> functions = new Dictionary<string, FunctionOperatorInterpreter> ();
	Dictionary<string, FunctionOperatorInterpreter> properties = new Dictionary<string, FunctionOperatorInterpreter> ();
	Dictionary<string, FunctionOperatorInterpreter> other = new Dictionary<string, FunctionOperatorInterpreter> ();

	public ContextSwitchInterpreter (Type type, ScriptEngine engine)
	{
		this.Engine = engine;
		engine.GetPlugin<ContextSwitchesPlugin> ().AddInterToType (type, this);
        //if (ScriptEngine.AnalyzeDebug)
        //    Debug.Log ("Context switch " + type);
		contextType = type;
		if (type == typeof(GameObject))
			return;
		var props = type.GetProperties (BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
		var methods = type.GetMethods (BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
		foreach (var prop in props)
		{
			//Debug.Log (prop.Name);
			if (prop.PropertyType != typeof(string) && (prop.PropertyType.IsClass || (prop.PropertyType.IsValueType && !prop.PropertyType.IsEnum &&
			    prop.PropertyType != typeof(bool) && prop.PropertyType != typeof(float) && prop.PropertyType != typeof(int))) &&
			    !(prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition () == typeof(List<>)))
			{
				ContextPropertySwitchInterpreter inter = new ContextPropertySwitchInterpreter (prop.Name, prop.PropertyType, engine);
				contextSwitches.Add (NameTranslator.ScriptNameFromCSharp (prop.Name), inter);

				inter.Engine = Engine;
                //if (ScriptEngine.AnalyzeDebug)
                //    Debug.Log ("SubContext " + NameTranslator.ScriptNameFromCSharp (prop.Name));
			} else
			{
				ContextPropertyInterpreter inter = new ContextPropertyInterpreter (prop.Name, prop.PropertyType, Engine);
				inter.Engine = Engine;
                //if (ScriptEngine.AnalyzeDebug)
                //    Debug.Log (inter.Engine);
				properties.Add (NameTranslator.ScriptNameFromCSharp (prop.Name), inter);
                //if (ScriptEngine.AnalyzeDebug)
                //    Debug.Log (NameTranslator.ScriptNameFromCSharp (prop.Name));
			}

		}

		foreach (var method in methods)
		{
			if (method.GetCustomAttributes (typeof(CompilerGeneratedAttribute), false).Length > 0)
				continue;
           // if (ScriptEngine.AnalyzeDebug)
           //     Debug.Log ("Context method " + method.Name);
			ContextFunctionCallInterpreter inter = new ContextFunctionCallInterpreter (method, Engine);
			functions.Add (NameTranslator.ScriptNameFromCSharp (method.Name), inter);
		}
	}


}




public class ContextFunctionCallInterpreter : FunctionOperatorInterpreter
{
	ParameterInfo[] argsDef;
	string funcName;
	ExpressionInterpreter exprInter;
	Type returnType;
	ContextPropertySwitchInterpreter ctxInter;
	ContextSwitchesPlugin switches;
	FunctionOperatorInterpreter addContextInter = null;
	EventFunctionOperators ops;

	public ContextFunctionCallInterpreter (MethodInfo method, ScriptEngine engine)
	{
		ops = engine.GetPlugin<EventFunctionOperators> ();
		switches = engine.GetPlugin<ContextSwitchesPlugin> ();
		argsDef = method.GetParameters ();
		if (argsDef.Length > 0)
			addContextInter = switches.GetInterByType (argsDef [argsDef.Length - 1].ParameterType);
		Engine = engine;
		returnType = method.ReturnType;
		if (returnType != typeof(void) && returnType != typeof(string) && (returnType.IsClass || (returnType.IsValueType && !returnType.IsEnum &&
		    returnType != typeof(bool) && returnType != typeof(float) && returnType != typeof(int))) &&
		    !(returnType.IsGenericType && returnType.GetGenericTypeDefinition () == typeof(List<>)))
		{
			ctxInter = new ContextPropertySwitchInterpreter ("", returnType, engine);
		}
		funcName = method.Name;
	}

	public override void Interpret (Operator op, FunctionBlock block)
    {
        if (ScriptEngine.AnalyzeDebug)
            Debug.LogWarning ("Context function " + op.Identifier);
		if (exprInter == null)
			exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		var any = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;
		var sCtx = block.FindStatement<ContextStatement> (v => v.InterpretInContext (op, block) != null && (v.ContextVar.IsContext || v.ContextVar.IsArg));
		var contextVar = sCtx != null ? sCtx.ContextVar : null;
		//var contextVar = block.FindStatement<DeclareVariableStatement> (v => );

		StringBuilder argsBuilder = new StringBuilder ();
//		if (((op.Context is Expression) && op.Args.Count + 1 != argsDef.Length) ||
//		    ((op.Context is Context) && op.Args.Count != argsDef.Length))
//		{
//			Debug.Log ("Wrong amount of arguments");
//			return;
//		}
		for (int i = 0; i < op.Args.Count; i++)
		{
			if (argsDef [i].ParameterType.IsSubclassOf (typeof(Delegate)))
				argsBuilder.Append (exprInter.InterpretClosure (op.Args [i], block, argsDef [i].ParameterType).ExprString).Append (",");
			else if (argsDef [i].ParameterType == typeof(string))
				argsBuilder.Append ('(').Append (exprInter.InterpretExpression (op.Args [i], block).ExprString).Append (')').Append (".ToString()").Append (",");
			else
				argsBuilder.Append ('(').Append (argsDef [i].ParameterType).Append (')').Append ('(').Append (exprInter.InterpretExpression (op.Args [i], block).ExprString).Append (')').Append (",");
			
		}
		if (op.Context is Expression)
		{
			if (argsDef [argsDef.Length - 1].ParameterType.IsSubclassOf (typeof(Delegate)))
				argsBuilder.
				Append ('(').
				Append (argsDef [argsDef.Length - 1].ParameterType).
				Append (')').
				Append ('(').
				Append (exprInter.InterpretClosure (op.Context as Expression, block, argsDef [argsDef.Length - 1].ParameterType).ExprString).
				Append (')');
			else if (argsDef [argsDef.Length - 1].ParameterType == typeof(string))
				argsBuilder.Append ('(').Append (exprInter.InterpretExpression (op.Context as Expression, block).ExprString).Append (')').Append (".ToString()");
			else
				argsBuilder.
				Append ('(').
				Append (argsDef [argsDef.Length - 1].ParameterType).
				Append (')').
				Append ('(').
				Append (exprInter.InterpretExpression (op.Context as Expression, block).ExprString).
				Append (')');
			if (contextVar == null)
				block.Statements.Add (string.Format ("root.{0}({1});", funcName, argsBuilder));
			else
				block.Statements.Add (string.Format ("{2}.{0}({1});", funcName, argsBuilder, contextVar.Name));
		} else if (ctxInter != null)
		{
			if (op.Args.Count > 0)
				argsBuilder.Length -= 1;
			var ctx = op.Context as Context;
			FunctionBlock contextBlock = new FunctionBlock (block);
			block.Statements.Add (contextBlock);
			block = contextBlock;
			DeclareVariableStatement ctxVar = new DeclareVariableStatement ();
			ctxVar.Name = "FuncCtx" + DeclareVariableStatement.VariableId++;
			ctxVar.InitExpression = contextVar == null ? string.Format ("root.{0}({1});", funcName, argsBuilder) : string.Format ("{2}.{0}({1});", funcName, argsBuilder, contextVar.Name);
			ctxVar.Type = returnType;
			ctxVar.IsContext = true;

			ContextStatement stmt = new ContextStatement ();
			stmt.ContextVar = ctxVar;
			stmt.InterpretInContext = ctxInter.InterpretInContext;
			block.Statements.Add (ctxVar);
			block.Statements.Add (stmt);
			IfStatement isNotNull = new IfStatement ();
			isNotNull.CheckExpression = String.Format ("{0} != null", ctxVar.Name);
			isNotNull.TrueBlock = new FunctionBlock (block);
			block.Statements.Add (isNotNull);
			block = isNotNull.TrueBlock;
			for (int i = 0; i < ctx.Entries.Count; i++)
			{
				ops.GetInterpreter (ctx.Entries [i] as Operator, block).Interpret (ctx.Entries [i] as Operator, block);
			}
		} else
		{
			//Func doesn't return a context, while maybe allows for either lambda as value or context addition
			var lastArg = argsDef.Length > 0 ? argsDef [argsDef.Length - 1] : null;
            if(lastArg != null)
			if (typeof(Delegate).IsAssignableFrom (lastArg.ParameterType))
			{

				Debug.Log ("LAMBDA!");
				//Interpret as lambda
				LambdaStatement lambda = new LambdaStatement ();
				lambda.DelegateType = lastArg.ParameterType;
				var method = lastArg.ParameterType.GetMethod ("Invoke");
				lambda.Params = method.GetParameters ();
				lambda.Name = "Lambda" + DeclareVariableStatement.VariableId++;
				block.Statements.Add (lambda);
				lambda.Block = new FunctionBlock (block);

				//DeclareVariableStatement lastVar = null;
				foreach (var param in lambda.Params)
				{
					var argVar = new DeclareVariableStatement ();
					//	lastVar = argVar;
					argVar.Name = param.Name;
					argVar.IsArg = true;
					argVar.Type = param.ParameterType;
					lambda.Block.Statements.Add (argVar);
				}
				//if (lastVar != null)
				//	lastVar.IsContext = true;

				var retType = lambda.DelegateType.GetMethod ("Invoke").ReturnType;
				bool hasReturn = false;
				if (retType != null && retType != typeof(void))
				{
					hasReturn = true;
					lambda.Block.Statements.Add (new DeclareVariableStatement () {
						Name = "return_value",
						InitExpression = string.Format ("default({0})", retType),
						IsReturn = true,
						Type = retType
					});
				}

				foreach (var entry in (op.Context as Context).Entries)
				{
					var subOp = entry as Operator;
					ops.GetInterpreter (subOp, lambda.Block).Interpret (subOp, lambda.Block);
				}
				if (hasReturn)
					lambda.Block.Statements.Add ("return return_value;");
				//Don't forget to call a function and add an arugment
				argsBuilder.Append (lambda.Name);
				if (contextVar == null)
					block.Statements.Add (string.Format ("root.{0}({1});", funcName, argsBuilder));
				else
					block.Statements.Add (string.Format ("{2}.{0}({1});", funcName, argsBuilder, contextVar.Name));
			} else if (addContextInter != null)
			{
				//Interpret as new value
				DeclareVariableStatement newVar = new DeclareVariableStatement ();
				newVar.Name = "NewArg" + DeclareVariableStatement.VariableId++;
				newVar.IsContext = true;
				newVar.Type = lastArg.ParameterType;
				if (contextVar == null)
					newVar.InitExpression = String.Format ("root.AddComponent<{0}>()", newVar.Type);
				else
					newVar.InitExpression = String.Format ("{0}.AddComponent<{0}>()", contextVar.Name, newVar.Type);
				FunctionBlock contextBlock = new FunctionBlock (block);
				contextBlock.Statements.Add (newVar);
				addContextInter.Interpret (op, contextBlock);
				argsBuilder.Append (newVar.Name);
				if (contextVar == null)
					contextBlock.Statements.Add (string.Format ("root.{0}({1});", funcName, argsBuilder));
				else
					contextBlock.Statements.Add (string.Format ("{2}.{0}({1});", funcName, argsBuilder, contextVar.Name));
			
				block.Statements.Add (contextBlock);
			}
		}
			


		
	
	}

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}

}

public class ContextPropertyInterpreter : FunctionOperatorInterpreter
{
	ExpressionInterpreter exprInter;
	EventFunctionOperators ops;
	ContextSwitchesPlugin switches;

	public override void Interpret (Operator op, FunctionBlock block)
	{
        interpret = false;
		if (exprInter == null)
		{
			switches = Engine.GetPlugin<ContextSwitchesPlugin> ();
			ops = Engine.GetPlugin<EventFunctionOperators> ();
			exprInter = Engine.GetPlugin<ExpressionInterpreter> ();
		}

		var varName = op.Identifier as string;

        if (ScriptEngine.AnalyzeDebug)
            Debug.Log (block);
		var sCtx = block.FindStatement<ContextStatement> (v => v.InterpretInContext (op, block) != null && v.ContextVar.IsContext || v.ContextVar.IsArg);
		var context = sCtx != null ? sCtx.ContextVar : null;
        if (ScriptEngine.AnalyzeDebug)
            Debug.LogFormat ("FOUND COUNTEXT {0} for {1}", context, op.Identifier);
		if (listT == null)
		{
			if (!(op.Context is Expression))
				return;
            if (ScriptEngine.AnalyzeDebug)
                Debug.Log ("PROPERTY " + propName);
			if (context == null)
				block.Statements.Add (String.Format ("root.{0} = ({2})({1});", propName, exprInter.InterpretExpression (op.Context as Expression, block).ExprString, TypeName.NameOf (propType)));
			else
				block.Statements.Add (String.Format ("{2}.{0} = ({3})({1});", propName, exprInter.InterpretExpression (op.Context as Expression, block).ExprString, context.Name, TypeName.NameOf (propType)));
			
		} else
		{
			Debug.Log ("list of" + listT);
			ForStatement statement = new ForStatement ();
			string listVarName = context == null ? "root." + propName : context.Name + "." + propName;
			string iterName = "i" + DeclareVariableStatement.VariableId++;
			statement.InsideExpr = String.Format ("int {0} = 0; {1} != null && {0} < {1}.Count; {0}++", iterName,
			                                      listVarName);
			FunctionBlock repeatBlock = new FunctionBlock (block, block.Method, block.Type);
			statement.RepeatBlock = repeatBlock;
			block.Statements.Add (statement);
			Operator listVarOp = new Operator ();

			DeclareVariableStatement listVar = new DeclareVariableStatement ();
			listVar.Name = "iter" + DeclareVariableStatement.VariableId++;
			listVar.IsContext = true;
			listVar.IsNew = true;
			listVar.Type = listT;
			listVar.InitExpression = String.Format ("{0}[{1}]", listVarName, iterName);

			statement.RepeatBlock.Statements.Add (listVar);
			var inter = switches.GetInterByType (listT);
            //Debug.Log(inter);
			inter.Interpret (op, repeatBlock);
		}
		interpret = true;
	}

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}

	protected Type propType;
	protected string propName;
	Type listT = null;

	public ContextPropertyInterpreter (string propName, Type type, ScriptEngine engine)
	{
		
		if (type.IsGenericType && type.GetGenericTypeDefinition () == typeof(List<>))
		{
            //Debug.Log("List " + propName);
			listT = type.GetGenericArguments () [0];
			engine.GetPlugin<ContextSwitchesPlugin> ().AddInterToType (type, this);
		}

		Engine = engine;
		this.propName = propName;
		propType = type;
	}
}

public class ContextPropertySwitchInterpreter : ContextPropertyInterpreter
{
	struct PropKey
	{
		public Type Type;
		public string Name;

		public PropKey (Type type, string name)
		{
			Type = type;
			Name = name;
		}

		public override int GetHashCode ()
		{
			return Type.GetHashCode () + Name.GetHashCode ();
		}

		public override bool Equals (object obj)
		{
			try
			{
				var key = (PropKey)obj;
				return key.Type == this.Type && key.Name == this.Name;
			} catch
			{
				return false;
			}
		}
	}

	static Dictionary<PropKey, ContextPropertySwitchInterpreter> allPropSwitches = new Dictionary<PropKey, ContextPropertySwitchInterpreter> ();
	//	static Dictionary<Type, ContextPropertySwitchInterpreter> switchesByType = new Dictionary<Type, ContextPropertySwitchInterpreter> ();
	//
	//	public static ContextPropertySwitchInterpreter GetSwitch (Type t)
	//	{
	//		ContextPropertySwitchInterpreter inter = null;
	//		if (!switchesByType.TryGetValue (t, out inter))
	//		{
	//
	//
	//		}
	//		return inter;
	//	}

	public ContextPropertySwitchInterpreter (string propName, Type type, ScriptEngine engine) : base (propName, type, engine)
	{
		engine.GetPlugin<ContextSwitchesPlugin> ().AddInterToType (type, this);
		this.propName = propName;
		propType = type;
		this.Engine = engine;
       // if (ScriptEngine.AnalyzeDebug)
      //      Debug.Log ("Context switch " + type);
		var props = type.GetProperties (BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		var methods = type.GetMethods (BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
       // if (ScriptEngine.AnalyzeDebug)
       //     Debug.Log ("Methods count " + methods.Length);
		var thisKey = new PropKey (type, propName);
		if (!allPropSwitches.ContainsKey (thisKey))
			allPropSwitches.Add (thisKey, this);
		if (typeof(MonoBehaviour).IsAssignableFrom (type) && type != typeof(MonoBehaviour))
        {
            //if (ScriptEngine.AnalyzeDebug)
            //    Debug.Log ("It's a component! " + type);
			foreach (var prop in props)
			{
				//Debug.Log (prop.Name);
				if (prop.PropertyType != typeof(string) && (prop.PropertyType.IsClass || (prop.PropertyType.IsValueType && !prop.PropertyType.IsEnum &&
				    prop.PropertyType != typeof(bool) && prop.PropertyType != typeof(float) && prop.PropertyType != typeof(int))))
				{
					var key = new PropKey (prop.PropertyType, prop.Name);
					if (allPropSwitches.ContainsKey (key))
						contextSwitches.Add (NameTranslator.ScriptNameFromCSharp (prop.Name), allPropSwitches [key]);
					else
					{
						ContextPropertySwitchInterpreter inter = new ContextPropertySwitchInterpreter (prop.Name, prop.PropertyType, engine);
						contextSwitches.Add (NameTranslator.ScriptNameFromCSharp (prop.Name), inter);

						inter.Engine = Engine;
					}

                   // if (ScriptEngine.AnalyzeDebug)
                  //      Debug.Log ("SubContext " + NameTranslator.ScriptNameFromCSharp (prop.Name));
				} else
				{
					ContextPropertyInterpreter inter = new ContextPropertyInterpreter (prop.Name, prop.PropertyType, engine);
					inter.Engine = Engine;
                  //  if (ScriptEngine.AnalyzeDebug)
                  //      Debug.Log (inter.Engine);
					properties.Add (NameTranslator.ScriptNameFromCSharp (prop.Name), inter);
                 //   if (ScriptEngine.AnalyzeDebug)
                  //      Debug.Log (NameTranslator.ScriptNameFromCSharp (prop.Name));
				}

			}

			foreach (var method in methods)
			{
				if (method.GetCustomAttributes (typeof(CompilerGeneratedAttribute), false).Length > 0)
					continue;
               // if (ScriptEngine.AnalyzeDebug)
                //    Debug.Log ("Context method " + method.Name);
				ContextFunctionCallInterpreter inter = new ContextFunctionCallInterpreter (method, Engine);
				functions.Add (NameTranslator.ScriptNameFromCSharp (method.Name), inter);
			}
		}

	}

	EventFunctionOperators ops;
	Dictionary<string, FunctionOperatorInterpreter> contextSwitches = new Dictionary<string, FunctionOperatorInterpreter> ();
	Dictionary<string, FunctionOperatorInterpreter> functions = new Dictionary<string, FunctionOperatorInterpreter> ();
	Dictionary<string, FunctionOperatorInterpreter> properties = new Dictionary<string, FunctionOperatorInterpreter> ();
	Dictionary<string, FunctionOperatorInterpreter> other = new Dictionary<string, FunctionOperatorInterpreter> ();

	public override void Interpret (Operator op, FunctionBlock block)
	{
		base.Interpret (op, block);
		if (interpret)
        {

            if (ScriptEngine.AnalyzeDebug)
                Debug.LogFormat("Property {0} was interpreted by ContextPropertyInterpreter {1} already", op, propName);
            return;
        }
		if (!(op.Context is Context))
        {

            if (ScriptEngine.AnalyzeDebug)
                Debug.LogFormat("Property context switch {0} has no context", op);
            return;
        }
        if (ops == null)
			ops = Engine.GetPlugin<EventFunctionOperators> ();
		var varName = op.Identifier as string;

		FunctionBlock contextBlock = new FunctionBlock (block, block.Method, block.Type);
		block.Statements.Add (contextBlock);
		DeclareVariableStatement declareVar = new DeclareVariableStatement ();
		declareVar.Type = propType;
		declareVar.Name = "subContext" + DeclareVariableStatement.VariableId++;
		declareVar.IsContext = true;

		DeclareVariableStatement contextVar = block.FindStatement<DeclareVariableStatement> (v => v.Name == varName);
		if (contextVar == null)
		{
			var sCtx = block.FindStatement<ContextStatement> (v => v.InterpretInContext (op, block) != null && v.ContextVar.IsContext);
			contextVar = sCtx != null ? sCtx.ContextVar : null;
		}

		if (contextVar == null)
			declareVar.InitExpression = String.Format ("root.{0}", propName);
		else
			declareVar.InitExpression = String.Format ("{1}.{0}", propName, contextVar.Name);
		contextBlock.Statements.Add (declareVar);
		contextBlock.Statements.Add (new ContextStatement () {
			ContextVar = declareVar,
			InterpretInContext = InterpretInContext
		});
		IfStatement isNotNull = new IfStatement ();
		isNotNull.CheckExpression = String.Format ("{0} != null", declareVar.Name);
		isNotNull.TrueBlock = new FunctionBlock (contextBlock);
		contextBlock.Statements.Add (isNotNull);
		contextBlock = isNotNull.TrueBlock;
		foreach (var entry in (op.Context as Context).Entries)
		{
            //Debug.LogFormat("Interpreting {0} as part of {1} context", (entry as Operator).Identifier, op.Identifier);
			var subOp = entry as Operator;
			if (subOp == null)
				continue;
			FunctionOperatorInterpreter opInter = null;
			if ((opInter = ops.GetInterpreter (subOp, contextBlock)) == null)
			if (!contextSwitches.TryGetValue (subOp.Identifier as string, out opInter))
			if (!functions.TryGetValue (subOp.Identifier as string, out opInter))
			if (!properties.TryGetValue (subOp.Identifier as string, out opInter))
			{
				//Debug.LogFormat ("Can't interpret context operator {1} in {0}", block.Method.Name, subOp.Identifier);
				continue;
			}
			opInter.Interpret (subOp, contextBlock);
		}

	}

	public FunctionOperatorInterpreter InterpretInContext (Operator op, FunctionBlock block)
	{
		//Debug.Log ("interpret in context");
		FunctionOperatorInterpreter opInter = null;
		if (!contextSwitches.TryGetValue (op.Identifier as string, out opInter))
		if (!functions.TryGetValue (op.Identifier as string, out opInter))
		if (!properties.TryGetValue (op.Identifier as string, out opInter))
                {
                    if (ScriptEngine.AnalyzeDebug)
                        Debug.LogFormat ("Can't interpret context operator {1} in {0}", block.Method.Name, op.Identifier);
			return null;
		}
		return opInter;
	}

	public override bool Match (Operator op, FunctionBlock block)
	{
		return false;
	}
	
}