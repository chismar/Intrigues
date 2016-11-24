using UnityEngine;
using System.Collections;
using InternalDSL;
using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;


public class ExpressionInterpreter : ScriptEnginePlugin
{
	Dictionary<string, Type> components = new Dictionary<string, Type> ();
	Dictionary<string, ScopeInterpreter> scopeInterpreters = new Dictionary<string, ScopeInterpreter> ();

	public override void Init ()
	{
		var cmpTypes = Engine.FindTypesCastableTo<MonoBehaviour> ();
		foreach (var cmp in cmpTypes)
		{
			string scriptName = NameTranslator.ScriptNameFromCSharp (cmp.Name);
			components.Add (scriptName, cmp);
			HasComponentScope scope = new HasComponentScope ();
			scope.Type = cmp;
			scope.ExprInter = this;
			scopeInterpreters.Add ("has_" + scriptName, scope);
			scope.Engine = this.Engine;
		}

		var specTypes = Engine.FindTypesWithAttribute<ScopeInterpreterAttribute> ();
		foreach (var specType in specTypes)
		{
			ScopeInterpreter inter = Activator.CreateInstance (specType.Type) as ScopeInterpreter;
			inter.Engine = this.Engine;
			inter.ExprInter = this;
			scopeInterpreters.Add (specType.Attribute.Name, inter);
		}

		//string closure = InterpretClosure ();
	}

	public struct Expr
	{
		public string ExprString;
		public Type Type;
	}

	public Operator InterpretScope (Scope scope, FunctionBlock block)
	{
		Operator op = new Operator ();
		op.Identifier = scope;
		op.Context = new Context ();

		return op;
	}

	public Stack<DeclareVariableStatement> CleanUpContextes = new Stack<DeclareVariableStatement> ();

	public Expr InterpretScopedList (Scope scope, FunctionBlock block)
	{
		FunctionBlock listBlock = new FunctionBlock (block, block.Method, block.Type);
		block.Statements.Add (listBlock);
		var listVar = new DeclareVariableStatement ();
		listVar.Name = "scopedList" + DeclareVariableStatement.VariableId++;
		//listVar.InitExpression = 



		return new Expr ();
	}

	public void TransformScopedOperator (Operator op, FunctionBlock block)
	{
		var scope = op.Identifier as Scope;
		var endContext = op.Context;
		Operator curOp = null;
		for (int i = 0; i < scope.Parts.Count; i++)
		{
			var part = scope.Parts [i];
			Operator subOp = new Operator ();
			if (part is string)
			{
				var opId = part as string;
				subOp.Identifier = opId;
			} else
			{
				var call = part as FunctionCall;
				subOp.Identifier = call.Name;
				subOp.Args = new List<Expression> ();
				for (int j = 0; j < call.Args.Length; j++)
				{
					subOp.Args.Add (call.Args [j]);
				}
			}
			if (curOp == null)
			{
				op.Args = subOp.Args;
				op.Context = subOp.Context;
				op.Identifier = subOp.Identifier;
				curOp = op;
			} else
			{
				var ctx = new Context ();
				curOp.Context = ctx;
				ctx.Entries.Add (subOp);
				curOp = subOp;
			}

				

			subOp.Init ();
		}
		curOp.Context = endContext;
	}

	public Expr InterpretClosure (Expression expression, FunctionBlock block, Type closureType)
	{
		//Debug.LogFormat ("Interpret {0} as closure", expression);
		StringBuilder closureBuilder = new StringBuilder ();
		var methodInfo = closureType.GetMethod ("Invoke");
		var args = methodInfo.GetParameters ();
		FunctionBlock lambdaBlock = new FunctionBlock (block, block.Method, block.Type);
		lambdaBlock.DefaultScope = args [0].Name;

		closureBuilder.Append ("(");
		DeclareVariableStatement lastArg = null;
		foreach (var param in args)
		{
			var argVar = new DeclareVariableStatement ();
			lastArg = argVar;
			argVar.Name = param.Name;
			argVar.IsArg = true;
			argVar.Type = param.ParameterType;
			lambdaBlock.Statements.Add (argVar);
			closureBuilder.Append (param.ParameterType).Append (" ").Append (param.Name).Append (",");
		}
		if (lastArg != null)
			lastArg.IsContext = true;
		if (closureBuilder [closureBuilder.Length - 1] == ',')
			closureBuilder.Length -= 1;
		closureBuilder.Append (")=>{");
		var internals = InterpretExpression (expression, lambdaBlock);
		foreach (var statement in lambdaBlock.Statements)
			closureBuilder.Append (statement).Append (";").Append (Environment.NewLine);
		if (methodInfo.ReturnType != null)
			closureBuilder.Append ("return ");
		closureBuilder.Append (internals.ExprString).Append (";");
		closureBuilder.Append ("}");

		return new Expr (){ ExprString = closureBuilder.ToString () };
		//return InterpretExpression (expression, block);
	}

	public Expr InterpretExpression (Expression expression, FunctionBlock block, bool isFirst = true, bool isBool = false)
	{
//		for (int i = 0; i < CleanUpContextes.Count; i++)
//		{
//			CleanUpContextes [i].IsContext = false;
//		}
//		CleanUpContextes.Clear ();
		StringBuilder builder = new StringBuilder ();
		builder.Length = 0;
		Expr res;
        if (expression.Operands.Length == 0)
            Debug.Log("fuck " + expression.ToString());
		if (expression.Operands.Length == 1)
		{
			//ProcessOperand (expression.Operands [0], builder);

			int stackSize = CleanUpContextes.Count;
			res = ProcessOperand (expression.Operands [0], block, isBool);
			while (CleanUpContextes.Count > stackSize)
				CleanUpContextes.Pop ().IsContext = false;
		} else
		{
			Expression.BinaryOp binOp = (Expression.BinaryOp)expression.Operands [1];
			Type exprType = null;
			switch (binOp)
			{
			case Expression.BinaryOp.Add:
			case Expression.BinaryOp.Sub:
			case Expression.BinaryOp.Div:
			case Expression.BinaryOp.Mul:
				exprType = typeof(float);
				break;
			case Expression.BinaryOp.Equals:
			case Expression.BinaryOp.More:
			case Expression.BinaryOp.Less:
			case Expression.BinaryOp.NotEquals:
			case Expression.BinaryOp.MoreOrEquals:
			case Expression.BinaryOp.LessOrEquals:
			case Expression.BinaryOp.And:
			case Expression.BinaryOp.Or:
				exprType = typeof(bool);
				isBool = true;
				break;
			case Expression.BinaryOp.Undefined:
				break;
			default:
				throw new ArgumentOutOfRangeException ();
            }
            if (ScriptEngine.AnalyzeDebug)
                Debug.Log (expression);
			for (int i = 0; i < expression.Operands.Length; i += 2)
            {
                if (ScriptEngine.AnalyzeDebug)
                    Debug.Log ("OPERAND " + expression.Operands [i]);
				builder.Append ("(");
				int stackSize = CleanUpContextes.Count;
				builder.Append (ProcessOperand (expression.Operands [i], block, isBool).ExprString);
				builder.Append (")");
				while (CleanUpContextes.Count > stackSize)
					CleanUpContextes.Pop ().IsContext = false;
				if (i + 1 < expression.Operands.Length)
					builder.Append (expression.OpToString ((Expression.BinaryOp)expression.Operands [i + 1]));
			}
			res = new Expr (){ ExprString = builder.ToString (), Type = exprType };
		}
//		if (isFirst)
//		{
//			while (CleanUpContextes.Count > 0)
//				CleanUpContextes.Pop ().IsContext = false;
////			while(Clean)
////			for (int i = 0; i < CleanUpContextes.Count; i++)
////			{
////				CleanUpContextes [i].IsContext = false;
////			}
////			CleanUpContextes.Clear ();
//		}

		return res;
	}


	Expression[] defaultArgsList = new Expression[0];

	public Expr ProcessOperand (object operand, FunctionBlock block, bool isInsideBoolean = false)
	{
		Expr returnExpr = new Expr ();
		StringBuilder exprBuilder = new StringBuilder ();
		bool hasSign = false;
		DeclareVariableStatement resultVar = new DeclareVariableStatement ();
		resultVar.IsHidden = true;
		int insertResultIndex = block.Statements.Count;
		block.Statements.Add ("");
		char signChar = ' ';
		if (operand is ExprAtom)
		{
			if ((operand as ExprAtom).Op == ExprAtom.UnaryOp.Inverse)
			{

				signChar = '!';
			} else if ((operand as ExprAtom).Op == ExprAtom.UnaryOp.Not)
			{
				signChar = '-';
			}
			operand = (operand as ExprAtom).Content;
		}

		BindingFlags any = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public;
		if (operand is Scope)
		{
			//bool exprIsResultVar = false;
			var scope = (operand as Scope).Parts;
			bool contextVariable = true;
			var contextVar = block.FindStatement<DeclareVariableStatement> (v => v.Name == scope [0] as string);
			if (contextVariable = (contextVar == null))
				contextVar = block.FindStatement<DeclareVariableStatement> (v => v.IsContext);
            if (ScriptEngine.AnalyzeDebug)
                Debug.LogWarningFormat ("S_CTX {0} {1}", contextVar, operand);
			string contextName = null; //!contextVariable ? "root" : contextVar.Name;
			Type contextType = null; //!contextVariable ? typeof(GameObject) : contextVar.Type;
			if (contextVar == null)
			{
				contextName = block.DefaultScope;
				contextType = typeof(GameObject);
			} else
			{
				contextName = contextVar.Name;
				contextType = contextVar.Type;
			}

			exprBuilder.Append (contextName).Append (".");
			bool firstTimeList = true;
			FunctionBlock curBlock = block;
			for (int i = contextVariable ? 0 : 1; i < scope.Count; i++)
			{

                if (ScriptEngine.AnalyzeDebug)
                    Debug.LogWarningFormat ("scope part {0} {1} {2}", scope [i], contextType.IsGenericType, contextType.IsGenericType ? (contextType.GetGenericTypeDefinition () == typeof(List<>)).ToString () : "");
				if (contextType.IsGenericType && contextType.GetGenericTypeDefinition () == typeof(List<>))
				{
					if (firstTimeList)
					{
						CleanUpContextes.Push (resultVar);
						resultVar.IsTemp = true;
						resultVar.Name = "result" + DeclareVariableStatement.VariableId++;
						block.Statements [insertResultIndex] = resultVar;
						resultVar.IsHidden = false;
						resultVar.IsResult = true;

						//resultList.Type = contextType;
						//exprIsResultVar = true;
						firstTimeList = false;
					}
					Debug.Log ("scope list " + scope [i]);
					DeclareVariableStatement declVar = new DeclareVariableStatement ();
					CleanUpContextes.Push (declVar);
					declVar.IsTemp = true;
					declVar.Name = "list" + DeclareVariableStatement.VariableId++;
					declVar.Type = contextType;
					if (exprBuilder [exprBuilder.Length - 1] == '.')
						exprBuilder.Length -= 1;
					if (hasSign)
					{
						declVar.InitExpression = exprBuilder.ToString (1, exprBuilder.Length - 1);
						exprBuilder.Length = 1;
						//exprBuilder.Append (declVar.Name).Append ('.');
					} else
					{

						declVar.InitExpression = exprBuilder.ToString ();
						exprBuilder.Length = 0;
						//exprBuilder.Append (declVar.Name).Append ('.');
					}
					curBlock.Statements.Add (declVar);
					ForStatement forStatement = new ForStatement ();
					forStatement.RepeatBlock = new FunctionBlock (block, block.Method, block.Type);
					var repeatContext = new DeclareVariableStatement ();
					repeatContext.IsTemp = true;
					CleanUpContextes.Push (repeatContext);
					forStatement.RepeatBlock.Statements.Add (repeatContext);
					curBlock.Statements.Add (forStatement);
					curBlock = forStatement.RepeatBlock;
					var iterName = "i" + DeclareVariableStatement.VariableId++;
					forStatement.InsideExpr = String.Format (@"int {0} = 0; {0} < {1}.Count; {0}++", iterName, declVar.Name);

					contextType = contextType.GetGenericArguments () [0];
					repeatContext.Name = "SubContext" + DeclareVariableStatement.VariableId++;
					repeatContext.Type = contextType;
					repeatContext.IsContext = true;
					repeatContext.InitExpression = String.Format (@"{0}[{1}]", declVar.Name, iterName);

				}
				bool isFunc = false;
				if (scope [i] is FunctionCall || scope [i] is string)
				{
//					var callOp = ProcessOperand (scope [i], block);
					Expression[] callArgs = defaultArgsList;
					string callName = null;
					var call = scope [i] as FunctionCall;
					if (call != null)
					{
						callName = call.Name;
						callArgs = call.Args;
					} else
					{

						callName = scope [i] as string;
					}
					if (scopeInterpreters.ContainsKey (callName))
					{
						var interpreter = scopeInterpreters [callName];
						string outExpr = null;
						interpreter.Interpret (callArgs, curBlock, contextType, exprBuilder.ToString (), out outExpr, out curBlock, out contextType, i == scope.Count - 1);
						if (hasSign)
						{
							exprBuilder.Length = 1;
							exprBuilder.Append (outExpr).Append ('.');
						} else
						{

							exprBuilder.Length = 0;
							exprBuilder.Append (outExpr).Append ('.');
						}
						isFunc = true;
					} else
					{
						var methodName = NameTranslator.CSharpNameFromScript (callName);
						var method = contextType.GetMethod (methodName);
						if (i == 0 && method == null)
						{
							var otherContext = block.FindStatement<DeclareVariableStatement> (v => (v.IsContext || v.IsArg) && (method = v.Type.GetMethod (methodName, any)) != null);
							if (otherContext != null)
							{
								exprBuilder.Length = hasSign ? 1 : 0;
                                if (ScriptEngine.AnalyzeDebug)
                                    Debug.LogWarning ("OTHER CONTEXT" + otherContext.DebugString ());
								exprBuilder.Append (otherContext.Name).Append ('.');
								contextType = otherContext.Type;
							} else
							{

                                if (ScriptEngine.AnalyzeDebug)
                                    Debug.LogWarning ("Can't find context for method " + methodName);
								block.FindStatement<DeclareVariableStatement> (v => {
                                    if (ScriptEngine.AnalyzeDebug)
                                        Debug.LogFormat ("{0} {1} {3}                  ||||{2}", v.Name, v.Type, IfStatement.AntiMergeValue++, v.IsContext || v.IsArg);
									return false; });
							}
						}
						if (method == null)
                        {
                            if (ScriptEngine.AnalyzeDebug)
                                Debug.LogFormat ("Can't find {0} in {1}", NameTranslator.CSharpNameFromScript (callName), contextType);
						} else
						{
							exprBuilder.Append (method.Name).Append ("(");
							var argsDef = method.GetParameters ();
							if (callArgs != null)
							{
								for (int j = 0; j < callArgs.Length; j++)
								{
									if (argsDef [j].ParameterType.IsSubclassOf (typeof(Delegate)))
										exprBuilder.Append (InterpretClosure (callArgs [j], curBlock, argsDef [j].ParameterType).ExprString).Append (",");
									else
										exprBuilder.Append (InterpretExpression (callArgs [j], curBlock).ExprString).Append (",");
								}
								if (callArgs.Length > 0)
									exprBuilder.Length -= 1;
							}

							exprBuilder.Append (")");
							contextType = method.ReturnType;


							var declVar = new DeclareVariableStatement ();
							CleanUpContextes.Push (declVar);
							declVar.IsTemp = true;
							declVar.Name = "prop" + DeclareVariableStatement.VariableId++;
							declVar.IsContext = true;
							if (exprBuilder.Length > 0 && exprBuilder [exprBuilder.Length - 1] == '.')
								exprBuilder.Length -= 1;
							if (hasSign)
							{
								declVar.InitExpression = exprBuilder.ToString (1, exprBuilder.Length - 1);
								exprBuilder.Length = 1;
								exprBuilder.Append (declVar.Name).Append ('.');
							} else
							{

								declVar.InitExpression = exprBuilder.ToString ();
								exprBuilder.Length = 0;
								exprBuilder.Append (declVar.Name).Append ('.');
							}
							declVar.Type = contextType;
							curBlock.Statements.Add (declVar);
							if (contextType.IsClass)
							{
								IfStatement ifSt = new IfStatement ();
								ifSt.CheckExpression = String.Format ("{0} != null", declVar.Name);
								ifSt.TrueBlock = new FunctionBlock (curBlock);
								curBlock.Statements.Add (ifSt);
								curBlock = ifSt.TrueBlock;
							}
							isFunc = true;
						}

					}

				} 
				if (!isFunc)
				{
					var propName = NameTranslator.CSharpNameFromScript (scope [i] as string);

					var prop = contextType.GetProperty (propName);

					if (i == 0 && prop == null)
					{
						var customVar = block.FindStatement<DeclareVariableStatement> (v => v.Name == scope [i] as string);
						if (customVar == null)
						{
							var otherContext = block.FindStatement<DeclareVariableStatement> (v => {
								//Debug.LogWarning (v.Type);
								//Debug.Log (v.IsContext || v.IsArg);
								//var props = v.Type.GetProperties (any);
								//foreach (var allProp in props)
								//	Debug.Log (allProp.Name);
								return (v.IsContext || v.IsArg) && (prop = v.Type.GetProperty (propName, any)) != null;});
							if (otherContext != null)
							{
								exprBuilder.Length = hasSign ? 1 : 0;

								exprBuilder.Append (otherContext.Name).Append ('.');
								contextType = otherContext.Type;
								if (contextType.IsClass && !prop.GetGetMethod().IsStatic)
								{
									IfStatement ifSt = new IfStatement ();
									ifSt.CheckExpression = String.Format ("{0} != null", otherContext.Name);
									ifSt.TrueBlock = new FunctionBlock (curBlock);
									curBlock.Statements.Add (ifSt);
									curBlock = ifSt.TrueBlock;
								}
							}
                            else
                                if (ScriptEngine.AnalyzeDebug)
                                    Debug.LogWarning ("Can't find context for property " + propName);
						} else
						{
							exprBuilder.Length = hasSign ? 1 : 0;
							exprBuilder.Append (customVar.Name).Append ('.');
							contextType = customVar.Type;
							if (contextType.IsClass && !prop.GetGetMethod().IsStatic)
							{
								IfStatement ifSt = new IfStatement ();
								ifSt.CheckExpression = String.Format ("{0} != null", customVar.Name);
								ifSt.TrueBlock = new FunctionBlock (curBlock);
								curBlock.Statements.Add (ifSt);
								curBlock = ifSt.TrueBlock;
							}
						}


                    }
                    if (ScriptEngine.AnalyzeDebug)
                        Debug.LogWarning (prop);
					if (prop == null && components.ContainsKey (scope [i] as string))
					{
						var type = components [scope [i] as string];
                        string storedFromName = null;
                        if (hasSign)
                            storedFromName =  exprBuilder.ToString(1, exprBuilder.Length - 1);
                        else
                            storedFromName = exprBuilder.ToString();
                        if (ScriptEngine.AnalyzeDebug)
                            Debug.LogWarning ("Component found " + type);
                        var storedVar = curBlock.FindStatement<DeclareVariableStatement> (v => v.Type == type && v.storedOf != null && storedFromName == v.storedOf);
                        
						contextType = type;
						if (storedVar == null)
						{
							storedVar = new DeclareVariableStatement ();
							CleanUpContextes.Push (storedVar);
							storedVar.IsTemp = true;
							storedVar.IsContext = true;
							curBlock.Statements.Add (storedVar);//block.FindStatement<DeclareVariableStatement> (v => !v.IsContext && v.Type == type);
							storedVar.Name = "StoredVariable" + DeclareVariableStatement.VariableId++;
							storedVar.Type = type;

                            storedVar.storedOf = hasSign ? exprBuilder.ToString(1, exprBuilder.Length) : exprBuilder.ToString(0, exprBuilder.Length);
                            exprBuilder.Append (String.Format ("GetComponent(typeof({0})))", type));
							exprBuilder.Insert (0, String.Format ("(({0})", type));
							if (hasSign)
							{
								storedVar.InitExpression = exprBuilder.ToString (1, exprBuilder.Length - 1);
								exprBuilder.Length = 1;
								exprBuilder.Append (storedVar.Name).Append ('.');
							} else
							{

								storedVar.InitExpression = exprBuilder.ToString ();
								exprBuilder.Length = 0;
								exprBuilder.Append (storedVar.Name).Append ('.');
							}
						}
						if (hasSign)
						{
							exprBuilder.Length = 1;
							exprBuilder.Append (storedVar.Name).Append ('.');
						} else
						{

							exprBuilder.Length = 0;
							exprBuilder.Append (storedVar.Name).Append ('.');
						}

						if (contextType.IsClass)
						{
							IfStatement ifSt = new IfStatement ();
							ifSt.CheckExpression = String.Format ("{0} != null", storedVar.Name);
							ifSt.TrueBlock = new FunctionBlock (curBlock);
							curBlock.Statements.Add (ifSt);
							curBlock = ifSt.TrueBlock;
						}

					} else if (scopeInterpreters.ContainsKey (scope [i] as string))
					{
						var interpreter = scopeInterpreters [scope [i] as string];
						string outExpr = null;
						interpreter.Interpret (null, curBlock, contextType, exprBuilder.ToString (), out outExpr, out curBlock, out contextType, i == scope.Count - 1);
						if (hasSign)
						{
							exprBuilder.Length = 1;
							exprBuilder.Append (outExpr).Append ('.');
						} else
						{

							exprBuilder.Length = 0;
							exprBuilder.Append (outExpr).Append ('.');
						}

					} else if (prop == null && scope.Count == 1)
                    {
                        if (ScriptEngine.AnalyzeDebug)
                            Debug.LogWarningFormat ("Can't find {0} in {1}, interpreting as a string", propName, contextType);
						contextType = typeof(string);
						exprBuilder.Length = 0;
						exprBuilder.Append ("\"").Append (scope [i]).Append ("\"");
						break;
					} else if (prop == null)
					{

						Debug.LogWarningFormat ("Can't find {0} in {1}", propName, contextType);
						break;
					} else
					{
						contextType = prop.PropertyType;
						exprBuilder.Append (propName).Append ('.');
						var declVar = new DeclareVariableStatement ();
						CleanUpContextes.Push (declVar);
						declVar.IsTemp = true;
						declVar.IsContext = true;
						declVar.Name = "prop" + DeclareVariableStatement.VariableId++;
						if (exprBuilder.Length > 0 && exprBuilder [exprBuilder.Length - 1] == '.')
							exprBuilder.Length -= 1;
						if (hasSign)
						{
							declVar.InitExpression = exprBuilder.ToString (1, exprBuilder.Length - 1);
							exprBuilder.Length = 1;
							exprBuilder.Append (declVar.Name).Append ('.');
						} else
						{

							declVar.InitExpression = exprBuilder.ToString ();
							exprBuilder.Length = 0;
							exprBuilder.Append (declVar.Name).Append ('.');
						}
						declVar.Type = contextType;
						curBlock.Statements.Add (declVar);
						if (contextType.IsClass)
						{
							IfStatement ifSt = new IfStatement ();
							ifSt.CheckExpression = String.Format ("{0} != null", declVar.Name);
							ifSt.TrueBlock = new FunctionBlock (curBlock);
							curBlock.Statements.Add (ifSt);
							curBlock = ifSt.TrueBlock;
						}
					}


				}

			}
			returnExpr.Type = contextType;
			var res = resultVar;
			if (!res.IsHidden)
			{
				var list = curBlock.FindStatement<DeclareVariableStatement> (v => v.Type != null && v.Type.IsGenericType && v.Type.GetGenericTypeDefinition () == typeof(List<>));
				var lasVar = curBlock.FindStatement<DeclareVariableStatement> (v => v.IsContext);
				if (list != null && !firstTimeList)
				{
					curBlock.Statements.Add (String.Format (@"{0}.Add({1});", res.Name, lasVar.Name));
					res.Type = typeof(List<>).MakeGenericType (lasVar.Type);
					res.InitExpression = String.Format ("new {0}();", TypeName.NameOf (res.Type));
				} else
				{
					res.Type = lasVar.Type;
					curBlock.Statements.Add (String.Format (@"{0} = {1};", res.Name, lasVar.Name));
				}
				if (hasSign)
				{
					exprBuilder.Length = 1;
					exprBuilder.Append (res.Name).Append ('.');
				} else
				{

					exprBuilder.Length = 0;
					exprBuilder.Append (res.Name).Append ('.');
				}

				returnExpr.Type = res.Type;
			}

			if (!res.IsHidden && res.Type != null)
			{
				var resType = res.Type;
				res.IsResult = false;
				Debug.Log (isInsideBoolean);
				if (isInsideBoolean && resType.IsGenericType && resType.GetGenericTypeDefinition () == typeof(List<>))
				{
					exprBuilder.Append (String.Format (" != null ? {0}.Count : 0", exprBuilder));
				}
			}
			if (exprBuilder.Length > 0 && exprBuilder [exprBuilder.Length - 1] == '.')
				exprBuilder.Length -= 1;
			if (res.IsHidden)
			{
				resultVar.Name = "OperandVar" + DeclareVariableStatement.VariableId++;
				resultVar.Type = contextType;
				resultVar.InitExpression = string.Format ("default({0})", TypeName.NameOf (contextType));
				resultVar.IsHidden = false;
				block.Statements [insertResultIndex] = resultVar;
				curBlock.Statements.Add (String.Format ("{0} = {1};", resultVar.Name, exprBuilder));
				exprBuilder.Length = hasSign ? 1 : 0;
				var resType = res.Type;
				if (isInsideBoolean && resType.IsGenericType && resType.GetGenericTypeDefinition () == typeof(List<>))
				{
					exprBuilder.Append (String.Format ("{0} != null ? {0}.Count : 0", resultVar.Name));
				} else
				{
					exprBuilder.Append (resultVar.Name);
					
				}
			}

			
		} else if (operand is FunctionCall)
		{

//			var call = operand as FunctionCall;
//			for (int i = 0; i < call.Args.Length; i++)
//			{
//				
//			}

		} else if (operand is Expression)
		{
			var ex = InterpretExpression (operand as Expression, block, false, isInsideBoolean);
			exprBuilder.Append (ex.ExprString);
			returnExpr.Type = ex.Type;
		} else
		{
			returnExpr.Type = operand.GetType ();
			if (operand is bool)
				exprBuilder.Append ((bool)operand ? "true" : "false");
			else
				exprBuilder.Append (operand);
			if (operand is float)
				exprBuilder.Append ('f');
		}
		string head = String.Format ("{0}(", signChar);
		exprBuilder.Insert (0, head).Append (')');
		returnExpr.ExprString = exprBuilder.ToString ();
		return returnExpr;
	}

}


public abstract class ScopeInterpreter
{
	public ScriptEngine Engine;

	public ExpressionInterpreter ExprInter;

	public abstract void Interpret (Expression[] args, FunctionBlock block, Type contextType, string exprVal, out string newExprVal, out FunctionBlock newCurBlock, out Type newContextType, bool isLast);

}



public class ScopeInterpreterAttribute : Attribute
{
	public string Name { get; internal set; }

	public ScopeInterpreterAttribute (string name)
	{
		Name = name;
	}
}

