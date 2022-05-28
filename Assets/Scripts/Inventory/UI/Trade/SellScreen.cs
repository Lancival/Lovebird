using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]

public class SellScreen : InventoryDisplay
{
    [Header("Sales")]
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Button confirmButton;
        private Item currentItem;

    void Start() => gameObject.SetActive(false);

    protected override bool ShouldDisplay(KeyValuePair<Item,int> itemCount) => itemCount.Value > 0 && itemCount.Key.sellable;

    protected override ItemBox InstantiateItemBox()
    {
        ItemBox box = Instantiate(itemBoxPrefab, content.transform).GetComponent<ItemBox>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) =>
            {
                SetItem((PointerEventData) data, box);
            });
        box.gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        return box;
    }

    private void SetItem(PointerEventData data, ItemBox box)
    {
        currentItem = box.item;
        itemImage.sprite = currentItem.sprite;
        itemImage.enabled = true;
        priceText.text = currentItem.price.ToString();
        confirmButton.interactable = true;
    }

    public void Sell()
    {
        if (currentItem != null)
        {
            int quantity = Inventory.GetQuantity(currentItem);
            if (quantity > 0)
            {
                Inventory.Add(currentItem, -1);
                Money.AddMoney(currentItem.price);

                if (quantity == 1)
                {
                    confirmButton.interactable = false;
                    itemImage.enabled = false;
                    priceText.text = "--";
                }

                emptyInventory.SetActive(true);
                foreach (ItemBox itemBox in itemBoxes)
                {
                    itemBox.UpdateDisplay();
                    if (itemBox.gameObject.activeSelf)
                    {
                        emptyInventory.SetActive(false);
                    }
                }
            }
        }
    }
}
