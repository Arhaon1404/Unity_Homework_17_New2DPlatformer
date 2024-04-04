using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().TryGetComponent(out Character attackCharacter))
        {
            attackCharacter.SetDamage(_character);
        }
    }
}
