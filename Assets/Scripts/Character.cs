using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _damage;

    public int health => _health;
    public int damage => _damage;

    private void GetDeath()
    {
        Destroy(this.gameObject);
    }

    public void GetDamage(int damagePoints)
    {
        _health -= damagePoints;

        if (_health == 0) GetDeath();
    }

    public void SetDamage(Character character)
    {
        character.GetDamage(_damage);
    }
}
