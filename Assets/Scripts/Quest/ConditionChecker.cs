public static class ConditionChecker
{
	public static bool Check(Condition condition)
	{
		switch (condition.type)
		{
			case ConditionType.Always:
				return true;
			case ConditionType.Inventory:
				Compare(condition.comparison, Inventory.GetQuantity(condition.variable), condition.target);
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
				Inventory.Subscribe(condition.variable, (int quantity) => (InventoryHandler(condition.comparison, quantity, condition.target, subscribeDelegate)));
				break;
			case ConditionType.Dialogue:
				// TO DO
				break;
			default:
				return;
		}
	}

	private static bool InventoryHandler(Comparison comparison, int quantity, int target, SubscribeDelegate subscribeDelegate)
	{
		if (Compare(comparison, quantity, target))
		{
			subscribeDelegate();
			return true;
		}
		return false;
	}

	public static bool Compare(Comparison comparison, int variable, int target)
	{
		switch (comparison)
		{
			case Comparison.Equal:
				return variable == target;
			case Comparison.NotEqual:
				return variable != target;
			case Comparison.Greater:
				return variable > target;
			case Comparison.Less:
				return variable < target;
			case Comparison.GreaterOrEqual:
				return variable >= target;
			case Comparison.LessOrEqual:
				return variable <= target;
			default:
				return false;
		}
	}
}