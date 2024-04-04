using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class AutomaticMovement : DirectionTowarder
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    protected override void Start()
    {
        base.Start();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();

        _rigidbody.velocity = Direction * _speed;
    }
}