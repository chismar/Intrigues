using UnityEngine;
using System.Collections;
using System;
using InternalDSL;
using System.CodeDom;
using System.Collections.Generic;


public class FiltersPlugin : ScriptEnginePlugin
{
	Dictionary<string, FilterPartInterpreter> filters = new Dictionary<string, FilterPartInterpreter> ();

	public override void Init ()
	{

	}

	public void AddFilter (FilterPartInterpreter filter, string name)
	{
		filter.Engine = Engine;
		filters.Add (name, filter);
	}


	public FilterPartInterpreter GetFilter (string filterName)
	{
		FilterPartInterpreter filter = null;
		filters.TryGetValue (filterName, out filter);
		return filter;
	}


}

public class ComponentsFiltersPlugin : ScriptEnginePlugin
{
	public override void Init ()
	{
		FiltersPlugin filtersPlugin = Engine.GetPlugin<FiltersPlugin> ();

		var components = Engine.FindTypesCastableTo<MonoBehaviour> ();
		foreach (var cmp in components)
		{
			var cmpName = NameTranslator.ScriptNameFromCSharp (cmp.Name);
			var opName = "has_" + cmpName;
			HasComponentFilter filter = new HasComponentFilter (cmp);
			filtersPlugin.AddFilter (filter, opName);
		}

		var specTypes = Engine.FindTypesWithAttribute<FilterPartInterpreterAttribute> ();
		foreach (var specType in specTypes)
		{
			FilterPartInterpreter inter = Activator.CreateInstance (specType.Type) as FilterPartInterpreter;
			inter.Engine = this.Engine;
			filtersPlugin.AddFilter (inter, specType.Attribute.Name);
		}
	}
}

public class FilterPartInterpreterAttribute : Attribute
{
	public string Name { get; set; }

	public FilterPartInterpreterAttribute (string name)
	{
		Name = name;
	}
}


public abstract class FilterPartInterpreter
{
	public ScriptEngine Engine;

	public abstract void Interpret (Expression[] args, CodeMemberMethod filterFunction);
}

public class HasComponentFilter : FilterPartInterpreter
{
	Type cmpType;
	string checkString;

	public HasComponentFilter (Type cmpType)
	{

		this.cmpType = cmpType;
		checkString = String.Format ("if(go.GetComponent((typeof({0})) == null) return false;", cmpType);
	}

	public override void Interpret (Expression[] args, CodeMemberMethod filterFunction)
	{
		if (args != null)
			Debug.Log ("Somehow has component filter has arguments");
		filterFunction.Statements.Add (new CodeSnippetStatement (checkString));
	}
}

[FilterPartInterpreter ("fit")]
public class FitFilter : FilterPartInterpreter
{
	string checkString;

	public FitFilter ()
	{

		checkString = "if(!{0}) return false;";
	}

	public override void Interpret (Expression[] args, CodeMemberMethod filterFunction)
	{
		if (args != null)
			Debug.Log ("Somehow has component filter has arguments");
		FunctionBlock block = new FunctionBlock (null, filterFunction, null);
		var expr = Engine.GetPlugin<ExpressionInterpreter> ().InterpretExpression (args [0], block);
		filterFunction.Statements.Add (new CodeSnippetStatement (String.Format (expr.ExprString, expr.ExprString)));
		//filterFunction.Statements.Add ();
	}
}