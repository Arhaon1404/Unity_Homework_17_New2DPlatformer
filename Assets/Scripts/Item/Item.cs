using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private int _heathPointsRestore;

    public void SetEffect(Player player)
    {
        player.GetHeath(_heathPointsRestore);
    }
}
