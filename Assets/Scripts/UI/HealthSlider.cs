using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class HealthSlider : AbstractHealthInfo
{
    protected Slider Slider;

    protected void Awake()
    {
        Health = transform.root.GetComponent<Health>();
    }

    protected virtual void Start()
    {
        Slider = GetComponent<Slider>();
        InfoUpdate();
    }

    protected override void InfoUpdate()
    {
        Slider.value = Health.HealthPoints / Health.MaxHealthPoints;
    }
}
