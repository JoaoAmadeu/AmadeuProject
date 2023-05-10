using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a communication with an Interactive object.
/// </summary>
public class Interactor : MonoBehaviour
{
    [Tooltip ("The maximum distance to search for an Interactive object")]
    [SerializeField]
    private float maxDistance = 1.0f;

    private LayerMask rayLayerMask = Physics2D.AllLayers;

    public Ray ray { get; set; }

    /// <summary>
    /// Cast a raycast to find any Interactive object. If found, it will notify the other object.
    /// </summary>
    public void Interact ()
    {
        Debug.Log("!");
        var hits = Physics2D.RaycastAll(ray.origin, ray.direction, maxDistance, rayLayerMask);

        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<Interactive>(out Interactive interactive))
                {
                    if (interactive.gameObject != gameObject)
                    {
                        interactive.Interact(this);
                        return;
                    }
                }
            }
        }
        Debug.Log("@");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction.normalized * maxDistance);
        Gizmos.color = Color.white;
    }
}
