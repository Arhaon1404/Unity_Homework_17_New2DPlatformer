using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttackerChecker : ColliderChecker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsColliding == false)
        {
            if (collision.gameObject.TryGetComponent(out Character attackCharacter))
            {
                int attackerDamage = attackCharacter.GetComponent<Attacker>().Damage;
                _mainCharacter.GetComponent<Health>().Decrease(attackerDamage);
            }

            IsColliding = true;
            RunCoroutine();
        }
    }
}
