using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int GetDamage()
    { 
        return _damage;
    }
}
