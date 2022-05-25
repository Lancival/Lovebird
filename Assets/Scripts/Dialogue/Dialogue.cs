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
    public string NPCname;
    
    public string[] sentences;
    [YarnCommand("addQuest")]
    public static void addQuest()
    {
        Debug.Log("Adding quest...");
    }

}
