public static class ConditionChecker
{
	public static bool Check(Condition condition)
	{
		switch (condition.type)
		{
			case ConditionType.Always:
				return true;
			case ConditionType.Inventory:
				// TO DO
				break;
			case ConditionType.Dialogue:
				// TO DO
				break;
			case ConditionType.Never:
				return false;
		}
		return false;
	}
}