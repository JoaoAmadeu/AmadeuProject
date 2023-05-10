using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Receives an interaction and raises an event upon it.
/// </summary>
public class Interactive : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onInteract;

    /// <summary>
    /// Receives the interaction.
    /// </summary>
    public virtual void Interact (Interactor interactor)
    {
        onInteract?.Invoke();
        Debug.Log("Interact was called");
    }
}
