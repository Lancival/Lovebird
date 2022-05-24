using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int quantity;

    void Start()
    {
        Inventory.Add(item, quantity);
    }
}
