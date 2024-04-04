using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MovementControler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector3 Direction;

    private bool _isGrounded;
    private static int _jumpAnimation = Animator.StringToHash("isJump");
    private static int _fallAnimation = Animator.StringToHash("isFall");
    private static int _runAnimation = Animator.StringToHash("isRun");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isGrounded = true;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetBool(_runAnimation, true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetBool(_runAnimation, true);
        }
        else
        {
            _animator.SetBool(_runAnimation, false);
        }
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce,ForceMode2D.Impulse);
            }
        }

        ChangeJumpAnimation(_rigidbody.velocity.y);
        CheckGround(_rigidbody.velocity.y);
    }

    private void CheckGround(float velocityY)
    {
        _isGrounded = velocityY == 0;
    }

    private void ChangeJumpAnimation(float velocityY)
    {
        if (velocityY > 0)
        {
            _animator.SetBool(_jumpAnimation, true);
            _animator.SetBool(_fallAnimation, false);
        }
        else if (velocityY < 0)
        {
            _animator.SetBool(_jumpAnimation, false);
            _animator.SetBool(_fallAnimation, true);
        }
        else
        {
            _animator.SetBool(_jumpAnimation, false);
            _animator.SetBool(_fallAnimation, false);
        }
    }
}
