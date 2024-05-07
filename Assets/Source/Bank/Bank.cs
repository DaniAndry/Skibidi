using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _moneyText;
    [SerializeField] private List<TMP_Text> _diamondText;

    private int _money = 50;
    private int _diamond = 10;

    public event Action OnBuy;
    
    private void OnEnable()
    {
        AwardGiver.OnReward += GiveRewardMoney;
    }

    private void Start()
    {
        UpdateText();
    }

    private void OnDisable()
    {
        AwardGiver.OnReward -= GiveRewardMoney;
    }

    public void TakeMoney(int money)
    {
        if (TryTakeValue(money))
        {
            _money -= money;
            TaskCounter.IncereaseProgress(money, Convert.ToString(TaskType.SpendMoney));
            AudioManager.Instance.Play("Buy");
            OnBuy?.Invoke();
            UpdateText();
        }
    }

    public bool TryTakeValue(int value)
    {
        if(_money >= value)
            return true;
        else 
            return false; 
    }

    public void GiveMoney(int money)
    {
        _money += money;
        UpdateText();
    }

    public void TakeDiamond(int diamond)
    {
        if (TryTakeValue(diamond))
        {
            _diamond -= diamond;
            UpdateText();
        }
    }

    private void GiveRewardMoney(string name, int amount)
    {
        if (name == Convert.ToString(ResourceType.Money))
        {
            GiveMoney(amount);
        }
    }

    private void UpdateText()
    {
        foreach (TMP_Text money in _moneyText)
        {
            money.text = _money.ToString();
        }

        foreach (TMP_Text diamond in _diamondText)
        {
            diamond.text = _diamond.ToString();
        }
    }
}
