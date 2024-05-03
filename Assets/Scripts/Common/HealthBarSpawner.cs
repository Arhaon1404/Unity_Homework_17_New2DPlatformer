using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSpawner : MonoBehaviour
{
    [SerializeField] private Character _parent;
    [SerializeField] private GameObject _healthBar;

    private void Start()
    {
        _healthBar = Instantiate(_healthBar, _parent.transform);
    }
}
