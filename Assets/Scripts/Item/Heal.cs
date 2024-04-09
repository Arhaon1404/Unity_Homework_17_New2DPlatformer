using UnityEngine;

public class Heal : Item
{
    [SerializeField] private int _heathPointsRestore;
    public int GetHealthPoints()
    {
        return _heathPointsRestore;
    }
}
