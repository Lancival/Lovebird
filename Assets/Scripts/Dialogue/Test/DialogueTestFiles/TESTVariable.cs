using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TESTVariable : MonoBehaviour
{
    [YarnCommand("CHOMCHOM_CONVO_DONE")]
    public void CHOMCHOM_CONVO_DONE()
    {
        Debug.Log("Set convo to DONE.");
    }
}
