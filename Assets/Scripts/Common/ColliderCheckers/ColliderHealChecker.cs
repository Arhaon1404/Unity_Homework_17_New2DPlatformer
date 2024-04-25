using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHealChecker : ColliderChecker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsColliding == false)
        {
            if (collision.gameObject.TryGetComponent(out Heal heal))
            {
                int healthPointsRestore = heal.HeathPointsRestore;
                DestroyObject(collision.gameObject);
                _mainCharacter.GetComponent<Health>().Increase(healthPointsRestore);
            }

            IsColliding = true;
            RunCoroutine();
        }
    }
}
