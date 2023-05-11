using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays an inventory in the UI
/// </summary>
public class MenuInventory : MonoBehaviour
{
    /// <summary>
    /// Transform that holds buttons, each representing an asset item
    /// </summary>
    [SerializeField, Tooltip("Transform that holds buttons, each representing an asset item")]
    private RectTransform itemsGrid;

    private Inventory inventory;

    private ItemButton[] itemButtons;

    /// <summary>
    /// Is this UI visible to the user?
    /// </summary>
    public bool IsOpen { get { return gameObject.activeInHierarchy; } }

    private void Awake()
    {
        GetButons();
    }

    private void GetButons ()
    {
        if (itemsGrid && itemButtons.Length == 0)
        {
            itemButtons = itemsGrid.GetComponentsInChildren<ItemButton>();
        }
        else
        {
            Debug.LogWarning($"No buttons found at menu inventory {gameObject.name}");
        }
    }

    /// <summary>
    /// Hide this UI
    /// </summary>
    public void Close ()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Show this inventory
    /// </summary>
    /// <param name="inventory"></param>
    public void Open (Inventory inventory)
    {
        this.inventory = inventory;
        GetButons();

        var items = inventory.Items;

        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (i < items.Length) 
            {
                itemButtons[i].SetIcon(items[i].Icon);
                itemButtons[i].InventoryIndex = i;
            }
            else
            {
                itemButtons[i].SetIcon(null);
                itemButtons[i].InventoryIndex = -1;
            }
        }

        gameObject.SetActive(true);
    }
}
