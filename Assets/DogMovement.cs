using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : BaseMovement
{
    protected override void Move()
    {
        playerSpeed = 12f;
        playerTurnSpeed = 120f;
        jumpForce = 80f;
        base.Move();
    }
}
