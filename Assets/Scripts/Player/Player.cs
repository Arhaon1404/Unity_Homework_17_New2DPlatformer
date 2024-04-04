using UnityEngine;

public class Player : Character
{
    public void GetHeath(int healPoints)
    { 
        _health += healPoints;
    }
}
