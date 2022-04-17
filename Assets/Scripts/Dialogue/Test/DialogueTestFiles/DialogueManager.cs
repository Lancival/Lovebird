using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<Dialogue> listofdialogue;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       listofdialogue = new Queue<Dialogue>();

        
    }
    public void StartDialogue(Dialogue testdialogue)
    {
        Debug.Log("Started speaking with " + testdialogue.NPCname);
    }

   
}
