using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    // Item Count
    private static Dictionary<Item, int> _items = new Dictionary<Item, int>();
    public static Dictionary<Item, int> items
    {
    	get => _items;
    	private set => _items = value;
    }

    // Name/tag to item dictionaries
    private static Dictionary<string, Item> nameToItem = new Dictionary<string, Item>();
    private static Dictionary<string, List<Item>> tagToItem = new Dictionary<string, List<Item>>();

    // Inventory change dictionary
    public delegate bool InventoryChangeHandler(int quantity);
    private static Dictionary<string, List<InventoryChangeHandler>> changeHandlers = new Dictionary<string, List<InventoryChangeHandler>>();

    // Initialize the dictionaries on load
    [RuntimeInitializeOnLoadMethod]
    private static void Intialize()
    {
    	foreach (Item item in Resources.LoadAll("Items", typeof(Item)))
    	{
    		_items.Add(item, 0);
            nameToItem.Add(item.itemName, item);
            foreach (string tag in item.tags)
            {
                if (!tagToItem.ContainsKey(tag))
                {
                    tagToItem.Add(tag, new List<Item>());
                }
                tagToItem[tag].Add(item);
            }
    	}
    }

    // Empty the inventory and regenerate the changeHandler dictionary
    public static void Reset()
    {
    	foreach (Item item in _items.Keys)
    	{
    		_items[item] = 0;
    	}
        changeHandlers = new Dictionary<string, List<InventoryChangeHandler>>();
    }

    // Run each of the InventoryChangeHandlers in the handlers list, with quantity as a parameter.
    // Returns a list of handlers which should be removed from the original list.
    private static List<InventoryChangeHandler> InvokeHandlers(List<InventoryChangeHandler> handlers, int quantity)
    {
        List<InventoryChangeHandler> handlersCopy = new List<InventoryChangeHandler>(handlers);
        List<InventoryChangeHandler> removeHandlers = new List<InventoryChangeHandler>();
        foreach(InventoryChangeHandler handler in handlersCopy)
        {
            if (handler(quantity))
            {
                removeHandlers.Add(handler);
            }
        }
        return removeHandlers;
    }

    // Invoke the handlers associated with this item's names AND tags.
    private static void InvokeHandlers(Item item)
    {
        int quantity = _items[item];
        if (changeHandlers.ContainsKey(item.itemName))
        {
            foreach (InventoryChangeHandler removeHandler in InvokeHandlers(changeHandlers[item.itemName], quantity))
            {
                changeHandlers[item.itemName].Remove(removeHandler);
            }
        }
        foreach (string tag in item.tags)
        {
            if (changeHandlers.ContainsKey(tag))
            {
                quantity = GetQuantity(tag);
                foreach (InventoryChangeHandler removeHandler in InvokeHandlers(changeHandlers[tag], quantity))
                {
                    changeHandlers[tag].Remove(removeHandler);
                }
            }
        }
    }

    // Change the quantity of the item by the specified amount, which CAN be negative
    public static void Add(Item item, int amount = 1)
    {
    	_items[item] += amount;
        if (_items[item] < 0)
        {
            _items[item] = 0;
        }
        InvokeHandlers(item);
    }

    public static void Add(string itemName, int amount = 1)
    {
        Add(nameToItem[itemName], amount);
    }

    // Remove all of one item
    public static void RemoveAll(Item item)
    {
    	_items[item] = 0;
        InvokeHandlers(item);
    }

    public static void RemoveAll(string itemName)
    {
        RemoveAll(nameToItem[itemName]);
    }

    public static int GetQuantity(Item item)
    {
        return _items[item];
    }

    public static int GetQuantity(string variable)
    {
        int quantity = 0;
        if (nameToItem.ContainsKey(variable))
        {
            quantity = _items[nameToItem[variable]];
        }
        else if (tagToItem.ContainsKey(variable))
        {
            foreach (Item item in tagToItem[variable])
            {
                quantity += _items[item];
            }
        }
        else
        {
            Debug.LogWarning(string.Format("Inventory does not contain an item named or tagged {0}", variable));
            return -1;
        }

        return quantity;
    }

    public static void Subscribe(string variable, InventoryChangeHandler handler)
    {
        if (!changeHandlers.ContainsKey(variable))
        {
            changeHandlers.Add(variable, new List<InventoryChangeHandler>());
        }
        changeHandlers[variable].Add(handler);
    }
}
