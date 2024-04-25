using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class SliderInfoChanger : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected Slider _slider;

    private void OnEnable()
    {
        Health.Changed += SliderUpdate;
    }

    private void OnDisable()
    {
        Health.Changed -= SliderUpdate;
    }

    protected virtual void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = Health.MaxHealthPoints;
        SliderUpdate();
    }

    protected virtual void SliderUpdate()
    {
        _slider.value = Health.HealthPoints;
    }
}
