using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base asset that represents the result from a query. Should be extended for better use.
/// </summary>
[CreateAssetMenu(menuName = "Scriptables/Conditionals/Empty", order = 0)]
public class ConditionalAsset : ScriptableObject
{
    /// <summary>
    /// Output value
    /// </summary>
    [SerializeField, Tooltip("Output value")]
    protected bool permission;

    protected GameObject asker;

    /// <summary>
    /// Sets the output value
    /// </summary>
    /// <param name="value"></param>
    public virtual void SetPermission (bool value)
    {
        permission = value;
    }

    /// <summary>
    /// Asks for permission.
    /// </summary>
    /// <param name="asker">Is the responsible for asking permission</param>
    /// <returns></returns>
    public virtual bool GetPermission (GameObject asker)
    {
        this.asker = asker;
        return false;
    }
}
