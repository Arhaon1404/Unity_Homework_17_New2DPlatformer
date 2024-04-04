using UnityEngine;

[RequireComponent(typeof(Item))]

public class ItemEffectActivator : MonoBehaviour
{
    private Transform _topParent;
    private Transform _point;

    private Item _item;

    private void Start()
    {
        _item = GetComponent<Item>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _item.SetEffect(player);

            Destroy(this.gameObject);

            _topParent = transform.root;
            _point = transform.parent;

            _topParent.BroadcastMessage("RunCoroutine", _point);
        }
    }
}
