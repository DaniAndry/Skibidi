using UnityEngine;

public class SpeedItem : Item
{
    private float _value = 5f;

    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMoverView playerMoverView))
        {
            playerMoverView.ChangeSpeed(_value);
            Destroy(gameObject);
        }
    }
}

