using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update The Start 
    //function will be called by Unity before gameplay begins 
    //(ie, before the Update function is called for the first time) 
    //and is an ideal place to do any initialization.
    private static DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private float defaultIndicatorIntensity;
    public string startNode = "Start";
    
    public Dialogue testdialogue;
    
    public void Start() 
    {
        dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
       
    }

    
    public void OnMouseDown() {
        if (interactable)
        {
            StartConversation();
        }
    }

    private void StartConversation() {
        Debug.Log($"Started conversation with {name}.");
        dialogueRunner.StartDialogue(startNode);
    }

    private void EndConversation() {
        if (isCurrentConversation) {
            isCurrentConversation = false;
            Debug.Log($"Ended conversation with {name}.");
        }
    }

//    [YarnCommand("disable")]
    public void DisableConversation() 
    {
        interactable = false;
    }

}
