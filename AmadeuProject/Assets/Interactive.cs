using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Receives an interaction and raises an event upon it.
/// </summary>
public class Interactive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Receives the interaction.
    /// </summary>
    public void Interact ()
    {
        Debug.Log("!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
