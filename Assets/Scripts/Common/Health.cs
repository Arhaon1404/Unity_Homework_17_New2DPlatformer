using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _maxHealthPoints;

    private void DestroyCharacter()
    {
        Destroy(this.gameObject);
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
    }

    public void DecreaseHealth(int numberDecreaseHealthPoint)
    {
        if ((_healthPoints - numberDecreaseHealthPoint) <= 0)
        {
            DestroyCharacter();
        }
        else
        {
            _healthPoints -= numberDecreaseHealthPoint;
        }
    }
}
