using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : movement
{
    public cooldown random;
    protected override void HandleInput()
    {
        inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButton("Jump"))
        {
            DoJump();
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
    }
}
