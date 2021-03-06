using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private static CanvasController _instance;
    public static CanvasController instance => _instance;

    [Header("Canvases")]
        [SerializeField] private UIScreen trade;
        [SerializeField] private UIScreen inventory;
        [SerializeField] private UIScreen questLog;
        [SerializeField] private Button map;
        [SerializeField] private UIScreen settings;
        [SerializeField] private LineView dialogue;

    void Awake() => _instance = this;
    void OnDestroy() => _instance = null;

    public static void OpenTrade() => _instance?.trade?.ChangeVisibility();
    public static void OpenInventory() => _instance?.inventory?.ChangeVisibility();
    public static void OpenQuestLog() => _instance?.questLog?.ChangeVisibility();
    public static void OpenSettings() => _instance?.settings?.ChangeVisibility();
    public static void ContinueDialogue() => _instance?.dialogue?.OnContinueClicked();
    public static void OpenMap() => _instance?.map?.onClick?.Invoke();
}
