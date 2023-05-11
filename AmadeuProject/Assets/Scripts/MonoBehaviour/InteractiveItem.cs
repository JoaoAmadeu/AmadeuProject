using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive with functionality regarding the Inventory
/// </summary>
public class InteractiveItem : Interactive
{
    /// <summary>
    /// Asset of the item
    /// </summary>
    [SerializeField, Tooltip("Asset of the item")]
    private ItemAsset item;

    [SerializeField, Tooltip("How many are available")]
    private int quantity = 1;

    /// <summary>
    /// How many are available
    /// </summary>
    public int Quantity 
    {
        get 
        {
            return quantity; 
        }
        private set 
        { 
            quantity = value;
            if (quantity <= 0) 
            {
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        // If there is no dialog attached to this, a default is created
        if (dialog == null) 
        {
            Talk talk = new Talk();
            talk.entryText = $"The item {item.ItemName} has been added to your inventory.";
            dialog = DialogAsset.CreateInstance(talk);
        }
    }

    public override void Interact(Interactor interactor)
    {
        if (interactor== null) 
        {
            Debug.Log($"Interactor is null at {gameObject.name}");
            return;
        }

        // Try to find an inventory on the Interactor gameObject. If failed, try the parent
        if (interactor.TryGetComponent<Inventory>(out Inventory inventory))
        {
            if (Quantity > 0)
            {
                Quantity--;
                inventory.AddItem(item);
            }
        }
        else if (interactor.transform.parent != null && 
            interactor.transform.parent.TryGetComponent<Inventory>(out inventory))
        {
            if (Quantity > 0)
            {
                Quantity--;
                inventory.AddItem(item);
            }
        }
    }
}
