using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class VampiricAbilityAttacker : MonoBehaviour
{
    [SerializeField] private Health _mainCharacterHealth;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _vampiricDamage;

    private List<Health> _enemyList = new List<Health>();

    private Coroutine _abilityCoroutine;
    private Coroutine _cooldownCoroutine;
    private WaitForSeconds _coroutineDelay;

    private SpriteRenderer _spriteRenderer;

    private bool _isCoroutineDone = true;
    private bool _inZone;

    private float _generalCooldown;
    private float _residualVampiricDamage;
    public float GeneralCooldown => _generalCooldown;

    public event Action CooldownUpdate;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _coroutineDelay = new WaitForSeconds(_delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health enemyHealth))
        {
            _inZone = true;
            _enemyList.Add(enemyHealth);
            _spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health enemyHealth))
        {
            _enemyList.Remove(enemyHealth);

            if (_enemyList.Count == 0)
            {
                _inZone = false;
                _spriteRenderer.enabled = false;
            }
        }
    }

    public void StartAbilityCoroutine()
    {
        if (_generalCooldown <= 0)
        {
            if (_abilityCoroutine != null && _isCoroutineDone == true)
            {
                StopCoroutine(_abilityCoroutine);
                StopCoroutine(_cooldownCoroutine);
            }

            if (_isCoroutineDone == true)
            {
                _isCoroutineDone = false;
                _abilityCoroutine = StartCoroutine(ActAbility());
            }
        }
    }

    private IEnumerator ActAbility()
    {
        float timeElapsed = _duration;
        _generalCooldown = 0;

        while (timeElapsed >= 0)
        {
            timeElapsed = CheckObjectInZone(timeElapsed);

            yield return _coroutineDelay;
        }

        _cooldownCoroutine = StartCoroutine(StartCooldown());

        _isCoroutineDone = true;
    }

    private IEnumerator StartCooldown()
    {
        _generalCooldown = _cooldown;

        while (_generalCooldown > 0)
        {
            _generalCooldown -= Time.deltaTime;
            yield return null;
            CooldownUpdate.Invoke();
        }
    }

    private float CheckObjectInZone(float timeElapsed)
    {
        if (_inZone)
        {
            float remainingHealth = _vampiricDamage - _enemyList[0].HealthPoints;

            _residualVampiricDamage = remainingHealth > 0 ? remainingHealth : 0;

            _enemyList[0].Decrease(_vampiricDamage);
            _mainCharacterHealth.Increase(_vampiricDamage - _residualVampiricDamage);
        }
        else
        {
            timeElapsed = 0;
        }

        return timeElapsed -= Time.deltaTime;
    }
}


