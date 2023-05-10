using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInventory : MonoBehaviour
{
    [SerializeField]
    private RectTransform itemsGrid;

    private Inventory inventory;

    private ItemButton[] itemButtons;

    public bool IsOpen { get { return gameObject.activeInHierarchy; } }

    private void Awake()
    {
        if (itemsGrid)
        {
            itemButtons = itemsGrid.GetComponentsInChildren<ItemButton>();
        }
    }

    public void Close ()
    {
        gameObject.SetActive(false);
    }

    public void Open (Inventory inventory)
    {
        this.inventory = inventory;

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
