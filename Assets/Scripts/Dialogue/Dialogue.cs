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
    
    [SerializeField] private Quest testquest;
    
    //had issues writing this way:
    //public static void addQuest()
    [YarnCommand("addQuest")]
    public static void addQuest(String questToBeAdded)
    {
        Debug.Log("Adding quest..." + questToBeAdded);
        QuestManager.Add(questToBeAdded);
    }

}
