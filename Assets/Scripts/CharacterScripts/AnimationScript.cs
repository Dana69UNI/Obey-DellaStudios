using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator _animator;
    float jumpTimer=0f;
    void Start()
    {
        _animator = GetComponent<Animator>();

    }
    private void OnMovement()
    {
        _animator.SetBool("IsMoving", true);
    }

    private void OnMovementRelease()
    {
        _animator.SetBool("IsMoving", false);
    }

    private void OnJump()
    {
        StartCoroutine(jumpCD());
    }

    private IEnumerator jumpCD()
    {
        
        while (jumpTimer < 0.5f)
        {
            _animator.SetBool("IsJumping", true);
            jumpTimer += Time.deltaTime;
            yield return null;
        }
        jumpTimer = 0f;
        _animator.SetBool("IsJumping", false);
    }
}
