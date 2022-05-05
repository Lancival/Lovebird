using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Currently NOT used

public class buttonToPrevScene : MonoBehaviour
{
    private int prevSceneToLoad;
    
    void Start()
    {
        prevSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void buttonPreScene(string level)
    {
        SceneManager.LoadScene(prevSceneToLoad);
    }
}
