using System;

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
}
