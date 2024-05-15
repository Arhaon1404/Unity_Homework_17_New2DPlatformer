using System;
using UnityEngine;
using TMPro;

public class AbilityCoolDownViewer : MonoBehaviour
{
    [SerializeField] private VampiricAbilityAttacker _abilityComponent;

    private TMP_Text _textMesh;

    protected void OnEnable()
    {
        _abilityComponent.CooldownUpdate += UpdateCooldown;
    }

    protected void OnDisable()
    {
        _abilityComponent.CooldownUpdate -= UpdateCooldown;
    }

    private void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
    }

    private void UpdateCooldown()
    {
        float cooldown = (float)Math.Round(_abilityComponent.GeneralCooldown, 1);

        if (cooldown > 0)
        {
            _textMesh.enabled = true;
        }
        else
        {
            _textMesh.enabled = false;
        }

        _textMesh.text = Convert.ToString(cooldown);
    }
}
