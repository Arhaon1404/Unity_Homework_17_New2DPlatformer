using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMoneyChecker : ColliderChecker
{
    protected override void CheckComponent(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            int points = money.MoneyPoints;
            DestroyObject(collision.gameObject);
            MainCharacter.GetComponent<Score>().Increase(points);
        }
    }
}
