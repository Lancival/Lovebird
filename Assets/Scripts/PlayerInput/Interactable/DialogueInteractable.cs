using UnityEngine;
using Yarn.Unity;

public class DialogueInteractable : Interactable
{
    private DialogueRunner dialogueRunner;
    private static DialogueInteractable currentDialogue = null;

    [SerializeField] private string startNode = "Start";
    
    new void Awake() => dialogueRunner = FindObjectOfType<DialogueRunner>();

    public override void Interact()
    {
        if (dialogueRunner.IsDialogueRunning && currentDialogue == this)
        {
            CanvasController.ContinueDialogue();
        }
        else if (dialogueRunner.IsDialogueRunning == false)
        {
            currentDialogue = this;
            dialogueRunner.StartDialogue(startNode);
        }
    }
}
