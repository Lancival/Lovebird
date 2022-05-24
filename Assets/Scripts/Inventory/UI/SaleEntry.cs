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
}
