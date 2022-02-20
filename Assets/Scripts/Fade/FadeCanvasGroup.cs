using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]

public class FadeCanvasGroup : MonoBehaviour
{

    private Canvas canvas;
	private CanvasGroup canvasGroup;
	private Coroutine fadeCoroutine = null;

	void Awake()
	{
        canvas = GetComponent<Canvas>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

    private static IEnumerator Fade(Canvas canvas, CanvasGroup canvasGroup, bool enabled, float startAlpha, float endAlpha, float duration)
    {
    	canvasGroup.gameObject.SetActive(true);
        canvas.enabled = true;
    	canvasGroup.alpha = startAlpha;

    	float startTime = Time.time;
    	float progress = 0;

    	while (true)
    	{
    		progress = (Time.time - startTime) / duration;
    		if (progress < 1)
    		{
    			canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
    		}
    		else
    		{
    			canvasGroup.alpha = endAlpha;
    			break;
    		}
    		yield return new WaitForEndOfFrame();
    	}

    	canvas.enabled = enabled;
    }

    public void Stop()
    {
    	if (fadeCoroutine != null)
    	{
    		StopCoroutine(fadeCoroutine);
    	}
    	fadeCoroutine = null;
    }

    public void FadeIn(float duration = 1f)
    {
    	Stop();
    	fadeCoroutine = StartCoroutine(Fade(canvas, canvasGroup, true, canvasGroup.alpha, 1f, duration));
    }

    public void FadeOutInactive(float duration = 1f)
    {
    	Stop();
    	fadeCoroutine = StartCoroutine(Fade(canvas, canvasGroup, false, canvasGroup.alpha, 0f, duration));
    }

    public void FadeOutActive(float duration = 1f)
    {
    	Stop();
    	fadeCoroutine = StartCoroutine(Fade(canvas, canvasGroup, true, canvasGroup.alpha, 0f, duration));
    }
}
