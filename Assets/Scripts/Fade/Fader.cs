using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]

public abstract class Fader<T> : MonoBehaviour
{
    protected T fadeSubject;
    protected Coroutine fadeCoroutine = null;

    protected virtual void Awake()
    {
        fadeSubject = GetComponent<T>();
    }

    public abstract IEnumerator Fade(float startAlpha, float endAlpha, float duration, bool enabled);

    public virtual void Stop()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = null;
    }

    public virtual void FadeIn(float duration = 1f)
    {
        Stop();
        fadeCoroutine = StartCoroutine(Fade(0f, 1f, duration, true));
    }

    public virtual void FadeOutInactive(float duration = 1f)
    {
        Stop();
        fadeCoroutine = StartCoroutine(Fade(1f, 0f, duration, false));
    }

    public virtual void FadeOutActive(float duration = 1f)
    {
        Stop();
        fadeCoroutine = StartCoroutine(Fade(1f, 0f, duration, true));
    }
}
