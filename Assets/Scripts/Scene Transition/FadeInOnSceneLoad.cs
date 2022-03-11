using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(FadeCanvasGroup))]

public class FadeInOnSceneLoad : MonoBehaviour
{
	private FadeCanvasGroup fader;

    void Awake() => fader = GetComponent<FadeCanvasGroup>();

    void Start()
    {
    	if (SceneLoader.instance == null)
    	{
    		Debug.LogWarning("No instance of SceneLoader exists.");
    		Destroy(this);
    	}
    	else
    	{
    		SceneLoader.instance.onSceneLoad.AddListener(fader.FadeIn);
    	}
    }
}
