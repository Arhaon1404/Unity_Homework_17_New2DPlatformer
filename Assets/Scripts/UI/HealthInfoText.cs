using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class HealthInfoText : AbstractHealthInfo
{
    [SerializeField] private Health _health;

    private TMP_Text _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
        InfoUpdate();
    }

    protected override void InfoUpdate()
    {
        _textMesh.text = Convert.ToString(_health.HealthPoints / _health.MaxHealthPoints);
    }
}
