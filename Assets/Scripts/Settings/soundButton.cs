using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is for the sound effect of the button

public class soundButton : MonoBehaviour
{
    public AudioSource buttonSound;

    public void PlayButtonSound(){
        buttonSound.Play();
    }
}