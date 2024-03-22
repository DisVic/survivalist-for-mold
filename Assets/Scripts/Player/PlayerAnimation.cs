using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Movement()
    {
        _animator.SetInteger("MovementSpeed", 1);
    }
    public void Idle()
    {
        _animator.SetInteger("MovementSpeed", 0);
    }
}
