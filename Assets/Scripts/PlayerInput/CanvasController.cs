using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private static CanvasController _instance;
    public static CanvasController instance => _instance;

    [SerializeField] private FadeCanvasGroup inventory;
    [SerializeField] private FadeCanvasGroup questLog;
    [SerializeField] private FadeCanvasGroup settings;

    void Awake() => _instance = this;
    void OnDestroy() => _instance = null;

    public static void OpenInventory() => _instance?.inventory?.FadeIn();
    public static void OpenQuestLog() => _instance?.questLog?.FadeIn();
    public static void OpenSettings() => _instance?.settings?.FadeIn();
    public static void OpenMap() => SceneLoader.instance?.LoadScene("Map");
}
