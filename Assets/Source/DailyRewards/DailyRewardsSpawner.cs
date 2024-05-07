using System.Collections.Generic;
using UnityEngine;

public class DailyRewardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _dailyRewardPrefab;
    [SerializeField] private Transform _spawnTarget;

    public void Spawn(List<DailyReward> rewards, DailyRewardSystem dailyRewardSystem)
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            GameObject dailyRewardObject = Instantiate(_dailyRewardPrefab, _spawnTarget);
            DailyRewardView rewardView = dailyRewardObject.GetComponent<DailyRewardView>();
            rewardView.Init(rewards[i].Amount, rewards[i].IsUnlock, rewards[i].IsUnbox, rewards[i].Index, dailyRewardSystem);
        }
    }
}
