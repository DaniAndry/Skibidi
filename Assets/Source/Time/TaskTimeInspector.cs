using System;
using TMPro;
using UnityEngine;

public class TaskTimeInspector : MonoBehaviour
{
    [SerializeField] private TMP_Text _weeklyTimerText;
    [SerializeField] private TMP_Text _dailyTimerText;

    private DateTime _startWeeklyTime;
    private DateTime _startDailyTime;
    private int _dailyTime = 1;
    private int _weeklyTime = 7;

    public event Action OnGoneDailyTime;
    public event Action OnGoneWeeklyTime;

    public void SetTime()
    {
        _startWeeklyTime = DateTime.Now;
        _startDailyTime = DateTime.Now;

        Debug.Log($"{_startDailyTime} è {_startWeeklyTime}");
    }

    public void RefreshTime()
    {
        if (_startDailyTime.Day == DateTime.Now.Day)
        {
            _dailyTimerText.text = _dailyTime.ToString();
        }
        else
        {
            OnGoneDailyTime?.Invoke();
            _startDailyTime = DateTime.Now;
        }

        if(DateTime.Now.Day < _startWeeklyTime.Day + _weeklyTime)
        {
            int subtractDays = DateTime.Now.Day - _startWeeklyTime.Day;
            int daysLeft = _weeklyTime - subtractDays;
            _weeklyTimerText.text = daysLeft.ToString();
            Debug.Log("ChangeTime");
        }
        else
        {
            _startWeeklyTime = DateTime.Now;
            OnGoneWeeklyTime?.Invoke();
            Debug.Log("OnGoneWeeklyTime");
        }
    }
}