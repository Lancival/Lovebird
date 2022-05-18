using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]

public class FadeSpriteRenderer : Fader<SpriteRenderer>
{
    protected override float currentAlpha => fadeSubject.color.a;

    public override IEnumerator Fade(float startAlpha, float endAlpha, float duration, bool enabled)
    {
        SpriteRenderer renderer = fadeSubject;

        renderer.gameObject.SetActive(true);
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, startAlpha);

        float startTime = Time.time;
        float progress = 0;

        while (true)
        {
            progress = (Time.time - startTime) / duration;
            if (progress < 1)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Lerp(startAlpha, endAlpha, progress));
            }
            else
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, endAlpha);
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        renderer.gameObject.SetActive(enabled);
    }
}
