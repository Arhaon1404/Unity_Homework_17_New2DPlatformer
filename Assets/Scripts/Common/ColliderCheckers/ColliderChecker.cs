using System.Collections;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    protected Coroutine Coroutine;
    protected bool IsCoroutineDone = true;
    protected bool IsColliding = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsColliding == false)
        {
            ActComponent(collision);

            IsColliding = true;
            RunCoroutine();
        }
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

    protected virtual void ActComponent(Collider2D collision) { }
}
