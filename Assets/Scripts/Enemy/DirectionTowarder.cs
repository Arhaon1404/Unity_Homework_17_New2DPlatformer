using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Enemy))]

public class DirectionTowarder : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    protected Enemy Enemy;
    protected Vector3 Direction;

    protected virtual void Start()
    {
        Enemy = transform.GetComponent<Enemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        Direction = Enemy.Target - transform.position;
        Direction.Normalize();

        _spriteRenderer.flipX = Direction.x > 0f;
    }
}
