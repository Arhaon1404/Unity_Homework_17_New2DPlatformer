using UnityEngine;

public class Heal : Item
{
    [field: SerializeField] public int HeathPointsRestore { get; private set; }
}
