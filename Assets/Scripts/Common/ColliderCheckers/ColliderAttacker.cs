using UnityEngine;

public class ColliderAttacker : ColliderChecker
{
    private Health _health;

    private void Start()
    {
        _health = GetComponentInParent<Health>();
    }

    protected override void ActComponent(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Attacker attacker))
        {
            int attackerDamage = attacker.Damage;
            _health.Decrease(attackerDamage);
        }
    }
}
