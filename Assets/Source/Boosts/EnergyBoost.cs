using System;

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
