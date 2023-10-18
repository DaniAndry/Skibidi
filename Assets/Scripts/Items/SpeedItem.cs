using UnityEngine;

public class SpeedItem : Item
{
    protected float Speed = 5;

    protected override void GetResourses(Player player)
    {
        player.TakeSpeed(Speed);
    }
}
