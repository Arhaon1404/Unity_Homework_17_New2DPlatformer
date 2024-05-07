using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHealChecker : ColliderChecker
{
    protected override void CheckComponent(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Heal heal))
        {
            int healthPointsRestore = heal.HeathPointsRestore;
            DestroyObject(collision.gameObject);
            MainCharacter.GetComponent<Health>().Increase(healthPointsRestore);
        }
    }
}
