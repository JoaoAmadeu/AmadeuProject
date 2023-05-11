using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Playable object. Moves, interact and can be interacted. It's controlled by a machine or user.
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TopDownDriver))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Interactor))]
[RequireComponent(typeof(Interactive))]
public class Pawn : MonoBehaviour
{
    private Animator animator;

    private TopDownDriver driver;

    public TopDownDriver Driver { get { return driver; } }

    public Interactor Interactor { get { return interactor; } }

    private Interactor interactor;

    private CircleCollider2D circleCollider;

    [SerializeField, Tooltip("Wearables to addorn the player")]
    private Clothing clothing;

    /// <summary>
    /// Float value used in the animator, to point the direction the pawn is facing.
    /// </summary>
    private float animatorDirection;

    private void Awake()
    {
        driver = GetComponent<TopDownDriver>();
        animator = GetComponent<Animator>();
        interactor = GetComponent<Interactor>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    /// <summary>
    /// Update animator values and the transform of the interactor
    /// </summary>
    private void Update()
    {
        if (animator == null) 
        {
            Debug.LogWarning($"Animator is null at {gameObject.name}");
        }
        if (interactor == null)
        {
            Debug.LogWarning($"Interactor is null at {gameObject.name}");
        }
        
        bool dontMove = false;
        switch (driver.Direction)
        {
            default:
            case Direction.None:
                dontMove = true;
                break;

            case Direction.Down:
                animatorDirection = 0.0f;
                break;

            case Direction.Right:
                animatorDirection = 0.34f;
                break;

            case Direction.Up:
                animatorDirection = 0.67f;
                break;

            case Direction.Left:
                animatorDirection = 1.0f;
                break;
        }

        animator.SetBool("Walking", driver.IsMoving);
        animator.SetFloat("FaceDirection", animatorDirection);
        if (clothing != null)
        {
            clothing.UpdateAnimations(driver.IsMoving, animatorDirection);
        }
        if (!dontMove) 
        {
            Vector2 origin = new Vector2(transform.position.x, transform.position.y) + circleCollider.offset;
            interactor.ray = new Ray(origin, driver.DirectionAxis);
        }
    }
}
