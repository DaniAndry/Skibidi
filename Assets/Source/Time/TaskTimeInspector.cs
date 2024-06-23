using System;
using TMPro;
using UnityEngine;
using YG;

public class TaskTimeInspector : MonoBehaviour
{
    [SerializeField] private TMP_Text _weeklyTimerText;
    [SerializeField] private TMP_Text _dailyTimerText;

    private int _startWeeklyTime;
    private int _startDailyTime;
    private int _dailyTime = 1;
    private int _weeklyTime = 7;

    public event Action OnGoneDailyTime;
    public event Action OnGoneWeeklyTime;

    public void Load()
    {
        _startDailyTime = YandexGame.savesData.StartDailyTime;
        _startWeeklyTime = YandexGame.savesData.StartWeeklyTime;
        Debug.Log(_startDailyTime);
        Debug.Log(_startWeeklyTime);
    }

    public void RefreshTime()
    {
        if (_startDailyTime == DateTime.Now.Day)
        {
            _dailyTimerText.text = _dailyTime.ToString();
        }
        else
        {
            _startDailyTime = DateTime.Now.Day;
            OnGoneDailyTime?.Invoke();
            Save();
        }

        if (DateTime.Now.Day < _startWeeklyTime + _weeklyTime)
        {
            int subtractDays = DateTime.Now.Day - _startWeeklyTime;
            int daysLeft = _weeklyTime - subtractDays;

            if (daysLeft > _weeklyTime)
            {
                daysLeft = 7;
                _startWeeklyTime = DateTime.Now.Day;
                Save();
            }

            _weeklyTimerText.text = daysLeft.ToString();
        }
        else
        {
            _startWeeklyTime = DateTime.Now.Day;
            OnGoneWeeklyTime?.Invoke();
            Save();
        }
    }

    private void Save()
    {
        YandexGame.savesData.StartDailyTime = _startDailyTime;
        YandexGame.savesData.StartWeeklyTime = _startWeeklyTime;
        YandexGame.SaveProgress();

        Debug.Log(YandexGame.savesData.StartDailyTime);
    }
}