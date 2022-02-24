using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(FadeCanvasGroup))]

public class FadeOutOnStart : MonoBehaviour
{

	[SerializeField] private float duration = 1.0f;
	private FadeCanvasGroup fader;

    void Awake()
    {
    	fader = GetComponent<FadeCanvasGroup>();
    }

    void Start()
    {
    	fader.FadeOutInactive(duration);
    }
}
