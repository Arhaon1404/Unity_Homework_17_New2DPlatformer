using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class TextInfo : SliderInfo
{
    [SerializeField] private Health _health;

    private TMP_Text _textMesh;

    protected override void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
        SliderUpdate();
    }

    protected override void SliderUpdate()
    {
        _textMesh.text = Convert.ToString(_health.HealthPoints);
    }
}
