using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemAsset> items = new ();

    public ItemAsset[] Items { get { return items.ToArray(); } }

    public void AddItem (ItemAsset item)
    {
        items.Add(item);
        Debug.Log(item.name);
    }
}
