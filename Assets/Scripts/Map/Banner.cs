using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FadeCanvasGroup))]
[RequireComponent(typeof(Image))]

public class Banner : MonoBehaviour
{
    private FadeCanvasGroup fader;
    private Image image;
    private int display = 0;

    void Awake()
    {
        fader = GetComponent<FadeCanvasGroup>();
        image = GetComponent<Image>();
    }

    public void FadeIn(Sprite sprite)
    {
        image.sprite = sprite;
        if (++display > 0)
        {
            fader.FadeIn();
        }
    }

    public void FadeOut()
    {
        if (--display <= 0)
        {
            fader.FadeOutInactive();
        }
    }
}
