using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]

public class FadeCanvasGroup : Fader<CanvasGroup>
{
    public override IEnumerator Fade(float startAlpha, float endAlpha, float duration, bool enabled)
    {
        CanvasGroup canvasGroup = fadeSubject;

        canvasGroup.gameObject.SetActive(true);
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

    	canvasGroup.gameObject.SetActive(enabled);
    }
}
