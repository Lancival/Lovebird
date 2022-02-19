using System.Collections;
using System.Collections.Generic;

public static class QuestManager
{
    private static List<Quest> quests = new List<Quest>();

    public static void Reset()
    {
    	quests = new List<Quest>();
    }

    public static void Add(Quest quest)
    {
    	if (quest == null)
    	{
    		return;
    	}

    	quests.Add(quest);
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
    	quests.Remove(quest);
    }
}
