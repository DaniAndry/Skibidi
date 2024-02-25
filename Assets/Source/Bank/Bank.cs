using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _moneyText;

    private int _money = 50;

    public event Action OnBuy;

    private void Start()
    {
        UpdateMoneyText();
    }

    private void OnEnable()
    {
        AwardGiver.OnReward += GiveRewardMoney;
    }

    private void OnDisable()
    {
        AwardGiver.OnReward -= GiveRewardMoney;
    }

    private void GiveRewardMoney(string name, int amount)
    {
        if(name == Convert.ToString(ResourceType.Money))
        {
            GiveMoney(amount);
        }
    }

    public void TakeMoney(int money)
    {
        _money -= money;
        TaskCounter.IncereaseProgress(money, Convert.ToString(TaskType.SpendMoney));
        AudioManager.Instance.Play("Buy");
        OnBuy?.Invoke();
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        foreach(TMP_Text money in _moneyText)
        {
            money.text = _money.ToString();
        }
    }

    public bool TryTakeMoney(int money)
    {
        if(_money >= money)
            return true;
        else 
            return false; 
    }

    public void GiveMoney(int money)
    {
        _money += money;
        UpdateMoneyText();
    }
}
