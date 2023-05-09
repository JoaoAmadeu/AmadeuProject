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

    [SerializeField]
    private LayerMask rayLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rayLayerMask = Physics2D.AllLayers;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Interact();
        }
    }

    /// <summary>
    /// Cast a raycast to find any Interactive object. If found, it will notify the other object.
    /// </summary>
    public void Interact ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxDistance, rayLayerMask);
        
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Interactive>(out Interactive interactive))
            {
                interactive.Interact();
            }
        }
    }

    /// <summary>
    /// Changes the layer mask used to detect the collider of the Interactive object.
    /// </summary>
    /// <param name="layerMask"></param>
    public void ChangeLayerMask (LayerMask layerMask)
    {
        rayLayerMask = layerMask;
    }
}
