using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : BaseMovement
{
    protected override void Move()
    {
        playerSpeed = 18f;
        playerTurnSpeed = 120f;
        jumpForce = 10f;
        base.Move();
    }
}
