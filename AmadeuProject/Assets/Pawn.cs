using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playable object. Can be machine or user controlled.
/// </summary>
public class Pawn : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    private Vector2 deltaMovement;

    [SerializeField]
    private Transform front;

    [SerializeField]
    private float movementSpeed = 3.0f;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Expensive operation, should be avoided
        if (front == null)
        {
            front = transform.Find("Front");
            Debug.Log($"transform.Find was used on {gameObject.name}");
        }
    }
    
    private void FixedUpdate()
    {
        rigidbody2D.position += deltaMovement * Time.fixedDeltaTime * movementSpeed;

        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            movement += Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            movement += Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            movement += Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            movement += Vector2.down;
        }

        Move(movement);
        front.right = (rigidbody2D.position + movement) - rigidbody2D.position;
    }

    /// <summary>
    /// Changes the position.
    /// </summary>
    /// <param name="delta">Value that will be added to the current position</param>
    public void Move(Vector2 delta)
    {
        deltaMovement = delta;
    }
}
