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

    private void Start()
    {
        UpdateText();
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
        UpdateText();
    }

    public void UpdateText()
    {
        foreach(TMP_Text money in _moneyText)
        {
            money.text = _money.ToString();
        }
        
        foreach(TMP_Text diamond in _diamondText)
        {
            diamond.text = _diamond.ToString();
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
        if (TryTakeMoney(money))
        {
            _money += money;
            UpdateText();
        }
    }

    public bool TryTakeDiamond(int diamond)
    {
        if (_diamond >= diamond)
            return true;
        else
            return false;
    }

    public void GiveDiamond(int diamond)
    {
        if (TryTakeDiamond(diamond))
        {
            _diamond -= diamond;
            UpdateText();
        }
    }
}
