using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmooshSliderInfoChanger : SliderInfoChanger
{
    [SerializeField] private float _rateOfChange;

    private float _target;

    private Coroutine _changeValueCoroutine;
    private WaitForSeconds _secondsPeriod;
    private bool _isDone;

    private IEnumerator ChangeSliderValue()
    {
        while (_isDone == false)
        {
            yield return _secondsPeriod;

            if (_slider.value < _target)
            {
                SliderValueUpdate();

                if (_slider.value >= _target)
                {
                    _isDone = true;
                }
            }
            else if (_slider.value > _target)
            {
                SliderValueUpdate();

                if (_slider.value <= _target)
                { 
                    _isDone = true;
                }
            }
        }
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

    private void SliderValueUpdate()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _target, _rateOfChange * Time.deltaTime);
    }

    protected override void Start()
    {
        base.Start();
        base.SliderUpdate();

        _secondsPeriod = new WaitForSeconds(0.01f);
        _isDone = true;
    }

    protected override void SliderUpdate()
    {
        _target = _health.HealthPoints;

        RunCoroutine();
    }
}
