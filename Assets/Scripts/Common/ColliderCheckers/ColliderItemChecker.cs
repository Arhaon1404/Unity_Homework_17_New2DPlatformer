using System;
using UnityEngine;

public class ColliderItemChecker : ColliderChecker
{
    public event Action ItemCollected;

    protected void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
        ItemCollected?.Invoke();
    }
}
