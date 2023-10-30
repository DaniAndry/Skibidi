using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected float Resourses;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerView playerView))
        {
            GetResourses(playerView);
            Destroy(gameObject);
        }
    }

    protected virtual void GetResourses(PlayerView playerView) { }
}
