using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public static class TypeName
{
	public static string NameOf (Type type)
	{
		if (type == null)
			return "NullType";
		Type genType;
        //if (ScriptEngine.AnalyzeDebug)
        //    Debug.Log ("NameOf " + type);
		if (type.IsGenericType && (genType = type.GetGenericTypeDefinition ()) == typeof(List<>))
		{
			return String.Format ("System.Collections.Generic.List<{0}>", type.GetGenericArguments () [0]);
		}
		return type.FullName;
	}
}

public class IfStatement
{
	public static int AntiMergeValue = 0;
	public string CheckExpression;
	public FunctionBlock TrueBlock;

	public override string ToString ()
	{
		//return String.Format ("if({0}){1} else {{ UnityEngine.Debug.Log(\"{0} = false \" +  IfStatement.AntiMergeValue++); }}", CheckExpression, TrueBlock);
		return String.Format ("if({0}){1}", CheckExpression, TrueBlock);
	}
}

public class LambdaStatement
{
	public FunctionBlock Block;
	public string Name;
	public Type DelegateType;
	public ParameterInfo[] Params;
	static StringBuilder paramsBuilder = new StringBuilder ();

	public override string ToString ()
	{
		paramsBuilder.Length = 0;
		if (Params != null)
		{

			foreach (var param in Params)
				paramsBuilder.Append (param.ParameterType).Append (' ').Append (param.Name).Append (',');
			if (Params.Length > 0)
				paramsBuilder.Length -= 1;
		}
		string args = paramsBuilder.ToString ();
		return String.Format ("{3} {0} = ({2}) => {1};", Name, Block, args, DelegateType);
	}
}

public class DeclareVariableStatement
{
    public string storedOf = null;
	public static int VariableId = 0;
	public string ctxEntity = null;
	public StatementStringContainer Cnt = null;
	public Type Type;
	public string Name;
	public string InitExpression;
	public bool IsHidden = false;
	public bool IsNew = false;
	public bool IsContext = false;
	public bool IsArg = false;
	public bool IsResult = false;
	public bool IsTemp = false;
	public bool IsReturn = false;
	public bool IsDeclaration = true;
	//	public object Lambda;

	public override string ToString ()
	{
//		if (Lambda != null)
//		{
//			return string.Format("var {0}")
//		}
		if (InitExpression != null && InitExpression.Length > 0 && InitExpression [InitExpression.Length - 1] == '.')
			InitExpression = InitExpression.Substring (0, InitExpression.Length - 1);
			
		if (IsArg || IsHidden)
			return "";
		if (!IsDeclaration)
		{
			if (InitExpression == null)
				return string.Format ("{0} {1}; //IsContext = {2} IsNew = {3}", "", Name, IsContext, IsNew);
			else
				return string.Format ("{0} {1} = {2}; //IsContext = {3} IsNew = {4}", "", Name, InitExpression, IsContext, IsNew);
		}
		if (InitExpression == null)
			return string.Format ("{0} {1}; //IsContext = {2} IsNew = {3}", TypeName.NameOf (Type), Name, IsContext, IsNew);
		else
			return string.Format ("{0} {1} = {2}; //IsContext = {3} IsNew = {4}", TypeName.NameOf (Type), Name, InitExpression, IsContext, IsNew);
	}

	public string DebugString ()
	{
		return string.Format ("DeclVarStmt: {0} {1} = {2}, IsContext = {3}", TypeName.NameOf (Type), Name, InitExpression, IsContext);
	}
}

public class ForStatement
{
	public FunctionBlock RepeatBlock;
	public string InsideExpr;

	public override string ToString ()
	{
		return string.Format ("for ({0}){1}", InsideExpr, RepeatBlock);
	}
}


