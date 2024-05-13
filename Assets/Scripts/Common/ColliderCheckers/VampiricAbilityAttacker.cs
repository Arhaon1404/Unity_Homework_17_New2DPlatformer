using System.Collections;
using UnityEngine;

public class VampiricAbilityAttacker : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private int _vampiricDamage;

    private Health _mainCharacterHealth;
    private Health _enemyHealth;

    private Coroutine _abilityCoroutine;
    private WaitForSeconds _coroutineDelay;
    private bool _isCoroutineDone = true;
    private bool inZone;

    private void Start()
    {
        _mainCharacterHealth = GetComponentInParent<Health>();
        _coroutineDelay = new WaitForSeconds(_delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health enemyHealth))
        {
            inZone = true;
            _enemyHealth = enemyHealth;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone = false;
    }

    private IEnumerator ActAbility()
    {
        float timeElapsed = 0;

        while (timeElapsed < _duration)
        {
            if (inZone)
            {
                _enemyHealth.Decrease(_vampiricDamage);
                _mainCharacterHealth.Increase(_vampiricDamage);
            }

            timeElapsed += Time.deltaTime;

            yield return _coroutineDelay;
        }

        _isCoroutineDone = true;
    }

    public void StartAbilityCoroutine()
    {
        if (_abilityCoroutine != null & _isCoroutineDone == true)
        {
            StopCoroutine(_abilityCoroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            _abilityCoroutine = StartCoroutine(ActAbility());
        }
    }
}
