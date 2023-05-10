using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemAsset : ScriptableObject
{
    [SerializeField]
    private string itemName;

    public string ItemName { get { return itemName; } }

    [SerializeField]
    private Sprite icon;

    public Sprite Icon { get { return icon; } }

    [SerializeField]
    private int price;

    public int Price { get { return price; } }
}
