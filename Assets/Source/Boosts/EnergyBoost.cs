using System;
using YG;

public class EnergyBoost : Boost
{
    private void OnEnable()
    {
        AwardGiver.OnReward += GiveRewardBoost;
    }

    private void OnDisable()
    {
        AwardGiver.OnReward -= GiveRewardBoost;
    }

    public override void Save()
    {
        YandexGame.savesData.CountEnergyBoost = Count;
        YandexGame.savesData.CountUpgradeEnergyBoost = CountUpgrade;
        YandexGame.SaveProgress();
    }

    public override void Load()
    {
        Count = YandexGame.savesData.CountEnergyBoost;
        CountUpgrade = YandexGame.savesData.CountUpgradeEnergyBoost;
        LoadTimer();
        UpdateText();
    }

    private void GiveRewardBoost(string name, int amount)
    {
        if (name == Convert.ToString(ResourceType.EnergyBoost))
        {
            for (int i = 0; i <= amount; i++)
            {
                Increase();
            }
        }
    }
}
