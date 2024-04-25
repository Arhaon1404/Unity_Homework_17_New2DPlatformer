using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _maxHealthPoints;

    public event Action Changed;

    public int HealthPoints => _healthPoints;
    public int MaxHealthPoints => _maxHealthPoints;

    private void DestroyCharacter()
    {
        HealthChangeInvoke();
        Destroy(gameObject);
    }

    public void Increase(int amount)
    {
        if ((_healthPoints + amount) >= _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }
        else
        {
            _healthPoints += amount;
        }

        HealthChangeInvoke();
    }

    public void Decrease(int amount)
    {
        if ((_healthPoints - amount) <= 0)
        {
            _healthPoints = 0;
            DestroyCharacter();
        }
        else
        {
            _healthPoints -= amount;
        }

        HealthChangeInvoke();
    }

    private void HealthChangeInvoke()
    {
        Changed?.Invoke();
    }
}
