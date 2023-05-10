using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Button button;

    public void SetIcon (Sprite sprite)
    {
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
}
