using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Pawn pawn;

    private void Update()
    {
        if (pawn != null) 
        {
            //pawn.Driver ()
            //movement.normalized
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    movement += Vector2.left;
        //    direction = Direction.Left;
        //    isMoving = true;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    movement += Vector2.right;
        //    direction = Direction.Right;
        //    isMoving = true;
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    movement += Vector2.up;
        //    direction = Direction.Up;
        //    isMoving = true;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    movement += Vector2.down;
        //    direction = Direction.Down;
        //    isMoving = true;
        //}
    }
}
