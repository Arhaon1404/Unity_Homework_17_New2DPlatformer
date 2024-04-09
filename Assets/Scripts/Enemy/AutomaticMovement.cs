using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class AutomaticMovement : DirectionTowarder
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Direction * _speed;
    }
}