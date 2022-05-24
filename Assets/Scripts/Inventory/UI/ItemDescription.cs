using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]

public class ItemDescription : MonoBehaviour
{
    private static ItemDescription _instance;
    public static ItemDescription instance => _instance;

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI descriptionText;

    [SerializeField] private Vector2 offset = new Vector2(225, -150);

    void Awake()
    {
        _instance = this;
        nameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        descriptionText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    void OnDestroy() => _instance = null;

    public void Show(Vector2 position, string name, string description)
    {
        transform.position = position + offset;
        nameText.text = name;
        descriptionText.text = description;
        gameObject.SetActive(true);
    }

    public void Hide() => gameObject.SetActive(false);
}
