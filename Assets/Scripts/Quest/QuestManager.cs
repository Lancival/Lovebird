using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class QuestManager
{
    // List of all quests available in game
    private static Dictionary<string, Quest> allQuests;

    // List of currently active quests
    private static List<Quest> _quests = new List<Quest>();
    public static List<Quest> quests => _quests;

    // Initialize list of all quests
    [RuntimeInitializeOnLoadMethod]
    private static void InitializeAllQuestDictionary()
    {
        allQuests = new Dictionary<string, Quest>();
        foreach (Quest quest in Resources.LoadAll("Quests", typeof(Quest)))
        {
            allQuests.Add(quest.questName, quest);
        }
    }

    // Empty current list of active quests
    public static void Reset()
    {
        _quests = new List<Quest>();
        UpdateQuestLog();
    }

    // Add a new quest
    public static void Add(Quest quest)
    {
        if (quest == null || _quests.Contains(quest))
        {
            return;
        }

        _quests.Add(quest);
        if (quest.IsComplete())
        {
            quest.Finish();
        }
        else
        {
            quest.Subscribe();
        }

        UpdateQuestLog();
    }

    // Add a new active quest named questName, if it exists
    public static void Add(string questName)
    {
        if (allQuests.ContainsKey(questName))
        {
            Add(allQuests[questName]);
        }
    }

    // Remove a quest from the currently active list
    public static void Remove(Quest quest)
    {
        if (_quests.Remove(quest))
        {
            UpdateQuestLog();
        }
    }

    // Remove a quest named questName, if it exists
    public static void Remove(string questName)
    {
        if (allQuests.ContainsKey(questName))
        {
            Remove(allQuests[questName]);
        }
    }

    public static void FinishQuest(Quest quest) => quest.Finish();
    public static void FinishQuest(string questName)
    {
        if (allQuests.ContainsKey(questName))
        {
            FinishQuest(allQuests[questName]);
        }
    }

    public static bool CheckQuest(Quest quest)
    {
        return quests.Contains(quest) && quest.IsComplete();
    }
    public static bool CheckQuest(string questName)
    {
        if (allQuests.ContainsKey(questName))
        {
            return CheckQuest(allQuests[questName]);
        }
        return false;
    }

    // Call QuestLog functions to show, hide, and update the quest log, if it exists
    public static void ShowQuestLog(float duration = 1f) => QuestLog.instance?.ShowQuestLog(duration);
    public static void HideQuestLog(float duration = 1f) => QuestLog.instance?.HideQuestLog(duration);
    private static void UpdateQuestLog() => QuestLog.instance?.UpdateQuestText();}
