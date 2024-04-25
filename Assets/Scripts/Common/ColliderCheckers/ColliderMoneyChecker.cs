using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMoneyChecker : ColliderChecker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsColliding == false)
        {
            if (collision.gameObject.TryGetComponent(out Money money))
            {
                int points = money.MoneyPoints;
                DestroyObject(collision.gameObject);
                _mainCharacter.GetComponent<Score>().Increase(points);
            }

            IsColliding = true;
            RunCoroutine();
        }
    }
}
