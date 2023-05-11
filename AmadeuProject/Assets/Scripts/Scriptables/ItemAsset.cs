using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Asset representing an Item
/// </summary>
[CreateAssetMenu]
public class ItemAsset : ScriptableObject
{
    [SerializeField, Tooltip("Name for display")]
    private string itemName;

    /// <summary>
    /// Name for display
    /// </summary>
    public string ItemName { get { return itemName; } }

    
    [SerializeField, Tooltip("Thumbnail")]
    private Sprite icon;

    /// <summary>
    /// Thumbnail
    /// </summary>
    public Sprite Icon { get { return icon; } }

    [SerializeField, Tooltip("Monetary value")]
    private int price;

    /// <summary>
    /// Monetary value
    /// </summary>
    public int Price { get { return price; } }
}
