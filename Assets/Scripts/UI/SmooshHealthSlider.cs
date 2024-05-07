using System.Collections;
using UnityEngine;

public class SmooshHealthSlider : HealthSlider
{
    [SerializeField] private float _duration;

    private float _target;

    private Coroutine _changeValueCoroutine;
    private bool _isDone;

    protected override void Start()
    {
        base.Start();
        base.InfoUpdate();

        _isDone = true;
    }

    protected override void InfoUpdate()
    {
        _target = Health.HealthPoints / Health.MaxHealthPoints;

        RunCoroutine();
    }

    private IEnumerator ChangeSliderValue()
    {
        float sliderValue = Slider.value;
        float timeElapsed = 0;

        while (timeElapsed < _duration)
        {
            Slider.value = Mathf.Lerp(sliderValue, _target, timeElapsed / _duration);
            timeElapsed += Time.deltaTime;

            yield return null;
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
