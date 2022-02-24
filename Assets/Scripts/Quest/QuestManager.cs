using System.Collections;
using System.Collections.Generic;

public static class QuestManager
{
    private static List<Quest> m_quests = new List<Quest>();
    public static List<Quest> quests
    {
        get {return m_quests;}
        private set {m_quests = value;}
    }

    public static void Reset()
    {
    	m_quests = new List<Quest>();
    }

    public static void Add(Quest quest)
    {
    	if (quest == null)
    	{
    		return;
    	}

    	m_quests.Add(quest);
    	if (quest.IsComplete())
    	{
    		quest.Finish();
    	}
    	else
    	{
    		quest.Subscribe();
    	}
    }

    public static void Remove(Quest quest)
    {
    	m_quests.Remove(quest);
    }

    public static void ShowQuestLog(float duration = 1f)
    {
        QuestLog.instance?.ShowQuestLog(duration);
    }

    public static void HideQuestLog(float duration = 1f)
    {
        QuestLog.instance?.HideQuestLog(duration);
    }
}
