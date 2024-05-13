using UnityEngine;

public class ColliderHealer : ColliderItemChecker
{
    private Health _health;

    private void Start()
    {
        _health = GetComponentInParent<Health>();
    }
    protected override void ActComponent(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Heal heal))
        {
            int healthPointsRestore = heal.HeathPointsRestore;
            DestroyObject(collision.gameObject);
            _health.Increase(healthPointsRestore);
        }
    }
}
