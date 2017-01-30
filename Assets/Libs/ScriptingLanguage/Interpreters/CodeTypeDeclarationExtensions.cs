using UnityEngine;
using System.Collections;
using System.CodeDom;
using System;
using System.Reflection;
using System.Collections.Generic;


public static class CodeTypeDeclarationExtensions
{

	public static void CreateProp(this CodeTypeDeclaration type, Type propType, string identifier)
	{
		CodeMemberProperty prop = new CodeMemberProperty ();
		prop.Name = identifier.CSharp ();
		prop.Type = new CodeTypeReference (propType);
		prop.Attributes = MemberAttributes.Public | MemberAttributes.Final;
		prop.UserData.Add ("type", propType);
		CodeMemberField field = new CodeMemberField ();
		field.Name = prop.Name.ToLower ();
		field.Type = prop.Type = new CodeTypeReference (propType);
		field.UserData.Add ("type", propType);
		prop.GetStatements.Add (new CodeSnippetStatement ("return {0};".Fmt(field.Name)));
		prop.SetStatements.Add (new CodeSnippetStatement ("{0} = value;".Fmt (field.Name)));
		prop.HasGet = true;
		prop.HasSet = true;

		type.Members.Add (field);
		type.Members.Add (prop);
	}

	public static void OverridePropConst(this CodeTypeDeclaration type, Type baseType, string propName, string value)
	{
		MethodInfo baseMethod = baseType.GetProperty (propName).GetGetMethod ();
		CodeMemberProperty prop = new CodeMemberProperty ();
		prop.Name = propName.CSharp ();
		prop.Type = new CodeTypeReference (baseMethod.ReturnType);
		prop.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		prop.UserData.Add ("type", baseMethod.ReturnType);

		prop.GetStatements.Add (new CodeSnippetStatement ("return {0};".Fmt(value)));
		prop.HasGet = true;
		prop.HasSet = false;

		type.Members.Add (prop);
	}

	public static void CreatePropFunc(this CodeTypeDeclaration type, Type baseType, string propName, object context, ScriptEngine engine)
	{
		MethodInfo baseMethod = baseType.GetProperty (propName).GetGetMethod ();
		CodeMemberProperty prop = new CodeMemberProperty ();
		prop.Name = propName.CSharp ();
		prop.Type = new CodeTypeReference (baseMethod.ReturnType);
		prop.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		prop.UserData.Add ("type", baseMethod.ReturnType);
		var exprInter = engine.GetPlugin<ExpressionInterpreter> ();

		FunctionBlock block = new FunctionBlock (null, null, type);
		foreach(var pStatement in type.Props())
			block.Statements.Add(pStatement);
		
		DeclareVariableStatement externals = new DeclareVariableStatement ();
		externals.IsArg = true;
		externals.Name = "External";
		externals.Type = engine.GetType ("External");
		block.Statements.Add (externals);
		prop.GetStatements.Add (new CodeSnippetStatement ("return {0};".Fmt(exprInter.InterpretExpression(context as InternalDSL.Expression, block).ExprString)));
		prop.HasGet = true;
		prop.HasSet = false;

		type.Members.Add (prop);
	}

	public static List<DeclareVariableStatement> Props(this CodeTypeDeclaration type)
	{
		List<DeclareVariableStatement> list = new List<DeclareVariableStatement> ();
		foreach (var member in type.Members) {
			if (member is CodeMemberProperty) {
				var prop = member as CodeMemberProperty;
				DeclareVariableStatement st = new DeclareVariableStatement ();
				st.Name = prop.Name;
				st.IsArg = true;
				st.Type = prop.UserData ["type"] as Type;
				list.Add (prop);
			}
		}

		return list;
	}

}

