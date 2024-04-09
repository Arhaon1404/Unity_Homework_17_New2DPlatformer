using System;
using System.Collections;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    [SerializeField] private Character _mainCharacter;

    public event Action ItemCollected;

    private Coroutine _coroutine;
    private bool _isCoroutineDone = true;
    private bool _isColliding = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isColliding == false) 
        {
            if (collision.gameObject.TryGetComponent(out Character attackCharacter))
            {
                int attackerDamage = attackCharacter.GetComponent<Attacker>().GetDamage();
                _mainCharacter.GetComponent<Health>().DecreaseHealth(attackerDamage);
            }

            if (collision.gameObject.TryGetComponent(out Heal heal))
            {
                int healthPointsRestore = heal.GetHealthPoints();
                DestroyObject(collision.gameObject);
                _mainCharacter.GetComponent<Health>().IncreaseHealth(healthPointsRestore);
            }

            if (collision.gameObject.TryGetComponent(out Money money))
            {
                int points = money.GetMoneyPoints();
                DestroyObject(collision.gameObject);
                _mainCharacter.GetComponent<Score>().IncreaseScore(points);
            }

            _isColliding = true;
            RunCoroutine();
        }
    }

    private void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
        ItemCollected?.Invoke();
    }

    private IEnumerator CollidingReset()
    {
        yield return new WaitForEndOfFrame();

        _isColliding = false;

        _isCoroutineDone = true;
    }

    private void RunCoroutine()
    {
        if (_coroutine != null & _isCoroutineDone == true)
        {
            StopCoroutine(_coroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            _coroutine = StartCoroutine(CollidingReset());
        }
    }
}
