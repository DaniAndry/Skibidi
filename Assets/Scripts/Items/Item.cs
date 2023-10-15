using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int Resourses;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
          GetResourses(player);
        }
    }

    protected virtual void GetResourses(Player player) 
    {
        player.TakeResourses(Resourses);
    }
}
