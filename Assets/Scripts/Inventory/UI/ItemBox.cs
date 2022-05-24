using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

    [SerializeField] private Material silhouetteMaterial;

    private bool isCollection = false;

    public void SetItem(Item item, bool collection = false)
    {
        _item = item;
        isCollection = collection;
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
        if (isCollection || quantity <= 1)
        {
            counter.SetActive(false);
        }
        else
        {
            counter.SetActive(true);
            counterText.text = quantity.ToString();
        }

        image.sprite = _item.sprite;
        if (isCollection)
        {
            if (Inventory.collection[_item] == false)
            {
                GetComponent<EventTrigger>().enabled = false;
                image.material = silhouetteMaterial;
            }
            else
            {
                GetComponent<EventTrigger>().enabled = true;
                image.material = null;
            }
        }
    }

    public void ShowDescription() => ItemDescription.instance?.Show(transform.position, _item.name, _item.description);
    public void HideDescription() => ItemDescription.instance?.Hide();
}
