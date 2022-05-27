using UnityEngine;

public class PickupInteractable : Interactable
{
    [SerializeField] private Item item;

    public override void Interact()
    {
        if (item != null)
        {
            Inventory.Add(item);
        }
        gameObject.SetActive(false);
    }
}
