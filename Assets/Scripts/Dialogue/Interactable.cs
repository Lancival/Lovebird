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
    private DialogueRunner dialogueRunner;
    //public Dialogue IntroDialogue;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private float defaultIndicatorIntensity;
    public YarnProject IntroSceneProj;
    //public string startNode = Yarn.Dialogue.DefaultStartNodeName;
    public string startNode = "Start";
    //public Camera MainCam;
    //public Camera CamCHOM;

     //Define List of Cameras
    //private List<Camera> cameras;
    
    public void Start() 
    {
       // cameras.Add(MainCam);
       // cameras.Add(CamCHOM);
        //SwapCamera(MainCam);
        //dialogueRunner = FindObjectOfType<DialogueRunner>();
        //dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
        //dialogueRunner.onDialogueComplete.AddListener(EndConversation);
        
    }


    public void OnMouseDown() {
        if (interactable)
        {
        //if (interactable && !dialogueRunner.IsDialogueRunning) {
            StartConversation();
        }
    }

    private void StartConversation() {
        Debug.Log($"Started conversation with {name}.");
        //isCurrentConversation = true;
        //SwapCamera(CamCHOM);
        dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
        //dialogueRunner.StartDialogue(someStringVariable);
        dialogueRunner.StartDialogue(startNode);
    }

   /*  public void SwapCamera(Camera cam){
            // performance tradeoff
            foreach(Camera c in cameras){
                    c.enabled = false;
            }
            cam.enabled = true;
    } */

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
