using UnityEngine;

public class Money : Item
{
    [SerializeField] private int _moneyPoints;
    public int GetMoneyPoints()
    {
        return _moneyPoints;
    }
}
