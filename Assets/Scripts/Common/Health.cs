using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _maxHealthPoints;

    public event Action HealthChange;

    public int HealthPoints => _healthPoints;
    public int MaxHealthPoints => _maxHealthPoints;

    private void DestroyCharacter()
    {
        HealthChangeInvoke();
        Destroy(gameObject);
    }

    public void IncreaseHealth(int numberIncreaseHealthPoint)
    {
        if ((_healthPoints + numberIncreaseHealthPoint) >= _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }
        else
        {
            _healthPoints += numberIncreaseHealthPoint;
        }

        HealthChangeInvoke();
    }

    public void DecreaseHealth(int numberDecreaseHealthPoint)
    {
        if ((_healthPoints - numberDecreaseHealthPoint) <= 0)
        {
            _healthPoints = 0;
            DestroyCharacter();
        }
        else
        {
            _healthPoints -= numberDecreaseHealthPoint;
        }

        HealthChangeInvoke();
    }

    private void HealthChangeInvoke()
    {
        HealthChange?.Invoke();
    }
}
