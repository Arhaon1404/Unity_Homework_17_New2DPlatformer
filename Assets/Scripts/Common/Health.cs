using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthPoints;
    [SerializeField] private float _maxHealthPoints;

    public event Action Changed;

    public float HealthPoints => _healthPoints;
    public float MaxHealthPoints => _maxHealthPoints;

    private void DestroyCharacter()
    {
        HealthChangeInvoke();
        Destroy(gameObject);
    }

    public void Increase(int amount)
    {
        if (amount > 0)
        {
            _healthPoints = Math.Clamp(_healthPoints + amount, 0, _maxHealthPoints);

            HealthChangeInvoke();
        }
    }

    public void Decrease(int amount)
    {
        if (amount > 0)
        {
            _healthPoints = Math.Clamp(_healthPoints - amount, 0, _maxHealthPoints);

            if (_healthPoints == 0)
                DestroyCharacter();

            HealthChangeInvoke();
        }
    }

    private void HealthChangeInvoke()
    {
        Changed?.Invoke();
    }
}
