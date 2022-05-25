using UnityEngine;
using Yarn.Unity;

public class TESTDialogueYarnInteractable : MonoBehaviour
{
    private DialogueRunner RunnerTEST;
    public string conversationStartNode;
    private bool interactable = true;

    public void Start() 
    {
        RunnerTEST = FindObjectOfType<DialogueRunner>();
        StartConversation();
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
}
