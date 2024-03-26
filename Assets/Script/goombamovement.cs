using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombamovement : movement
{
    protected bool FlipDirection = false;

    protected override void HandleInput()
    {
        if (FlipDirection)
        {
            inputDirection = Vector2.left;
        }
        else
        {
            inputDirection = Vector2.right;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Boun"))
        { return; }

        FlipDirection = !FlipDirection;
    }
}
