using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WearableAsset : ItemAsset
{
    [SerializeField]
    private BodyPart target;

    public BodyPart Target { get { return target; } }
}
