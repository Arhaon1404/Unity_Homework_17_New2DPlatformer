using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class PathTargetChanger : MonoBehaviour
{
    [SerializeField] private float _allowableDistanceTarget;

    private Enemy _enemy;
    
    private Vector2[] _patrolPathArray;

    private int _count;

    private bool _isTargetPriority;

    public bool IsTargetPriority => _isTargetPriority;

    public Vector2 LastTarget => _patrolPathArray[_count++ % _patrolPathArray.Length];

    private void Start()
    {
        _isTargetPriority = false;

        _enemy = transform.GetComponent<Enemy>();

        _patrolPathArray = new Vector2[_enemy.PatrolPath.transform.childCount];

        for (int i = 0; i < _enemy.PatrolPath.transform.childCount; i++)
        {
            _patrolPathArray[i] = _enemy.PatrolPath.transform.GetChild(i).transform.position;
        }

        _count = 0;

        if (_patrolPathArray[_count] != null)
        {
            _enemy.SetTarget(_patrolPathArray[_count]);
        }
    }

    private void Update()
    {
        if (_isTargetPriority == false)
        {
            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, _enemy.Target) <= _allowableDistanceTarget)
        {
            _enemy.SetTarget(_patrolPathArray[_count++ % _patrolPathArray.Length]);
        }
    }

    public void SetPriorityTarget(bool isTargetPriority)
    {
        _isTargetPriority = isTargetPriority;
    }
}
