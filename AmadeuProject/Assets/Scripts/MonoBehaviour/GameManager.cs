using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage and link all classess to give proper response to its actions.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("HUD button responsible for opening the player inventory.")]
    private Button inventoryButton;

    [SerializeField, Tooltip("UI of player's inventory.")]
    private MenuInventory menuInventory;

    [SerializeField, Tooltip("Inventory to feed to the UI")]
    private Inventory playerInventory;

    [SerializeField, Tooltip("UI that will display any text to the player.")]
    private TextDisplayer textDisplayer;

    [SerializeField]
    private DialogAsset shopkeeperDialog;

    [SerializeField]
    private GameObject shoopingMenu;

    private void Start()
    {
        shopkeeperDialog.Talk.onNextStep.AddListener (() => shoopingMenu.SetActive(true));

        if (inventoryButton != null)
        {
            inventoryButton.onClick.AddListener(TogglePlayerInventory);
        }
        else
        {
            Debug.LogWarning("Inventory HUD button not found");
        }


        textDisplayer.Hide();
        
        TogglePlayerInventory(false);
    }

    /// <summary>
    /// Change the visibility of the player's UI inventory
    /// </summary>
    /// <param name="state"></param>
    private void TogglePlayerInventory (bool state)
    {
        if (menuInventory == null)
        {
            Debug.LogError("Inventory UI not found");
            return;
        }

        if (playerInventory == null)
        {
            Debug.LogError("Player inventory not found");
            return;
        }

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
        TogglePlayerInventory(!menuInventory.IsOpen);
    }
}
