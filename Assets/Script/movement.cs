using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class movement : MonoBehaviour
{
    public float Accel = 10f;
    public float jumpforce = 50f;

    public AudioClip jumpSound;
    private AudioSource audioSource;
    //public float BufferCheckRadius = 1f;
    //public Transform BufferCheck;
    public bool _IsBuff = false;
    public bool _preInput = false;

    public Transform GroundCheck;
    public float GroundCheckRadius = 1f;
    public float MaxSlpoeAngle = 45f;

    public cooldown CoyoteTime;
    public cooldown BufferJump;
    public bool CanJump = true;

    public LayerMask GroundLayerMask;

    public bool _isGrounded = false;
    public bool _isJump = false;
    public bool _isRun = false;
    public bool _isFall = false;
    
    public bool isJumping { get { return _isJump; } }
    public bool isRunning { get { return _isRun; } }
    public bool isGround { get { return _isGrounded; } }
    public bool isFalling { get { return _isFall; } }
    public bool FlipAnis;

    protected Vector2 inputDirection;

    protected Rigidbody2D rb;
    protected Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        col= GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {

            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = jumpSound;

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

        BufferJumping();

        Flip();
    }

    protected virtual void HandleInput()
    {
        
    }
    public virtual void DoJump()
    {
        if (!CanJump) return;

        if (!_isJump) return;

        if (CoyoteTime.CurrentProgress == cooldown.Progress.Finished) return;
        
        CanJump = false;
        _isJump = true;
        audioSource.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        
        _isJump = true;
        

        CoyoteTime.StopCooldown();

        
    }

    void HandleMovement()
    {
        Vector3 targetVel = Vector3.zero;

        if (_isGrounded && !_isJump)
        {
            targetVel = new Vector2(inputDirection.x * (Accel), 0f);
        }
        else
        {
            targetVel = new Vector2(inputDirection.x * (Accel), rb.velocity.y);
        }

        rb.velocity = targetVel;

        if (targetVel.x == 0)
        {
            _isRun = false;
            
        }
        else
        {
            _isRun = true;
            

        }
    }

    void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayerMask);
        Debug.Log(_isGrounded);



        if(rb.velocity.y <= 0)
        {

            _isJump = false;
        }

        if (_isGrounded && !isJumping)
        {
            
            CanJump = true;
            if (CoyoteTime.CurrentProgress != cooldown.Progress.Ready)
            {
                CoyoteTime.StopCooldown();
            }
        }

        if (!_isGrounded && !_isJump && CoyoteTime.CurrentProgress == cooldown.Progress.Ready)
        {
            CoyoteTime.StartCooldown();
          
        }
        
    }
    void BufferJumping()
    {
        _IsBuff = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius*20, GroundLayerMask);
        if (rb.velocity.y < 0 && !_isGrounded && _IsBuff)
        {
            BufferJump.StartCooldown();

            if (Input.GetButton("Jump"))
            {
                _preInput = true;
            }
        }
        if (_isGrounded)
        {
            BufferJump.StopCooldown();
        }
        if (_isGrounded && _preInput ==true)
        {
            DoJump();
            _preInput = false;
        }
    }
   
    protected virtual void Flip()
    {
        if(inputDirection.x == 0)
            return;

        if(inputDirection.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
            FlipAnis = false;

        }
        if(inputDirection.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            FlipAnis = true;
        }
    }
}
