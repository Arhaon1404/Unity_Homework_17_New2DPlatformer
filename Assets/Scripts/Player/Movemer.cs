using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AnimationChanger))]

public class Movemer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private AnimationChanger _animationChanger;

    private bool _isGrounded;
    private bool _isRight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<AnimationChanger>();
        _isGrounded = true;
    }

    private void Update()
    {
        ReadButtons();
    }

    private void ReadButtons()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _isRight = true;
            _animationChanger.ChangeDirectionAnimation(_isRight, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _isRight = false;
            _animationChanger.ChangeDirectionAnimation(_isRight, true);
        }
        else
        {
            _animationChanger.ChangeDirectionAnimation(_isRight, false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        _animationChanger.ChangeJumpAnimation(_rigidbody.velocity.y);
        CheckGround(_rigidbody.velocity.y);
    }

    private void CheckGround(float velocityY)
    {
        _isGrounded = velocityY == 0;
    }
}
