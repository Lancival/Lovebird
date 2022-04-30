using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    
    [SerializeField] private Quest questToBeAdded;
    
    //had issues writing this way:
    //public static void addQuest()
    [YarnCommand("addQuest")]
    public void addQuest()
    {
        Debug.Log("Adding quest...");
        //QuestManager.Add(quest);
        QuestManager.Add(questToBeAdded);
    }

}
