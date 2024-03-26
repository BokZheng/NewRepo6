using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class token : MonoBehaviour
{
    playermovement _movement;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _movement = collision.GetComponent<playermovement>();
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            _movement._isGrounded = true;
            _movement.CanJump = true;
            _movement._isJump = false;

            if (Input.GetButton("Jump"))
            {
                _movement.DoJump();
                _movement._isJump = true;
            }
            else
            {
                _movement._isJump = false;
            }
        }
    }
}
