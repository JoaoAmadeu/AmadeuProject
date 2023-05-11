using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Conditional that will query if the asker has a specific Item in its inventory
/// </summary>
[CreateAssetMenu(menuName = "Scriptables/Conditionals/Item", order = 1)]
public class ItemConditional : ConditionalAsset
{
    /// <summary>
    /// Item to search for
    /// </summary>
    [SerializeField, Tooltip("Item to search for")]
    private ItemAsset item;

    public override void SetPermission (bool value)
    {
        // not allowed for public alteration
    }

    /// <summary>
    /// Will search the asker for an Inventory and then search for specific Item, inside of it
    /// </summary>
    /// <param name="asker">Where to search for an inventory</param>
    /// <returns></returns>
    public override bool GetPermission (GameObject asker)
    {
        if (asker.TryGetComponent<Inventory>(out Inventory inventory)) 
        {
            return inventory.Items.Contains(item);
        }
        else
        {
            return false;
        }
    }
}
