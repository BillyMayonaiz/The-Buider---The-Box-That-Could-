using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : BaseMovement
{
    protected override void Move()
    {
        playerSpeed = 10f;
        playerTurnSpeed = 120f;
        jumpForce = 50f;
        base.Move();
    }
}
