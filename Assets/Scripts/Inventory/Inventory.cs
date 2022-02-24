using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    private static Dictionary<Item, int> _items = new Dictionary<Item, int>();
    public static Dictionary<Item, int> items
    {
    	get {return _items;}
    	private set {_items = value;}
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Intialize()
    {
    	foreach (Item item in Resources.LoadAll("Items", typeof(Item)))
    	{
    		_items.Add(item, 0);
    	}
    }

    public static void Reset()
    {
    	foreach (Item item in _items.Keys)
    	{
    		_items[item] = 0;
    	}
    }

    public static void Add(Item item, int amount = 0)
    {
    	_items[item] += amount;
    }

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

    public static void RemoveAll (Item item)
    {
    	_items[item] = 0;
    }
}
