using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]

public class BuyScreen : MonoBehaviour
{
    [SerializeField] private GameObject saleEntryPrefab;
    [SerializeField] private Transform content;

    [SerializeField] private Item[] itemsForSale;
    private List<SaleEntry> entries;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        entries = new List<SaleEntry>();
    }

    public void Show()
    {
        int i = 0;
        for (; i < itemsForSale.Length; i++)
        {
            if (entries.Count <= i)
            {
                entries.Add(Instantiate(saleEntryPrefab, content).GetComponent<SaleEntry>());
            }
            entries[i].item = itemsForSale[i];
            entries[i].UpdateDisplay();
        }
        for (; i < entries.Count; i++)
        {
            entries[i].UpdateDisplay();
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
