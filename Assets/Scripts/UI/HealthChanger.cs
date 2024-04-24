using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _healthPoints;

    public void Increase()
    {
        _health.IncreaseHealth(_healthPoints);
    }

    public void Decrease()
    {
        _health.DecreaseHealth(_healthPoints);
    }
}
