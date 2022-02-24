using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    // Item Count
    private static Dictionary<Item, int> _items = new Dictionary<Item, int>();
    public static Dictionary<Item, int> items
    {
    	get {return _items;}
    	private set {_items = value;}
    }

    // Conversion of name or tag to Item
    private static Dictionary<string, Item> nameToItem = new Dictionary<string, Item>();
    private static Dictionary<string, List<Item>> tagToItem = new Dictionary<string, List<Item>>();

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

    // Empty the inventory, but does not regenerate the other dictionaries
    public static void Reset()
    {
    	foreach (Item item in _items.Keys)
    	{
    		_items[item] = 0;
    	}
    }

    // Add the specified amount of an item
    public static void Add(Item item, int amount = 0)
    {
    	_items[item] += amount;
    }

    public static void Add(string itemName, int amount = 0)
    {
        Add(nameToItem[itemName], 0);
    }

    // Remove the specified amount of an item
    public static void Remove(Item item, int amount = 0)
    {
    	if (_items[item] <= amount)
    	{
    		_items[item] = 0;
    	}
    	else
    	{
    		_items[item] -= amount;
    	}
    }

    public static void Remove(string itemName, int amount = 0)
    {
        Remove(nameToItem[itemName], amount);
    }

    // Remove all of one item
    public static void RemoveAll(Item item)
    {
    	_items[item] = 0;
    }

    public static void RemoveAll(string itemName)
    {
        RemoveAll(nameToItem[itemName]);
    }
}
