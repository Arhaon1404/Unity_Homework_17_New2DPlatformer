using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private ZonePatrol _patrolPath;

    private Vector3 _target;

    public Vector3 Target => _target;
    public ZonePatrol PatrolPath => _patrolPath;

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
