using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup))]

public class SellScreen : InventoryDisplay
{
    void Start()
    {
        gameObject.SetActive(false);
    }
}
