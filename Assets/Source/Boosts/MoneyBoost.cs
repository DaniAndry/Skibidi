using System;
using YG;

public class MoneyBoost : Boost
{
    private void OnEnable()
    {
        AwardGiver.OnReward += GiveRewardBoost;
    }

    private void OnDisable()
    {
        AwardGiver.OnReward -= GiveRewardBoost;
    }

    private void GiveRewardBoost(string name, int amount)
    {
        if (name == Convert.ToString(ResourceType.MoneyBoost))
        {
            for (int i = 0; i < amount; i++)
            {
                Increase();
            }
        }
    }
    public override void Save()
    {
        YandexGame.savesData.CountMoneyBoost = Count;
        YandexGame.savesData.CountUpgradeMoneyBoost = CountUpgrade;
        YandexGame.SaveProgress();
    }

    public override void Load()
    {
        Count = YandexGame.savesData.CountMoneyBoost;
        CountUpgrade = YandexGame.savesData.CountUpgradeMoneyBoost;
        LoadTimer();
        UpdateText();
    }
}
