using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int Resourses;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
          GetResourses(player);
            Destroy(gameObject);
        }
    }

    protected virtual void GetResourses(Player player){}
}
