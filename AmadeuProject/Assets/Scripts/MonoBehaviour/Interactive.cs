using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Receives an interaction and raises an event upon it.
/// </summary>
public class Interactive : MonoBehaviour
{
    /// <summary>
    /// Event raised when it receives an interaction from the Interactor
    /// </summary>
    [SerializeField, Tooltip("Event raised when it receives an interaction from the Interactor")]
    protected UnityEvent onGainInteraction;

    /// <summary>
    /// Optional dialog, for player feedback
    /// </summary>
    [SerializeField, Tooltip("Optional dialog, for player feedback")]
    protected DialogAsset dialog;

    public DialogAsset Dialog { get { return dialog; } }

    /// <summary>
    /// Receives the interaction.
    /// </summary>
    public virtual void Interact (Interactor interactor)
    {
        onGainInteraction?.Invoke();
    }
}
