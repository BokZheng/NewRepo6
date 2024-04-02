using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class animatorhandler : MonoBehaviour
{
    private Animator _animator;
    private movement _movement;

    private Vector3 _initialScale = Vector3.one;
    private Vector3 _flipScale = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = transform.parent.GetComponent<movement>();

        _initialScale = transform.localScale;
        _flipScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    void HandleFlip()
    {
        if (_movement == null)
        {
            return;
        }

        transform.localScale = _movement.FlipAnis? _flipScale : _initialScale;
    }

    
    void UpdateAnimator()
    {
        if (_movement == null)
        { 
            return;
        }

        Debug.Log(_movement.isRunning);
        _animator.SetBool("IsRunning", _movement.isRunning);
        _animator.SetBool("IsJumping", _movement.isJumping);
        _animator.SetBool("IsFalling", _movement.isFalling);
        
    }
}
