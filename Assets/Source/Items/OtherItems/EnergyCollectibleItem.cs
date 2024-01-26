using UnityEngine;

public class EnergyCollectibleItem : OtherItem
{
    private int _boostCount = 50;
    private int _deBoostCount = -35;

    public override void Boost()
    {
        PlayerView.OnEnergyChanged(_boostCount);
    }

    public override void DeBoost()
    {
        PlayerView.OnEnergyChanged(_deBoostCount);
    }
}
