using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class VampiricAbilityAttacker : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _vampiricDamage;

    public event Action Changed;

    private List<Health> _enemyList = new List<Health>();

    private Health _mainCharacterHealth;

    private Coroutine _abilityCoroutine;
    private WaitForSeconds _coroutineDelay;

    private SpriteRenderer _spriteRenderer;

    private bool _isCoroutineDone = true;
    private bool _inZone;

    private float _generalCooldown;

    private float _residualVampiricDamage;

    public float GeneralCooldown => _generalCooldown;

    private void Start()
    {
        _mainCharacterHealth = GetComponentInParent<Health>();
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

    private IEnumerator ActAbility()
    {
        float timeElapsed = _duration;
        _generalCooldown = 0;

        while (timeElapsed >= 0)
        {
            yield return _coroutineDelay;

            if (_inZone == true)
            {
                _residualVampiricDamage = (_vampiricDamage - _enemyList[0].HealthPoints) > 0 ? (_vampiricDamage - _enemyList[0].HealthPoints) : 0;
                _enemyList[0].Decrease(_vampiricDamage);
                _mainCharacterHealth.Increase(_vampiricDamage - _residualVampiricDamage);
            }
            else
            {
                timeElapsed = 0;
            }

            timeElapsed -= Time.deltaTime;
        }

        _generalCooldown = _cooldown;

        while (_generalCooldown > 0)
        {
            _generalCooldown -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            Changed.Invoke();
        }

        _isCoroutineDone = true;
    }
}
