using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttackerChecker : ColliderChecker
{
    protected override void CheckComponent(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character attackCharacter))
        {
            int attackerDamage = attackCharacter.GetComponent<Attacker>().Damage;
            MainCharacter.GetComponent<Health>().Decrease(attackerDamage);
        }
    }
}
