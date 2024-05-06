using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardSystem : MonoBehaviour
{
    [SerializeField] private Bank _bank;

    private DateTime _lastRewardTime;
    private int _lastRewardIndex = 0;
    private bool _isRewardTakenToday = false;
    private DailyRewardSpawner _spawner;

    private List<DailyReward> _rewards;

    private void Start()
    {
        _spawner = GetComponent<DailyRewardSpawner>();
        LoadRewardData();
        InitializeRewards();
        _spawner.Spawn(_rewards, this);
    }

    public void GiveReward(int index, int amout)
    {
        _lastRewardIndex = index;
        _isRewardTakenToday = true;
        _bank.GiveMoney(amout);
        SaveRewardData();
    }

    private void InitializeRewards()
    {
        _rewards = new List<DailyReward>();

        LoadRewardData();

        TimeSpan timeDifference = DateTime.UtcNow - _lastRewardTime;
        bool isSameDay = timeDifference.TotalDays < 1;
        bool isOverTwoDays = timeDifference.TotalDays > 2;

        int unlockIndex = isSameDay ? -1 : (isOverTwoDays ? 0 : _lastRewardIndex + 1);

        for (int i = 0; i < 30; i++)
        {
            int rewardAmount = CalculateRewardAmount(i);
            bool isUnbox = i < _lastRewardIndex;
            bool isUnlock = i-1 == unlockIndex;

            _rewards.Add(new DailyReward(rewardAmount, isUnlock, isUnbox, i));
        }
    }

    private int CalculateRewardAmount(int dayIndex)
    {
        return 100 + (dayIndex / 5) * 20;
    }

    private void LoadRewardData()
    {
        _lastRewardTime = DateTime.Parse(PlayerPrefs.GetString("LastRewardTime", DateTime.UtcNow.ToString()));
        _lastRewardIndex = PlayerPrefs.GetInt("LastRewardIndex", 0);
    }

    private void SaveRewardData()
    {
        PlayerPrefs.SetString("LastRewardTime", DateTime.UtcNow.ToString());
        PlayerPrefs.SetInt("LastRewardIndex", _lastRewardIndex);
        PlayerPrefs.Save();
    }
}
