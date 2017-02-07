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
		field.Name = identifier;
		field.Type = prop.Type;
		field.UserData.Add ("type", propType);
		prop.GetStatements.Add (new CodeSnippetStatement ("return {0};".Fmt(field.Name)));
		prop.SetStatements.Add (new CodeSnippetStatement ("{0} = value;".Fmt (field.Name)));
		prop.HasGet = true;
		prop.HasSet = true;

		type.Members.Add (field);
		type.Members.Add (prop);
	}

	public static T GetShared<T>(this CodeTypeDeclaration type, string name) where T : CodeTypeMember, new()
	{
		if (type.UserData.Contains (name)) {
			return type.UserData [name] as T;
		} else {
			var member = new T ();
			type.UserData.Add (name, member);
			type.Members.Add (member);
			return member;
		}
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


	public static void OverrideMethodConst(this CodeTypeDeclaration type, Type baseType, string propName, string value)
	{
		MethodInfo baseMethod = baseType.GetMethod (propName);
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
				list.Add (st);
			}
		}

		foreach (var member in type.Members)
		{
			var field = member as CodeMemberField;
			if (field != null)
			{
				var cachedVar = new DeclareVariableStatement ();
				cachedVar.Name = field.Name;
				cachedVar.Type = field.UserData ["type"] as Type;
				cachedVar.IsArg = true;

				list.Add (cachedVar);
			}
		}
		return list;
	}

	public static FunctionBlock InitialBlock(this CodeMemberMethod method, CodeTypeDeclaration type, ScriptEngine engine)
	{
		FunctionBlock block = new FunctionBlock (null, method, type);
		foreach(var pStatement in type.Props())
			block.Statements.Add(pStatement);

		DeclareVariableStatement externals = new DeclareVariableStatement ();
		externals.IsArg = true;
		externals.Name = "External";
		externals.Type = engine.GetType ("External");
		block.Statements.Add (externals);
		return block;
	}

	public static FunctionBlock OverrideMethod(this CodeTypeDeclaration type, Type baseType, string methodName, ScriptEngine engine)
	{
		
		CodeMemberMethod method = new CodeMemberMethod ();
		method.Name = methodName;
		method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
		type.Members.Add (method);

		var initBlock = method.InitialBlock (type, engine);

		var baseMethod = baseType.GetMethod (methodName);
		method.ReturnType = new CodeTypeReference (baseMethod.ReturnType);

		foreach (var param in baseMethod.GetParameters()) {
			method.Parameters.Add (new CodeParameterDeclarationExpression (param.ParameterType, param.Name));
			DeclareVariableStatement st = new DeclareVariableStatement ();
			st.IsArg = true;
			st.Name = param.Name;
			st.Type = param.ParameterType;
			initBlock.Statements.Add (st);
		}
		return initBlock;



	}

	public static void AddCategoryInterface(this CodeTypeDeclaration codeType, string cat, ScriptEngine engine, CodeNamespace cNamespace)
	{
		var type = engine.FindType("ScriptedTypes." + cat);
		if (type == null)
			type = engine.FindType(NameTranslator.CSharpNameFromScript(cat));
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
			codeType.OverridePropConst (typeof(Task), "IsBehaviour", "false");
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
}

