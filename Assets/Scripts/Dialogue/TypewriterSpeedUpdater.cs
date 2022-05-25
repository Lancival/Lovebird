using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(LineView))]

public class TypewriterSpeedUpdater : MonoBehaviour
{

    private LineView lineView;

    void Awake()
    {
        lineView = GetComponent<LineView>();
        Settings.TextDelay.onChange += SetTypewriter;
        SetTypewriter(Settings.TextDelay.Value);
    }

    void OnDestroy() => Settings.TextDelay.onChange -= SetTypewriter;

    public void SetTypewriter(float delay)
    {
        if (delay == 0)
        {
            lineView.useTypewriterEffect = false;
        }
        else
        {
            lineView.useTypewriterEffect = true;
            lineView.typewriterEffectSpeed = 1.0f / delay;
        }
    }
}
