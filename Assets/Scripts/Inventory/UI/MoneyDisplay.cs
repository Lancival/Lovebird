using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]

public class MoneyDisplay : MonoBehaviour
{
    private TextMeshProUGUI counter;

    void Awake()
    {
        counter = GetComponent<TextMeshProUGUI>();
        UpdateDisplay(Money.GetMoney());
        Money.onChange += UpdateDisplay;
    }

    void OnDestroy() => Money.onChange -= UpdateDisplay;

    public void UpdateDisplay(int quantity) => counter.text = quantity.ToString();
}
