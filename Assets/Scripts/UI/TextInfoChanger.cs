using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class TextInfoChanger : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TMP_Text _textMesh;

    private void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
        TextUpdate();
    }

    private void OnEnable()
    {
        _health.Changed += TextUpdate;
    }

    private void OnDisable()
    {
        _health.Changed -= TextUpdate;
    }

    private void TextUpdate()
    {
        _textMesh.text = Convert.ToString(_health.HealthPoints);
    }
}
