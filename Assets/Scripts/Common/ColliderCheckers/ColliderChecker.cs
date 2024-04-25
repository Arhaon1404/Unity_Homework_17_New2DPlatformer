using System;
using System.Collections;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    [SerializeField] protected Character _mainCharacter;

    public event Action ItemCollected;

    protected Coroutine Coroutine;
    protected bool IsCoroutineDone = true;
    protected bool IsColliding = false;

    protected void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
        ItemCollected?.Invoke();
    }

    protected IEnumerator CollidingReset()
    {
        yield return new WaitForEndOfFrame();

        IsColliding = false;

        IsCoroutineDone = true;
    }

    protected void RunCoroutine()
    {
        if (Coroutine != null & IsCoroutineDone == true)
        {
            StopCoroutine(Coroutine);
        }

        if (IsCoroutineDone == true)
        {
            IsCoroutineDone = false;
            Coroutine = StartCoroutine(CollidingReset());
        }
    }
}
