using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class SliderInfoChanger : MonoBehaviour
{
    protected Health Health;
    protected Slider Slider;

    private void Awake()
    {
        Health = transform.root.GetComponent<Health>();
    }

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
        Slider = GetComponent<Slider>();
        Slider.maxValue = Health.MaxHealthPoints;
        SliderUpdate();
    }

    protected virtual void SliderUpdate()
    {
        Slider.value = Health.HealthPoints;
    }
}
