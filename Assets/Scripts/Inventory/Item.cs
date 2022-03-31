using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Items", order = 1)]
public class Item : ScriptableObject
{
    [Header("Item Description")]
    	[Tooltip("The name of this item.")]
    	[SerializeField] private string _itemName;
    	public string itemName => _itemName;

    	[Tooltip("The description of this item.")]
    	[SerializeField] private string _description;
    	public string description => _description;

    	[Tooltip("The tags describing this item.")]
    	[SerializeField] private List<string> _tags;
    	public List<string> tags => _tags;

    	[Tooltip("The image for this item.")]
    	[SerializeField] private Sprite _sprite;
    	public Sprite sprite => _sprite;

    public bool HasTag(string tag) => tags.Contains(tag);
}
