using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hold Items
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemAsset> items = new ();

    public ItemAsset[] Items { get { return items.ToArray(); } }

    public void AddItem (ItemAsset item)
    {
        if (item == null)
        {
            Debug.Log($"Inventory {gameObject.name} is trying to add a null ItemAsset");
            return;
        }

        items.Add(item);
    }
}
