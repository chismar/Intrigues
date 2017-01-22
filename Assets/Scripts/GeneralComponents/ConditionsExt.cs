using System.Collections.Generic;

public static class ConditionsExt
{
	public static bool Met<T>(this List<T> conditions) where T : TaskCondition
	{
		if (conditions == null)
			return true;

		bool met = true;
		for (int i = 0; i < conditions.Count; i++)
			if (!conditions [i].Update ()) {
				met = false;
				break;
			}
		return met;

	}
	public static bool CanBeSatisfiedBy<T>(this List<T> conditions, Agent agent) where T : TaskCondition
	{
		if (conditions == null)
			return true;
		bool canBeSatisfied = true;
		for (int i = 0; i < conditions.Count; i++) {
			if(!conditions[i].Met)
				canBeSatisfied = !agent.IsExternal(conditions[i]);
		}
		return canBeSatisfied;

	}
	public static TaskCondition Unsatisfied<T>(this List<T> conditions) where T : TaskCondition
	{
		if (conditions == null)
			return null;
		for (int i = 0; i < conditions.Count; i++)
			if (!conditions [i].Met)
				return conditions [i];
		return null;
	}

	public static void Update<T>(this List<T> conditions) where T : TaskCondition
	{
		if (conditions == null)
			return;
		for (int i = 0; i < conditions.Count; i++)
			conditions [i].Update ();
	}
}