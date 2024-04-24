using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class SliderInfoChanger : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected Slider _slider;

    private void OnEnable()
    {
        _health.HealthChange += SliderUpdate;
    }

    private void OnDisable()
    {
        _health.HealthChange -= SliderUpdate;
    }

    protected virtual void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.MaxHealthPoints;
        SliderUpdate();
    }

    protected virtual void SliderUpdate()
    {
        _slider.value = _health.HealthPoints;
    }
}
