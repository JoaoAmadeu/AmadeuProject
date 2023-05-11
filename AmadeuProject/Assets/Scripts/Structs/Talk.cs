using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Value only class, for textual feedback and context redirection based on a state from the game
/// </summary>
[Serializable]
public class Talk
{
    /// <summary>
    /// First text that will be displayed. Can be optional, if there is a conditional
    /// </summary>
    [Tooltip("First text that will be displayed. Can be optional, if there is a conditional")]
    public string entryText;

    /// <summary>
    /// Text displayed, when the conditional returns a positive value
    /// </summary>
    [Tooltip("Text displayed, when the conditional returns a positive value")]
    public string textAllowed;

    /// <summary>
    /// Text displayed, when the conditional returns a negative value
    /// </summary>
    [Tooltip("Text displayed, when the conditional returns a negative value")]
    public string textDenied;

    /// <summary>
    /// The dialog with the highest value, will be the first to be picked
    /// </summary>
    [Tooltip("Text displayed, when the conditional returns a negative value")]
    public int priority;

    /// <summary>
    /// Query that will choose the next state. Can be optional
    /// </summary>
    [Tooltip("Query that will choose the next state. Can be optional")]
    public ConditionalAsset conditional;

    // The Talk class can't have a instance of itself because it will mess with the serialization.
    // The solution is to have a reference to the asset that holds this class.
    /// <summary>
    /// Next dialog that will be displayed. Can be optional
    /// </summary>
    public DialogAsset nextDialog;

    /// <summary>
    /// Callback for when this dialog is finished.
    /// </summary>
    [Tooltip("Callback for when this dialog is finished.")]
    public UnityEvent onNextStep;
}
