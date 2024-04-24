using UnityEngine;

public class Money : Item
{
    public int MoneyPoints { get; private set; }

    private void Start()
    {
        MoneyPoints = 1;
    }
}
