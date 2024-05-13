using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Enemy _followerObject;

    private PathTargetChanger _pathTargetChanger;

    private void Start()
    {
        _pathTargetChanger = _followerObject.GetComponent<PathTargetChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryGetCollision(collision,false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryGetCollision(collision,false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TryGetCollision(collision,true);
    }

    private void TryGetCollision(Collider2D collision, bool isExit)
    {
        if (collision.GetComponent<Collider2D>().TryGetComponent(out EnemyAggresionZone enemyAggresionZone))
        {
            if (isExit)
            {
                ExitPlayer();
            }
            else
            {
                GetPlayer(enemyAggresionZone);
            }
        }
    }

    private void GetPlayer(EnemyAggresionZone enemyAggresionZone)
    {
        if (_pathTargetChanger.IsTargetPriority == false)
        {
            _pathTargetChanger.SetPriorityTarget(true);
        }

        _followerObject.SetTarget(enemyAggresionZone.transform.position);
    }

    private void ExitPlayer()
    {
        _pathTargetChanger.SetPriorityTarget(false);

        _followerObject.SetTarget(_pathTargetChanger.LastTarget);
    }
}
