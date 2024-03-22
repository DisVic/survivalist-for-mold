using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(PlayerAnimation))] 


public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    private bool _canMove;

    private PlayerCollisionHandler _collisionHandler;
    private PlayerAnimation _animation;
    private Rigidbody2D _rigidbody;

    private bool _isGrounded;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _animation = GetComponent<PlayerAnimation>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _canMove = true;
    }

    
    private void Update()
    {
        if (_canMove)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
                Jump();
        }
        TurnInMoveDirection();
        PlayAnimations();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void TurnInMoveDirection()
    {
        if (_rigidbody.velocity.x > 0.01f)
            transform.localScale = new Vector2(-1f, 1f);
        else if (_rigidbody.velocity.x < -0.01f)
            transform.localScale = new Vector2(1f, 1f);
    }
    public void Move()
    {
        if (_canMove == false) return;

        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
    private void PlayAnimations()
    {
        if (Mathf.Abs(_rigidbody.velocity.x) > 0.01f) _animation.Movement();
        else _animation.Idle();
    }
    public void EnableMove() => _canMove = true;
    public void DisableMove() => _canMove = false;
}
