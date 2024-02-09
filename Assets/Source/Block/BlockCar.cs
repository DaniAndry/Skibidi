using UnityEngine;

public class BlockCar : Block
{
    protected override void Activate(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMoverView player))
        {
            player.CrashOnCar();
            AudioManager.Instance.Play("StoneCrash");
        }
    }
}
