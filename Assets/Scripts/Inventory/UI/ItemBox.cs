using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
public class ItemBox : MonoBehaviour
{
    // Data
    private Item _item;

    // Components
    [SerializeField] private Image image;
    [SerializeField] private GameObject counter;
    [SerializeField] private TextMeshProUGUI counterText;

    public void SetItem(Item item)
    {
        _item = item;
    }

    public void UpdateDisplay()
    {
        if (_item == null)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);

        int quantity = Inventory.GetQuantity(_item);
        if (quantity <= 1)
        {
            counter.SetActive(false);
        }
        else
        {
            counter.SetActive(true);
            counterText.text = quantity.ToString();
        }

        image.sprite = _item.sprite;
    }

    public void ShowDescription() => ItemDescription.instance?.Show(transform.position, _item.name, _item.description);
    public void HideDescription() => ItemDescription.instance?.Hide();
}
