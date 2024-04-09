using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Animator))]

public class AnimationChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    private int _jumpAnimation = Animator.StringToHash("isJump");
    private int _fallAnimation = Animator.StringToHash("isFall");
    private int _runAnimation = Animator.StringToHash("isRun");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    public void ChangeDirectionAnimation(bool isRight, bool isRun)
    {
        _spriteRenderer.flipX = isRight;
        _animator.SetBool(_runAnimation, isRun);
    }

    public void ChangeJumpAnimation(float velocityY)
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
