using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]

public class TriggerAnimationOnSceneLoad : MonoBehaviour
{

	private Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

    void Start()
    {
    	if (SceneLoader.instance != null)
    	{
    		SceneLoader.instance.onSceneLoad.AddListener(TriggerAnimation);
    	}
    	else
    	{
    		Debug.LogWarning($"{gameObject.name} was unable to find instance of SceneLoader.");
    	}
    }

    private void TriggerAnimation(float duration)
    {
    	animator.SetTrigger("onSceneLoad");
    }
}
