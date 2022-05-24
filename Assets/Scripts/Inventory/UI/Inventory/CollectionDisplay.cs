using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]

public class CollectionDisplay : MonoBehaviour
{
    [SerializeField] private GameObject itemBoxPrefab;
    [SerializeField] private GameObject itemCategoryPrefab;
    [SerializeField] private GameObject content;

    private List<ItemBox> itemBoxes;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemBoxes = new List<ItemBox>();
    }

    void Start()
    {
        foreach (KeyValuePair<string, List<Item>> itemCategory in Inventory.tagToItem)
        {
            GameObject grid = Instantiate(itemCategoryPrefab, content.transform);
            grid.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemCategory.Key;
            Transform gridTransform = grid.transform.GetChild(1);

            foreach (Item item in itemCategory.Value)
            {
                ItemBox box = Instantiate(itemBoxPrefab, gridTransform).GetComponent<ItemBox>();
                box.SetItem(item, true);
                itemBoxes.Add(box);
            }
        }
        gameObject.SetActive(false);
    }

    public void Show()
    {
        foreach (ItemBox box in itemBoxes)
        {
            box.UpdateDisplay();
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
