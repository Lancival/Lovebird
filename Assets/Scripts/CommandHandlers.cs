using Yarn.Unity;

public static class CommandHandlers
{
    // Inventory
    [YarnCommand("AddItem")]
    public static void AddItem(string itemName, int quantity = 1) => Inventory.Add(itemName, quantity);
    [YarnCommand("AddMoney")]
    public static void AddMoney(int quantity) => Money.AddMoney(quantity);
    [YarnCommand("UpdateInventory")]
    public static void UpdateInventory()
    {
        VariableStorage.instance?.SetValue("$haveWoodScraps", Inventory.GetQuantity("Wood Scraps") > 0);
        VariableStorage.instance?.SetValue("$haveTornFabric", Inventory.GetQuantity("Torn Fabric") > 0);
        VariableStorage.instance?.SetValue("$haveGlassBottles", Inventory.GetQuantity("Glass Bottles") > 0);
        VariableStorage.instance?.SetValue("$haveLooseThread", Inventory.GetQuantity("Loose Thread") > 0);
        VariableStorage.instance?.SetValue("$haveLostGem", Inventory.GetQuantity("Lost Gem") > 0);
        VariableStorage.instance?.SetValue("$haveChomDoll", Inventory.GetQuantity("Chom Doll") > 0);
        VariableStorage.instance?.SetValue("$haveTrashBag", Inventory.GetQuantity("Trash Bag") > 0);
        VariableStorage.instance?.SetValue("$haveCans", Inventory.GetQuantity("Cans") > 0);
    }

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
