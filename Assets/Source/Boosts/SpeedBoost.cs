using System;

public class SpeedBoost : Boost
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
        if (name == Convert.ToString(ResourceType.SpeedBoost))
        {
            for(int i = 0; i <= amount; i++)
            {
                Increase();
            }
        }
    }
}
