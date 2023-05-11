using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Textual feedback
/// </summary>
[CreateAssetMenu(menuName = "Scriptables/Dialog")]
public class DialogAsset : ScriptableObject
{
    [SerializeField, Tooltip("Main attributes")]
    private Talk talk;

    /// <summary>
    /// Main attributes
    /// </summary>
    public Talk Talk { get { return talk; } }

    /// <summary>
    /// Proper instantiation of this class, allowing to use a construct at runtime.
    /// </summary>
    /// <param name="talk"></param>
    /// <returns></returns>
    public static DialogAsset CreateInstance (Talk talk)
    {
        var instance = ScriptableObject.CreateInstance<DialogAsset>();
        instance.talk = talk;
        return instance;
    }
}
