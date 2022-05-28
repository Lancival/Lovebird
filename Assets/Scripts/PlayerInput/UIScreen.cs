using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(FadeCanvasGroup))]

public class UIScreen : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private FadeCanvasGroup fader;

    [SerializeField] private float duration = 0.5f;
    [SerializeField] private bool active = false;

    public UnityEvent onShow;
    public UnityEvent onHide;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        fader = GetComponent<FadeCanvasGroup>();
    }

    void Start()
    {
        if (active)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        active = true;
        gameObject.SetActive(true);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        fader.FadeIn(duration);
        onShow?.Invoke();
    }

    private void Hide()
    {
        active = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        fader.FadeOutInactive(duration);
        onHide?.Invoke();
    }

    public void ChangeVisibility()
    {
        if (active)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
}
