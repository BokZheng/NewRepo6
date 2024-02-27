using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float Accel = 10f;
    public float jumpforce = 50f;

    public Transform GroundCheck;
    public float GroundCheckRadius = 1f;
    public float MaxSlpoeAngle = 45f;

    public LayerMask GroundLayerMask;

    protected bool isGround = false;
    protected bool isJump = false;

    protected Vector2 inputDirection;

    protected Rigidbody2D rb;
    protected Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        col= GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

    }

    void FixedUpdate()
    {
        CheckGround();

        HandleMovement();

    }

    protected virtual void HandleInput()
    {
        
    }
    protected virtual void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }

    void HandleMovement()
    {
        Vector3 targetVel = Vector3.zero;

        if (isGround && !isJump)
        {
            targetVel = new Vector2(inputDirection.x * (Accel), 0f);
        }
        else
        {
            targetVel = new Vector2(inputDirection.x * (Accel), rb.velocity.y);
        }

        rb.velocity = targetVel;
    }

    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayerMask);
        Debug.Log(isGround);

        if (isGround )
        {
            if (isJump)
            {
                Jump();
            }
        }
    }
}
