using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : Interactive
{
    [SerializeField]
    private ItemAsset item;

    [SerializeField]
    private int quantity = 1;

    public override void Interact(Interactor interactor)
    {
        // Try to find a inventory on the Interactor gameObject. If failed, try the parent
        if (interactor.TryGetComponent<Inventory>(out Inventory inventory))
        {
            if (quantity > 0)
            {
                quantity--;
                inventory.AddItem(item);
            }
        }
        else if (interactor.transform.parent != null && 
            interactor.transform.parent.TryGetComponent<Inventory>(out inventory))
        {
            if (quantity > 0)
            {
                quantity--;
                inventory.AddItem(item);
            }
        }
    }
}
