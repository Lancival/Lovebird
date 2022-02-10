using System.Collections;
using System.Collections.Generic;

public static class QuestManager
{
    private static List<Quest> quests = new List<Quest>();

    public static void Reset()
    {
    	quests = new List<Quest>();
    }

    public static void AddQuest(QuestInformation info)
    {
    	quests.Add(new Quest(info));
    }
}
