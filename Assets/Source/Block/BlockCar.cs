using UnityEngine;

public class BlockCar : Block
{
    protected override void Activate(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMoverView player) && collision.gameObject.TryGetComponent(out PlayerView playerView))
        {
            player.CrashOnCar();
            AudioManager.Instance.Play("StoneCrash");
            playerView.GameOver();
        }
    }
}
