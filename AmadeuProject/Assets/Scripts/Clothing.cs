using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    [SerializeField, Tooltip("Animator for the torse and legs outfit")]
    private Animator outfitAnimator;

    [SerializeField, Tooltip("Animator for the back")]
    private Animator backAnimator;

    [SerializeField, Tooltip("Animator for the face")]
    private Animator faceAnimator;

    private Animator[] clothes;

    private void Awake()
    {
        clothes = new Animator[] {outfitAnimator, backAnimator, faceAnimator};
    }

    public void UpdateAnimations (bool isWalking, float direction)
    {
        foreach (var item in clothes)
        {
            if (item == null || !item.gameObject.activeInHierarchy)
            {
                continue;
            }

            item.SetBool("Walking", isWalking);
            item.SetFloat("FaceDirection", direction);
        }
    }
}
