using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
public class ItemBox : MonoBehaviour
{
    // Data
    [SerializeField] private Item _item;

    // Components
    private Image image;
    private GameObject counter;
    private TextMeshProUGUI counterText;

    void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        counter = transform.GetChild(1).gameObject;
        counterText = counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

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

    public void AddItem(int quantity)
    {
        Inventory.Add(_item, quantity);
    }
}
