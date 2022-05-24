using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(FadeCanvasGroup))]
[RequireComponent(typeof(CanvasGroup))]

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject itemBoxPrefab;

    [Header("Other GameObjects")]
        [SerializeField] private GameObject emptyInventory;
        [SerializeField] private GameObject content;

    private List<ItemBox> itemBoxes;

    private FadeCanvasGroup fader;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        fader = GetComponent<FadeCanvasGroup>();
        canvasGroup = GetComponent<CanvasGroup>();

        itemBoxes = new List<ItemBox>();
        //gameObject.SetActive(false);
    }

    public void Show()
    {
        int itemDisplayCount = 0;
        foreach (KeyValuePair<Item,int> itemCount in Inventory.items)
        {
            if (itemCount.Value > 0)
            {
                if (itemBoxes.Count <= itemDisplayCount)
                {
                    itemBoxes.Add(Instantiate(itemBoxPrefab, content.transform).GetComponent<ItemBox>());
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
        fader.FadeIn();
    }

    public void Hide()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(false);
    }
}
