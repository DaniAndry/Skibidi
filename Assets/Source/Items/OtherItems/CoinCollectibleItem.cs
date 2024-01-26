using UnityEngine;

public class CoinCollectibleItem : OtherItem
{
    private int _boostCount = 10;
    private int _deBoostCount = -5;

    public override void Boost()
    {
        PlayerView.AddMoney(_boostCount);
    }

    public override void DeBoost()
    {
        PlayerView.AddMoney(_deBoostCount);
    }
}
