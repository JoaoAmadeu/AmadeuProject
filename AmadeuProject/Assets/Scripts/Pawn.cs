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

    private Interactor interactor;

    private CircleCollider2D circleCollider;

    private float animatorDirection;

    private void Awake()
    {
        driver = GetComponent<TopDownDriver>();
        animator = GetComponent<Animator>();
        interactor = GetComponent<Interactor>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
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
        if (!dontMove) 
        {
            UpdateInteractor();
        }
    }

    public void UpdateInteractor ()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y) + circleCollider.offset;
        interactor.ray = new Ray(origin, driver.DirectionAxis);
    }
}
