using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item asset that represents a piece of clothing
/// </summary>
[CreateAssetMenu]
public class WearableAsset : ItemAsset
{
    /// <summary>
    /// Where it will be attached to
    /// </summary>
    [SerializeField, Tooltip("Where it will be attached to")]
    private BodyPart target;

    public BodyPart Target { get { return target; } }
}
