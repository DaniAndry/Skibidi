using UnityEngine;

public class EnergyItem : Item
{
    protected int Energy = 10;

    protected override void GetResourses(Player player)
    {
        player.TakeEnergy(Energy);
    }
}
