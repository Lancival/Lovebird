using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] protected GameObject itemBoxPrefab;

    [Header("Other GameObjects")]
        [SerializeField] protected GameObject emptyInventory;
        [SerializeField] protected GameObject content;

    protected List<ItemBox> itemBoxes;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemBoxes = new List<ItemBox>();
    }

    protected virtual ItemBox InstantiateItemBox() => Instantiate(itemBoxPrefab, content.transform).GetComponent<ItemBox>();
    public void Show()
    {
        int itemDisplayCount = 0;
        foreach (KeyValuePair<Item,int> itemCount in Inventory.items)
        {
            if (itemCount.Value > 0)
            {
                if (itemBoxes.Count <= itemDisplayCount)
                {
                    itemBoxes.Add(InstantiateItemBox());
                }
                itemBoxes[itemDisplayCount++].SetItem(itemCount.Key);
            }
        }

        if (itemDisplayCount > 0)
        {
            content.SetActive(true);
            emptyInventory.SetActive(false);
            foreach (ItemBox box in itemBoxes)
            {
                box.UpdateDisplay();
            }
        }
        else
        {
            emptyInventory.SetActive(true);
            content.SetActive(false);
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(false);
    }
}
