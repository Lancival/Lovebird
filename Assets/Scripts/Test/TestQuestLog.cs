using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuestLog : MonoBehaviour
{

	[SerializeField] private Quest quest;

    void Start()
    {
        QuestManager.Add(quest);
        QuestManager.ShowQuestLog();
    }
}
