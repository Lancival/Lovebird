using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private static CanvasController _instance;
    public static CanvasController instance => _instance;

    [Header("Canvases")]
        [SerializeField] private FadeCanvasGroup trade;
        [SerializeField] private Button tradeButton;
        [SerializeField] private Button inventory;
        [SerializeField] private Button questLog;
        [SerializeField] private Button map;
        [SerializeField] private Button settings;
        [SerializeField] private LineView dialogue;

    void Awake() => _instance = this;
    void OnDestroy() => _instance = null;

    public static void OpenTrade()
    {
        _instance?.trade?.FadeIn(0.5f);
        CanvasGroup canvasGroup = _instance?.trade?.gameObject.GetComponent<CanvasGroup>();
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        _instance?.tradeButton?.onClick?.Invoke();
    }
    public static void OpenInventory() => _instance?.inventory?.onClick?.Invoke();
    public static void OpenQuestLog() => _instance?.questLog?.onClick?.Invoke();
    public static void OpenSettings() => _instance?.settings?.onClick?.Invoke();
    public static void ContinueDialogue() => _instance?.dialogue?.OnContinueClicked();
    public static void OpenMap() => SceneLoader.instance?.LoadScene("Map");
}
