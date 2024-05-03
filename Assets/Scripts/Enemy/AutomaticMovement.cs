using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class AutomaticMovement : DirectionTowarder
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Direction * _speed;
    }

    protected override void Update()
    {
        base.Update();
    }
}