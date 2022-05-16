using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Items", order = 1)]
public class Item : ScriptableObject
{
    [HideInInspector]
        public string itemName => this.name;

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

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        // Note: In the import settings for the sprite, the read/write checkbox must be checked!
        Sprite sprite = ((Item) serializedObject.targetObject).sprite;
        if (sprite != null)
        {
            Texture2D croppedTexture = new Texture2D((int) sprite.rect.width, (int) sprite.rect.height);
            Color[] pixels = sprite.texture.GetPixels(
                (int) sprite.rect.x,
                (int) sprite.rect.y,
                (int) sprite.rect.height,
                (int) sprite.rect.width
            );
            croppedTexture.SetPixels(pixels);
            croppedTexture.Apply();
            return croppedTexture;
        }
        else
        {
            return null;
        }
    }
}