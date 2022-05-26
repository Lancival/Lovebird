using Yarn.Unity;

public static class CommandHandlers
{
    // Inventory
    [YarnCommand("AddItem")]
    public static void AddItem(string itemName, int quantity = 1) => Inventory.Add(itemName, quantity);
    [YarnCommand("AddMoney")]
    public static void AddMoney(int quantity) => Money.AddMoney(quantity);

    // Quests
    [YarnCommand("AddQuest")]
    public static void AddQuest(string questName) => QuestManager.Add(questName);
    [YarnCommand("FinishQuest")]
    public static void FinishQuest(string questName) => QuestManager.FinishQuest(questName);
    [YarnCommand("CheckQuest")]
    public static void CheckQuest(string questName, string variableName) => VariableStorage.instance?.SetValue(variableName, QuestManager.CheckQuest(questName));

    [YarnCommand("OpenShop")]
    public static void OpenShop() => CanvasController.OpenTrade();
}
