using InternalDSL;
using System.Collections.Generic;
public static class OperatorExtensions
{
	public static Operator Get(this Operator op, string id)
	{
		var ctx = op.Context as Table;
		if (ctx == null)
			return null;
		for (int j = 0; j < ctx.Entries.Count; j++)
		{
			var subOp = ctx.Entries [j] as Operator;
			if (subOp.Identifier as string == id)
				return subOp;
		}
		return null;
	}

	public static bool Has(this Operator op, string id)
	{
		return op.Get (id) != null;
	}

	public static List<Operator> GetAll(this Operator op, string id)
	{
		var ctx = op.Context as Table;
		if (ctx == null)
			return null;
		List<Operator> ops = new List<Operator> ();
		for (int j = 0; j < ctx.Entries.Count; j++)
		{
			var subOp = ctx.Entries [j] as Operator;
			if (subOp.Identifier as string == id)
				ops.Add(subOp);
		}
		return ops;
	}

	public static string Value(this Operator op)
	{
		var expr = op.Context as Expression;
		if (expr == null)
			return null;
		return expr.ToString ().ClearFromBraces ().Trim ();
	}


	public static string ArgValue(this Operator op, int index)
	{
		if (op.Args == null || op.Args.Count <= index)
			return null;
		return op.Args [index].ToString ().ClearFromBraces ().Trim ();
	}
	public static string GetValue(this Operator op, string id)
	{
		var subOp = op.Get (id);
		if (subOp == null)
			return null;
		else
			return subOp.Value ();
	}
	public static ExprAtom Atom(this Operator op)
	{
		var expr = op.Context as Expression;
		if (expr == null)
			return null;
		if (expr.Operands.Length == 0)
			return null;
		var atom = expr.Operands [0] as ExprAtom;
		return atom;
	}
	public static Scope Scope(this Operator op)
	{
		var atom = op.Atom ();
		if (atom == null)
			return null;
		return atom.Content as Scope;
	}

	public static FunctionCall Call(this Operator op)
	{
		var scope = op.Scope ();
		if (scope == null)
			return null;
		if (scope.Parts.Count == 0)
			return null;
		var ctor = scope.Parts[0] as FunctionCall;
		return ctor;
	}
}