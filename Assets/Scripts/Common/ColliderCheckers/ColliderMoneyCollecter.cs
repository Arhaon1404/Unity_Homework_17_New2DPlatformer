using UnityEngine;

public class ColliderMoneyCollecter : ColliderItemChecker
{
    private Score _score;

    private void Start()
    {
        _score = GetComponentInParent<Score>();
    }

    protected override void ActComponent(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            int points = money.MoneyPoints;
            DestroyObject(collision.gameObject);
            _score.Increase(points);
        }
    }
}
