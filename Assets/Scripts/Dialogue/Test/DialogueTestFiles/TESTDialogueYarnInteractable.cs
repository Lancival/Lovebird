using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;


// this file is attached to every character in the scene and so will affect only
// the targeted character object when functions are called

// disable scene interaction, activate speaker indicator, and
// run dialogue from {conversationStartNode}


public class TESTDialogueYarnInteractable : MonoBehaviour
{
    
    private DialogueRunner RunnerTEST;
    public string conversationStartNode;
    //private bool isinteractable = true;
    //private bool isconvoalreadyhappening = false;
    private bool interactable = true;
    

    public void Start() 
    {
        RunnerTEST = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    private void StartConversation() 
    {
        RunnerTEST.StartDialogue(conversationStartNode);
    }

    public void OnMouseDown() 
    {
    // if this character is enabled and no conversation is already running
        if (interactable) 
        {
        // then run this character's conversation
            StartConversation();
        }
    }
    // Update is called once per frame

}
