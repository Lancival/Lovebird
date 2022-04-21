using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class QuestManager
{
    private static Dictionary<string, Quest> allQuests;

    private static List<Quest> _quests = new List<Quest>();
    public static List<Quest> quests
    {
        get => _quests;
        private set => _quests = value;
    }

    private static readonly int questStackLimit = 10;
    private static int questStack = 0;

    [RuntimeInitializeOnLoadMethod]
    private static void InitializeAllQuestDictionary()
    {
        allQuests = new Dictionary<string, Quest>();
        foreach (Quest quest in Resources.LoadAll("Quests", typeof(Quest)))
            allQuests.Add(quest.questName, quest);
    }

    public static void Reset()
    {
        _quests = new List<Quest>();
        UpdateQuestLog();
    }

    public static void Add(Quest quest)
    {
        if (quest == null)
        {
            return;
        }

        if (++questStack > questStackLimit)
        {
            --questStack;
            return;
        }

        _quests.Add(quest);
        if (quest.IsComplete())
            quest.Finish();
        else
            quest.Subscribe();

        UpdateQuestLog();
        --questStack;
    }

    public static void Add(string questName)
    {
        if (allQuests.ContainsKey(questName))
            Add(allQuests[questName]);
    }

    public static void Remove(Quest quest)
    {
        _quests.Remove(quest);
        UpdateQuestLog();
    }

    public static void ShowQuestLog(float duration = 1f) => QuestLog.instance?.ShowQuestLog(duration);
    public static void HideQuestLog(float duration = 1f) => QuestLog.instance?.HideQuestLog(duration);

    private static void UpdateQuestLog()
    {
        if (QuestLog.instance?.visible ?? false)
        {
            QuestLog.instance?.UpdateQuestText();
        }
    }
}
