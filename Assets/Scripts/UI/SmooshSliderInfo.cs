using System.Collections;
using UnityEngine;

public class SmooshSliderInfo : SliderInfo
{
    [SerializeField] private float _rateOfChange;

    private int _target;

    private Coroutine _changeValueCoroutine;
    private bool _isDone;

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

    private IEnumerator ChangeSliderValue()
    {
        while (Slider.value != _target)
        {
            yield return null;

            Slider.value = Mathf.MoveTowards(Slider.value, _target, _rateOfChange * Time.deltaTime);
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
}
