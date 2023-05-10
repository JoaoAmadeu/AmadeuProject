using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Button inventoryButton;

    [SerializeField]
    private MenuInventory menuInventory;

    [SerializeField]
    private Inventory playerInventory;

    private void Start()
    {
        canvas.gameObject.SetActive(true);
        inventoryButton.onClick.AddListener(TogglePlayerInventory);

        TogglePlayerInventory(false);
    }

    private void TogglePlayerInventory (bool state)
    {
        if (state == false)
        {
            menuInventory.Close();
            inventoryButton.image.color = new Color(1, 1, 1, 0.66f);
            inventoryButton.transform.rotation = Quaternion.identity;
        }
        else
        {
            menuInventory.Open(playerInventory);
            inventoryButton.image.color = new Color(1, 1, 1, 1);
            inventoryButton.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
    }

    private void TogglePlayerInventory ()
    {
        if (menuInventory == null)
        {
            return;
        }

        if (playerInventory == null) 
        {
            return;
        }

        TogglePlayerInventory(!menuInventory.IsOpen);
    }
}
