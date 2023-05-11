using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button that holds a reference to an asset item
/// </summary>
public class ItemButton : MonoBehaviour
{
    /// <summary>
    /// Image that will show the item asset thumbnail
    /// </summary>
    [SerializeField, Tooltip("Image that will show the item asset thumbnail")]
    private Image icon;

    /// <summary>
    /// Main button
    /// </summary>
    [SerializeField, Tooltip("Main button")]
    private Button button;

    private int inventoryIndex;

    public int InventoryIndex
    {
        get
        {
            return inventoryIndex;
        }
        set
        {
            inventoryIndex = value;
            button.interactable = (inventoryIndex >= 0);
        }
    }

    /// <summary>
    /// Changes the image thumbnail
    /// </summary>
    /// <param name="sprite"></param>
    public void SetIcon (Sprite sprite)
    {
        if (icon == null)
        {
            Debug.Log($"No icon found at {gameObject.name}");
            return;
        }

        if (sprite == null) 
        {
            icon.enabled = false;
        }
        else 
        {
            icon.enabled = true;
            icon.sprite = sprite;
        }
    }
}
