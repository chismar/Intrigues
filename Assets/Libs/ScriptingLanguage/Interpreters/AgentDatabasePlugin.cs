using UnityEngine;
using System.Collections;
using System.CodeDom;
using InternalDSL;
using System.Collections.Generic;
using System;
using CSharpCompiler;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;



public class AgentDatabase : MonoBehaviour
{
    protected Dictionary<Type, object> data = new Dictionary<Type, object>();

    public List<T> Get<T>()
    {
        object list = null;
        data.TryGetValue(typeof(T), out list);
        return list as List<T>;
    }

    public bool Has<T>()
    {
        object list = null;
        data.TryGetValue(typeof(T), out list);
        return list != null;
    }
    

}

public class AgentDatabaseLoader : ScriptInterpreter
{

    Dictionary<string, Type> types = new Dictionary<string, Type>();
    CodeNamespace cNamespace = new CodeNamespace();
    Dictionary<string, CodeTypeDeclaration> codeTypes = new Dictionary<string, CodeTypeDeclaration>();
    //TODO: Actually create loaders
    ScriptsLoader loader;
    CodeTypeDeclaration dbComponentType;
    Type baseType;
    public void Init()
    {

        loader = UnityEngine.Object.FindObjectOfType<ScriptsLoader>();
    }
    HashSet<string> returnedLists = new HashSet<string>();
    public AgentDatabaseLoader(ScriptEngine engine, string typeName, Type baseType) : base(engine)
    {
        this.baseType = baseType;
        dbComponentType = new CodeTypeDeclaration(typeName);
        dbComponentType.BaseTypes.Add(typeof(AgentDatabase));
        cNamespace.Name = "ScriptedTypes";
        cNamespace.Types.Add(dbComponentType);
    }

    //	public void AddTypes (params Type[] types)
    //	{
    //		foreach (var type in types)
    //			this.types.Add (NameTranslator.ScriptNameFromCSharp (type.Name), type);
    //	}
    //
    public void AddType(Type t, string name)
    {

        //if (t.IsClass)
        types.Add(name, t);
    }

    public override void Interpret(Script script)
    {
        List<string> listExtensions = new List<string>();
        foreach (var entry in script.Entries)
        {

            CodeTypeDeclaration dbElement = null;
            if (!codeTypes.TryGetValue(entry.Identifier as string, out dbElement))
            {
                dbElement = new CodeTypeDeclaration(entry.Identifier as string);
                cNamespace.Types.Add(dbElement);
                dbElement.BaseTypes.Add(baseType);
                codeTypes.Add(entry.Identifier as string, dbElement);
            }
            var props = baseType.GetProperties();

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
                prop.PrivateImplementationType = new CodeTypeReference(baseType);
                if (!dbElement.UserData.Contains(fieldName))
                {
                    var field = new CodeMemberField();
                    field.Name = fieldName;
                    field.Type = new CodeTypeReference(propInfo.PropertyType);
                    dbElement.Members.Add(field);
                    dbElement.UserData.Add(fieldName, field);
                    field.UserData.Add("type", propInfo.PropertyType);
                }
                dbElement.Members.Add(prop);
            }
            if (entry.Context is Table)
            {

                foreach (var fieldOp in (entry.Context as Table).Entries)
                {
                    var op = fieldOp as Operator;
                    var typeName = (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts[0] as string;
                    CodeMemberField field = null;
                    CodeMemberProperty prop = new CodeMemberProperty();
                    prop.HasGet = true;
                    prop.HasSet = true;
                    prop.GetStatements.Add(new CodeSnippetStatement(String.Format("return {0}; ", op.Identifier)));
                    if ((typeName == "float" || typeName == "int") && op.Args.Count == 2)
                    {

                        var clampMin = op.Args[0].ToString();
                        var clampMax = op.Args[1].ToString();
                        prop.SetStatements.Add(new CodeSnippetStatement(String.Format("{0} = ({3})UnityEngine.Mathf.Clamp(value, {1}, {2}); ", op.Identifier, clampMin, clampMax, typeName)));

                    }
                    else
                        prop.SetStatements.Add(new CodeSnippetStatement(String.Format("{0} = value; ", op.Identifier)));

                    prop.Name = NameTranslator.CSharpNameFromScript(op.Identifier as string);
                    if (typeName == null)
                    {
                        var listFunc = (((op.Context as Expression).Operands[0] as ExprAtom).Content as Scope).Parts[0] as FunctionCall;
                        typeName = ((listFunc.Args[0].Operands[0] as ExprAtom).Content as Scope).Parts[0] as string;

                        if (ScriptEngine.AnalyzeDebug)
                            Debug.Log("LIST: " + typeName);
                        var listType = String.Format("System.Collections.Generic.List<{0}>", types[typeName]);
                        field = new CodeMemberField(new CodeTypeReference(listType), op.Identifier as string);
                        field.InitExpression = new CodeSnippetExpression(String.Format("new {0}()", listType));
                    }
                    else
                    {

                        if (ScriptEngine.AnalyzeDebug)
                            Debug.Log(typeName);
                        field = new CodeMemberField(types[typeName], op.Identifier as string);
                    }
                    field.Attributes = MemberAttributes.Public;
                    prop.Type = field.Type;
                    prop.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                    dbElement.Members.Add(prop);
                    dbElement.Members.Add(field);


                }


            }

            //OnAdd, OnRemove
            var elementName = (entry.Identifier as string).CSharp();
            var onAddEvent = new CodeTypeDeclaration(elementName + "Added");
            onAddEvent.BaseTypes.Add(new CodeTypeReference(typeof(DelayedEvent)));
            var onRemoveEvent = new CodeTypeDeclaration(elementName + "Removed");
            onRemoveEvent.BaseTypes.Add(new CodeTypeReference(typeof(DelayedEvent)));

            var elementProp = new CodeMemberProperty();
            elementProp.Name = "Fact";
            elementProp.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            elementProp.Type = new CodeTypeReference(dbElement.Name);
            var elementField = new CodeMemberField();
            elementField.Name = "fact";
            elementField.Type = new CodeTypeReference(dbElement.Name);
            elementProp.HasGet = true;
            elementProp.HasSet = true;
            elementProp.SetStatements.Add(new CodeSnippetStatement("fact = value;"));
            elementProp.GetStatements.Add(new CodeSnippetStatement("return fact;"));

            onAddEvent.Members.Add(elementProp);
            onAddEvent.Members.Add(elementField);

            onRemoveEvent.Members.Add(elementProp);
            onRemoveEvent.Members.Add(elementField);

            cNamespace.Types.Add(onAddEvent);
            cNamespace.Types.Add(onRemoveEvent);
            //Get\Query[Type], Add[Type], Remove[Type], Remove[Type]Where, Has[Type], Has[Type]Where

            var getThisTypeMethod = new CodeMemberProperty();
            getThisTypeMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            getThisTypeMethod.Name = "Get" + NameTranslator.CSharpNameFromScript(dbElement.Name);
            getThisTypeMethod.HasGet = true;
            getThisTypeMethod.HasSet = false;
            getThisTypeMethod.Type = new CodeTypeReference(string.Format("System.Collections.Generic.List<ScriptedTypes.{0}>", dbElement.Name));
            getThisTypeMethod.GetStatements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); return list;", dbElement.Name)));
            dbComponentType.Members.Add(getThisTypeMethod);

            if (returnedLists.Add(dbElement.Name))
            {
                var listExt = string.Format("public static class {0} {{ static ObjectPool<System.Collections.Generic.List<ScriptedTypes.{1}>> pool = new ObjectPool<System.Collections.Generic.List<ScriptedTypes.{1}>>(); {2} }}",
                    dbElement.Name + "ListExt", dbElement.Name,
                    string.Format("public static System.Collections.Generic.List<ScriptedTypes.{0}> Get() {{ var list = pool.Get(); list.Clear(); return list; }} public static void Return(this System.Collections.Generic.List<ScriptedTypes.{0}> list){{pool.Return(list);}}",
                    dbElement.Name));
                listExtensions.Add(listExt);
            }

            var queryThisTypeMethod = new CodeMemberMethod();
            queryThisTypeMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            queryThisTypeMethod.Name = "Query" + NameTranslator.CSharpNameFromScript(dbElement.Name);
            CodeTypeDelegate del = new CodeTypeDelegate(dbElement.Name + "_queryDelegate");
            del.ReturnType = new CodeTypeReference(typeof(bool));
            del.Parameters.Add(new CodeParameterDeclarationExpression("ScriptedTypes." + dbElement.Name, NameTranslator.ScriptNameFromCSharp(baseType.Name)));
            cNamespace.Types.Add(del);
            queryThisTypeMethod.Parameters.Add(new CodeParameterDeclarationExpression(dbElement.Name + "_queryDelegate", "queryDel"));
            queryThisTypeMethod.ReturnType = new CodeTypeReference(string.Format("System.Collections.Generic.List<ScriptedTypes.{0}>", dbElement.Name));
            queryThisTypeMethod.Statements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); if(list == null) return list; var queryList = {1}.Get(); foreach(var e in list) if (queryDel(e)) queryList.Add(e); return queryList;", dbElement.Name, dbElement.Name + "ListExt")));
            dbComponentType.Members.Add(queryThisTypeMethod);


            var deleteWhere = new CodeMemberMethod();
            deleteWhere.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            deleteWhere.Name = "Delete" + NameTranslator.CSharpNameFromScript(dbElement.Name) + "Where";

            deleteWhere.Parameters.Add(new CodeParameterDeclarationExpression(dbElement.Name + "_queryDelegate", "queryDel"));
            deleteWhere.Statements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); if(list == null) return; for(int i =0; i < list.Count; i++) if(queryDel(list[i])) {{ var e = EventsManager.Instance.GetEvent<ScriptedTypes.{1}>(); e.Root = gameObject; e.Fact = list[i]; EventsManager.Instance.FireEvent(e); list.RemoveAt(i); i--; }}", dbElement.Name, onRemoveEvent.Name)));
            dbComponentType.Members.Add(deleteWhere);


            var delete = new CodeMemberMethod();
            delete.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            delete.Name = "Delete" + NameTranslator.CSharpNameFromScript(dbElement.Name);

            delete.Parameters.Add(new CodeParameterDeclarationExpression(dbElement.Name, "obj"));
            delete.Statements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); if(list != null) {{ list.Remove(obj); var e = EventsManager.Instance.GetEvent<ScriptedTypes.{1}>(); e.Root = gameObject; e.Fact = obj; EventsManager.Instance.FireEvent(e);}} ", dbElement.Name, onRemoveEvent.Name)));
            dbComponentType.Members.Add(delete);

            var add = new CodeMemberMethod();
            add.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            add.Name = "Add" + NameTranslator.CSharpNameFromScript(dbElement.Name);
            add.ReturnType = new CodeTypeReference("ScriptedTypes." + dbElement.Name);
            add.Statements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); if(list == null) {{ list = ScriptedTypes.{0}ListExt.Get(); data.Add(typeof(ScriptedTypes.{0}), list); }} var e = new ScriptedTypes.{0}(); list.Add(e); var ev = EventsManager.Instance.GetEvent<ScriptedTypes.{1}>(); ev.Root = gameObject; ev.Fact = e; EventsManager.Instance.FireEvent(ev); return e;", dbElement.Name, onAddEvent.Name)));
            dbComponentType.Members.Add(add);

            var has = new CodeMemberMethod();
            has.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            has.Name = "Has" + NameTranslator.CSharpNameFromScript(dbElement.Name);
            has.ReturnType = new CodeTypeReference(typeof(bool));
            has.Statements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); return list != null;", dbElement.Name)));
            dbComponentType.Members.Add(has);

            var hasWhere = new CodeMemberMethod();
            hasWhere.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            hasWhere.Name = "Has" + NameTranslator.CSharpNameFromScript(dbElement.Name) + "Where";
            hasWhere.ReturnType = new CodeTypeReference(typeof(bool));
            hasWhere.Parameters.Add(new CodeParameterDeclarationExpression(dbElement.Name + "_queryDelegate", "queryDel"));
            hasWhere.Statements.Add(new CodeSnippetStatement(
                string.Format("var list = this.Get<ScriptedTypes.{0}>(); if(list == null) return false; for(int i =0; i < list.Count; i++) if(queryDel(list[i])) return true; return false;", dbElement.Name)));
            dbComponentType.Members.Add(hasWhere);
        }
        CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        CodeGeneratorOptions options = new CodeGeneratorOptions();
        var writer = new StringWriter();
        codeProvider.GenerateCodeFromNamespace(cNamespace, writer, options);
        if(listExtensions.Count > 0)
        {
            writer.WriteLine("namespace ScriptedTypes {");
            foreach (var listExt in listExtensions)
                writer.WriteLine(listExt);
            writer.WriteLine("}");
        }
        
        Debug.Log(writer.ToString());
        OnCompiled(loader.Load(new string[] { writer.ToString() }, "AgentsDatabases_" + baseType.Name));
        //onCompiled ();
    }

    public ContextSwitchInterpreter Ctx { get; internal set; }

    void OnCompiled(Assembly asm)
    {
        //AppDomain.CurrentDomain.Load (asm.GetName ());
        //asm.GetName ().SetPublicKeyToken (new byte[]{ 12, 13, 48, 2 });

        if (ScriptEngine.AnalyzeDebug)
            Debug.LogWarning(asm.FullName);
        Engine.AddAssembly(asm);
        // if (ScriptEngine.AnalyzeDebug)
        //     foreach (var key in codeTypes.Keys)
        //	Debug.Log (Engine.GetType (key));


        //		Ctx = new ContextSwitchInterpreter (type, Engine);
        //
        //		onCompiled ();
    }

}

