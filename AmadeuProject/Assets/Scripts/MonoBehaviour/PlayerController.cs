using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

/// <summary>
/// Control the pawn through the user input
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Pawn associated with the player's input
    /// </summary>
    [SerializeField, Tooltip("Pawn associated with the player's input")]
    private Pawn pawn;

    /// <summary>
    /// UI that will display any text to the player.
    /// </summary>
    [SerializeField, Tooltip("UI that will display any text to the player.")]
    private TextDisplayer textDisplayer;

    /// <summary>
    /// Component that translate user input to pawn actions
    /// </summary>
    [SerializeField, Tooltip("Component that translate user input to pawn actions")]
    private PlayerInput playerInput;

    private void Start()
    {
        if (!CheckForPawn())
        {
            return;
        }

        pawn.Interactor.onHitInteraction.AddListener(InteractionFound);
    }

    /// <summary>
    /// Restrict user actions, when it creates a new interaction
    /// </summary>
    /// <param name="interactive"></param>
    private void InteractionFound (Interactive interactive)
    {
        if (interactive == null) 
        {
            Debug.Log($"Interaction with null interactive at {gameObject.name}");
            return;
        }

        textDisplayer.Display (interactive.Dialog, pawn.gameObject);
        playerInput.actions.FindAction("Move").Disable();
        textDisplayer.onEndDisplay.AddListener(RegainControl);
    }

    /// <summary>
    /// Resume user input, after the interaction is finished
    /// </summary>
    private void RegainControl ()
    {
        playerInput.actions.FindAction("Move").Enable();
        textDisplayer.onEndDisplay.RemoveListener(RegainControl);
    }

    /// <summary>
    /// Move pawn through the user's input
    /// </summary>
    /// <param name="context"></param>
    public void MovePawn(CallbackContext context)
    {
        if (!CheckForPawn())
        {
            return;
        }

        if (context.valueType == typeof(Vector2))
        {
            pawn.Driver.Move(context.ReadValue<Vector2>());
        }
    }

    /// <summary>
    /// Try to find an interaction, through the user's input
    /// </summary>
    /// <param name="context"></param>
    public void PawnInteraction (CallbackContext context)
    {
        if (!CheckForPawn())
        {
            return;
        }

        if (context.phase == InputActionPhase.Performed)
        {
            pawn.Interactor.Interact();
        }
    }

    /// <summary>
    /// Advance to the next text displaying, through the user's input
    /// </summary>
    /// <param name="context"></param>
    public void NextDisplayText (CallbackContext context)
    {
        if (!CheckForPawn())
        {
            return;
        }

        if (context.phase == InputActionPhase.Performed)
        {
            textDisplayer.NextStep();
        }
    }

    private bool CheckForPawn ()
    {
        if (pawn == null)
        {
            Debug.LogError($"No pawn found at controller {gameObject.name}");
            return false;
        }
        else
        {
            return true;
        }
    }
}
