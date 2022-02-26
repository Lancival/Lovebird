using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Items", order = 1)]
public class Item : ScriptableObject
{
    [Header("Item Description")]
    	[Tooltip("The name of this item.")]
    	[SerializeField] private string _itemName;
    	public string itemName
    	{
    		get {return _itemName;}
    	}

    	[Tooltip("The description of this item.")]
    	[SerializeField] private string _description;
    	public string description
    	{
    		get {return _description;}
    	}

    	[Tooltip("The tags describing this item.")]
    	[SerializeField] private List<string> _tags;
    	public List<string> tags
    	{
    		get {return _tags;}
    	}

    	[Tooltip("The image for this item.")]
    	[SerializeField] private Sprite _sprite;
    	public Sprite sprite
    	{
    		get {return _sprite;}
    	}

    public bool HasTag(string tag)
    {
    	return (tags.Contains(tag));
    }
}
