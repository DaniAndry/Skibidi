using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskView : MonoBehaviour
{
    [SerializeField] private Task _task;
    [SerializeField] private Button _startExecution;
    [SerializeField] private Button _takeReward;
    [SerializeField] private Image _rewardIcon;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _amountRewardText;

    private Slider _amountCompleted;
    private int _collectedCounter = 0;
    private enum RewardName
    {
        Money,
        Diamond,
        SpeedBoost,
        EnergyBoost,
        MoneyBoost,
        Case,
        Skin,
        Dance
    }

    private void Awake()
    {
        _amountCompleted = GetComponentInChildren<Slider>();
        _amountCompleted.minValue = 0;
        _amountCompleted.maxValue = _task.AmountMaxCollect;
        _startExecution.gameObject.SetActive(true);

        UpdateUI();
    }

    private void OnEnable()
    {
        _takeReward.onClick.AddListener(TakeReward);
    }

    private void OnDisable()
    {
        _takeReward.onClick.RemoveListener(TakeReward);
    }

    private void UpdateUI()
    {
        _amountRewardText.text = _task.AmountReward.ToString();
        _rewardIcon.sprite = _task.RewardIcon;
        _descriptionText.text = $"{_task.Description.ToString()}: {_task.AmountMaxCollect}";
        _amountCompleted.value = _collectedCounter;
        _amountCompleted.value = _collectedCounter;
    }

    private void ExecuteTask()
    {
        if (_collectedCounter < _task.AmountMaxCollect)
        {
            _collectedCounter++;
            UpdateUI();
        }
        
        if(_collectedCounter >= _task.AmountMaxCollect)
        {
            CompleteTask();
        }
    }

    private void CompleteTask()
    {
        _startExecution.gameObject.SetActive(false);
        _takeReward.gameObject.SetActive(true);
    }

    private void TakeReward()
    {
        string[] rewardNames = Enum.GetNames(typeof(RewardName));
        List<string> names = new List<string>(rewardNames);
    }
}
