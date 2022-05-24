using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    // Item Count
    private static Dictionary<Item, int> _items = new Dictionary<Item, int>();
    public static Dictionary<Item, int> items => _items;

    // Collection Progress
    private static Dictionary<Item, bool> _collection = new Dictionary<Item, bool>();
    public static Dictionary<Item, bool> collection => _collection;

    // Name/tag to item dictionaries
    private static Dictionary<string, Item> nameToItem = new Dictionary<string, Item>();
    private static Dictionary<string, List<Item>> _tagToItem = new Dictionary<string, List<Item>>();
    public static Dictionary<string, List<Item>> tagToItem => _tagToItem;

    // Inventory change handler dictionary
    public delegate bool InventoryChangeHandler(int quantity);
    private static Dictionary<string, List<InventoryChangeHandler>> changeHandlers = new Dictionary<string, List<InventoryChangeHandler>>();

    // Initialize the dictionaries on load
    [RuntimeInitializeOnLoadMethod]
    private static void Intialize()
    {
    	foreach (Item item in Resources.LoadAll("Items", typeof(Item)))
    	{
    		_items.Add(item, 0);
            _collection.Add(item, false);
            nameToItem.Add(item.itemName, item);
            foreach (string tag in item.tags)
            {
                if (!_tagToItem.ContainsKey(tag))
                {
                    _tagToItem.Add(tag, new List<Item>());
                }
                _tagToItem[tag].Add(item);
            }
    	}
    }

    // Empty the inventory and regenerate the changeHandler dictionary
    public static void Reset()
    {
    	foreach (Item item in _items.Keys)
    	{
    		_items[item] = 0;
            _collection[item] = false;
    	}
        changeHandlers = new Dictionary<string, List<InventoryChangeHandler>>();
    }

    // Run each of the InventoryChangeHandlers in the handlers list, with quantity as a parameter.
    // Returns a list of handlers which should be removed from the original list.
    private static List<InventoryChangeHandler> InvokeHandlers(List<InventoryChangeHandler> handlers, int quantity)
    {
        List<InventoryChangeHandler> handlersCopy = new List<InventoryChangeHandler>(handlers); // Running handlers may add new handlers, use copy of list instead
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
            return;
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

    // Set the quantity of an item equal to the specified amount, which should be non-negative
    public static void Set(Item item, int amount)
    {
        if (amount > 0)
        {
            _items[item] = amount;
            _collection[item] = true;
        }
        else
        {
            _items[item] = 0;
        }
        InvokeHandlers(item);
    }
    public static void Set(string itemName, int amount) => Set(nameToItem[itemName], amount);

    // Change the quantity of the item by the specified amount, which CAN be negative
    public static void Add(Item item, int amount = 1) => Set(item, _items[item] + amount);
    public static void Add(string itemName, int amount = 1) => Add(nameToItem[itemName], amount);

    // Remove all of one item
    public static void RemoveAll(Item item) => Set(item, 0);
    public static void RemoveAll(string itemName) => Set(itemName, 0);

    // Returns the quantity of an item or the total quantity over a type of item
    public static int GetQuantity(Item item) => _items[item];
    public static int GetQuantity(string nameOrTag)
    {
        if (nameToItem.ContainsKey(nameOrTag))
        {
            return _items[nameToItem[nameOrTag]];
        }
        else if (_tagToItem.ContainsKey(nameOrTag))
        {
            int quantity = 0;
            foreach (Item item in _tagToItem[nameOrTag])
            {
                quantity += _items[item];
            }
            return quantity;
        }
        else
        {
            Debug.LogWarning(string.Format("Inventory does not contain an item named or tagged {0}", nameOrTag));
            return -1;
        }
    }

    // Adds a InventoryChangeHandler that will be invoked when the quantity of the item or tag changes
    public static void Subscribe(string nameOrTag, InventoryChangeHandler handler)
    {
        if (!changeHandlers.ContainsKey(nameOrTag))
        {
            changeHandlers.Add(nameOrTag, new List<InventoryChangeHandler>());
        }
        changeHandlers[nameOrTag].Add(handler);
    }
}
