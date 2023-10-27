using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    private float _count = 5f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMoverView playerMoverView))
        {
            playerMoverView.TakeSpeed(_count);
            Destroy(gameObject);
        }
    }
}

