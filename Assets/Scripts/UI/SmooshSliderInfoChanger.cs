using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmooshSliderInfoChanger : SliderInfoChanger
{
    [SerializeField] private float _rateOfChange;

    private int _target;

    private Coroutine _changeValueCoroutine;
    private bool _isDone;

    private IEnumerator ChangeSliderValue()
    {
        while (_slider.value != _target)
        {
            yield return null;

            _slider.value = Mathf.MoveTowards(_slider.value, _target, _rateOfChange * Time.deltaTime);
        }

        _isDone = true;
    }

    private void RunCoroutine()
    {
        if (_isDone)
        {
            if (_changeValueCoroutine != null)
            {
                StopCoroutine(_changeValueCoroutine);
            }

            _isDone = false;
            _changeValueCoroutine = StartCoroutine(ChangeSliderValue());
        }
    }

    protected override void Start()
    {
        base.Start();
        base.SliderUpdate();

        _isDone = true;
    }

    protected override void SliderUpdate()
    {
        _target = Health.HealthPoints;

        RunCoroutine();
    }
}
