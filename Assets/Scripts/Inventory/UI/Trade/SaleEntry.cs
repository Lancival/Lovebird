using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]

public class SaleEntry : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;

    [HideInInspector] public Item item;

    public void UpdateDisplay()
    {
        if (item == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            image.sprite = item.sprite;
            itemName.text = item.name;
            itemPrice.text = item.price.ToString();
        }
    }

    public void AttemptPurchase()
    {
        if (item != null)
        {
            if (Money.Purchase(item.price))
            {
                Inventory.Add(item);
            }
        }
    }

    public void ShowDescription() => ItemDescription.instance?.Show(image.transform.position, item.name, item.description);
    public void HideDescription() => ItemDescription.instance?.Hide();
}
