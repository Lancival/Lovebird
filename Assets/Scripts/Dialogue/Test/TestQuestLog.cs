using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuestLog : MonoBehaviour
{

	[SerializeField] private Quest quest;
	[SerializeField] private Item questToken;
    [SerializeField] private bool log;

    void Start()
    {
        QuestManager.Add(quest);
        QuestManager.ShowQuestLog();
    }

    public void AddQuestToken()
    {
    	Inventory.Add(questToken, 1);
        LogQuestTokens();
    }

    public void RemoveQuestToken()
    {
    	Inventory.Add(questToken, -1);
        LogQuestTokens();
    }

    private void LogQuestTokens()
    {
        if (log)
        {
            Debug.Log(string.Format("Number of quest tokens: {0}", Inventory.GetQuantity(questToken)));
        }
    }
}
