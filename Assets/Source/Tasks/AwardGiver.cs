using System;
using UnityEngine;

public static class AwardGiver
{
    public static event Action<string, int> OnReward;

    public static void Reward(string name, int amount)
    {
        OnReward?.Invoke(name, amount);
    }
}
