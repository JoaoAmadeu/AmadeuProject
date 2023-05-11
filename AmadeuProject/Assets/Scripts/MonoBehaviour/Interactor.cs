using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Creates a communication with an Interactive object.
/// </summary>
public class Interactor : MonoBehaviour
{
    /// <summary>
    /// The maximum distance to search for an Interactive object
    /// </summary>
    [SerializeField, Tooltip("The maximum distance to search for an Interactive object")]
    private float maxDistance = 1.0f;

    /// <summary>
    /// Layer mask of the ray that will search for an Interactive object
    /// </summary>
    private LayerMask rayLayerMask = Physics2D.AllLayers;

    /// <summary>
    /// Event raised when an Interactive is found
    /// </summary>
    public UnityEvent<Interactive> onHitInteraction;

    /// <summary>
    /// Transform properties of the raycast
    /// </summary>
    public Ray ray { get; set; }

    /// <summary>
    /// Cast a raycast to find any Interactive object. If found, it will notify the other object.
    /// </summary>
    public void Interact ()
    {
        var hits = Physics2D.RaycastAll(ray.origin, ray.direction, maxDistance, rayLayerMask);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == gameObject)
            {
                continue;
            }

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<Interactive>(out Interactive interactive))
                {
                    onHitInteraction?.Invoke(interactive);
                    interactive.Interact(this);
                    return;
                }
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction.normalized * maxDistance);
        Gizmos.color = Color.white;
    }
#endif
}
