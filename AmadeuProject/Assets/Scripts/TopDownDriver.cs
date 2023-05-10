using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Moves a transform in the top-down grid. Also displays a facing direction.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class TopDownDriver : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 3.0f;

    private new Rigidbody2D rigidbody2D;

    private Vector2 deltaMovement;

    private bool isMoving;

    public bool IsMoving { get { return isMoving; } }

    public Direction Direction 
    {
        get
        {
            if (deltaMovement.x > 0)
            {
                return Direction.Right;
            }
            else if (deltaMovement.x < 0) 
            {
                return Direction.Left;
            }
            else if (deltaMovement.y > 0) 
            {
                return Direction.Up;
            }
            else if (deltaMovement.y < 0)
            {
                return Direction.Down;
            }
            
            return Direction.None;
        }
    }

    public Vector3 DirectionAxis
    {
        get
        {
            switch (Direction)
            {
                default:
                case Direction.None:
                    

                case Direction.Down:
                    return (transform.position + Vector3.down) - transform.position;

                case Direction.Right:
                    return (transform.position + Vector3.right) - transform.position;

                case Direction.Up:
                    return (transform.position + Vector3.up) - transform.position;

                case Direction.Left:
                    return (transform.position + Vector3.left) - transform.position;
            }
        }
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0.0f;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.drag = 0.0f;
    }

    private void FixedUpdate()
    {
        if (deltaMovement == Vector2.zero) 
        {
            isMoving = false;
        }
        else 
        {
            isMoving = true;
            rigidbody2D.position += deltaMovement * Time.fixedDeltaTime * movementSpeed;
        }
    }

    
    /// <summary>
    /// Changes the position.
    /// </summary>
    /// <param name="context">Value from the input system</param>
    public void Move (InputAction.CallbackContext context)
    {
        Move(context.ReadValue<Vector2>());
    }

    /// <summary>
    /// Changes the position.
    /// </summary>
    /// <param name="delta">Value that will be added to the current position</param>
    public void Move (Vector2 delta)
    {
        deltaMovement = delta;
    }
}