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

	public delegate void SubscribeDelegate();
	public static void Subscribe(Condition condition, SubscribeDelegate subscribeDelegate)
	{
		switch (condition.type)
		{
			case ConditionType.Inventory:
				// TO DO
				break;
			case ConditionType.Dialogue:
				// TO DO
				break;
			default:
				return;
		}
	}
}