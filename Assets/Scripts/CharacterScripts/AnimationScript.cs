using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator _animator;
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
}
