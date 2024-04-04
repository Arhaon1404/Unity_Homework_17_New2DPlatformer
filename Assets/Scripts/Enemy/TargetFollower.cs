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
        TryGetPlayer(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryGetPlayer(collision);
    }

    private void TryGetPlayer(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().TryGetComponent(out Player player))
        {
            if (_pathTargetChanger.IsTargetPriority == false)
            {
                _pathTargetChanger.SetPriorityTarget(true);
            }

            _followerObject.SetTarget(player.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _pathTargetChanger.SetPriorityTarget(false);

        _followerObject.SetTarget(_pathTargetChanger.LastTarget);
    }
}
