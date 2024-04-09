using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _points;

    public void IncreaseScore(int numberIncreasePoints)
    {
        _points += numberIncreasePoints;
    }

    public void DecreaseScore(int numberDecreasePoints)
    {
        _points -= numberDecreasePoints;
    }
}
