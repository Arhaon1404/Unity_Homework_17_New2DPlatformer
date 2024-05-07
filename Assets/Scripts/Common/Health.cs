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
        _healthPoints = Math.Clamp(_healthPoints + amount, 0, _maxHealthPoints);

        HealthChangeInvoke();
    }

    public void Decrease(int amount)
    {
        _healthPoints = Math.Clamp(_healthPoints - amount, 0, _maxHealthPoints);

        if (_healthPoints == 0)
            DestroyCharacter();

        HealthChangeInvoke();
    }

    private void HealthChangeInvoke()
    {
        Changed?.Invoke();
    }
}
