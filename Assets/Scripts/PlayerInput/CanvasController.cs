using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private static CanvasController _instance;
    public static CanvasController instance => _instance;

    [SerializeField] private float duration = 0.5f;

    [Header("Canvases")]
        [SerializeField] private FadeCanvasGroup inventory;
        [SerializeField] private FadeCanvasGroup questLog;
        [SerializeField] private FadeCanvasGroup settings;
        [SerializeField] private LineView dialogue;

    void Awake() => _instance = this;
    void OnDestroy() => _instance = null;

    public static void OpenInventory() => _instance?.inventory?.FadeIn(_instance.duration);
    public static void OpenQuestLog() => _instance?.questLog?.FadeIn(_instance.duration);
    public static void OpenSettings() => _instance?.settings?.FadeIn(_instance.duration);
    public static void ContinueDialogue() => _instance?.dialogue?.OnContinueClicked();
    public static void OpenMap() => SceneLoader.instance?.LoadScene("Map");
}
