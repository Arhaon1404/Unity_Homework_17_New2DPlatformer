using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _points;

    public void Increase(int numberIncreasePoints)
    {
        _points += numberIncreasePoints;
    }

    public void Decrease(int numberDecreasePoints)
    {
        _points -= numberDecreasePoints;
    }
}
