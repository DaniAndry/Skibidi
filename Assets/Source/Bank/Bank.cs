using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _moneyText;
    [SerializeField] private List<TMP_Text> _diamondText;
    [SerializeField] private List<TMP_Text> _moneyForGameText;
    [SerializeField] private List<TMP_Text> _diamondForGameText;

    private int _diamond = 10;
    private int _moneyForGame;
    private int _diamondForGame;

    public event Action OnBuy;

    public int Money { get; private set; }  = 50;

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
        if (TryTakeMoney(money))
        {
            Money -= money;
            TaskCounter.IncereaseProgress(money, Convert.ToString(TaskType.SpendMoney));
            AudioManager.Instance.Play("Buy");
            OnBuy?.Invoke();
            UpdateText();
        }
    }

    public void UpdateText()
    {
        foreach(TMP_Text money in _moneyText)
        {
            money.text = Money.ToString();
        }
        
        foreach(TMP_Text diamond in _diamondText)
        {
            diamond.text = _diamond.ToString();
        }

        foreach (TMP_Text diamond in _diamondForGameText)
        {
            diamond.text = _diamondForGame.ToString();
        }
        
        foreach (TMP_Text money in _moneyForGameText)
        {
            money.text = _moneyForGame.ToString();
        }
    }

    public bool TryTakeMoney(int value)
    {
        if(Money >= value)
            return true;
        else 
            return false; 
    } 

    public bool TryTakeDiamond(int value)
    {
        if(_diamond >= value)
            return true;
        else 
            return false; 
    }

    public void GiveMoney(int money)
    {
        Money += money;
        UpdateText();
    }

    public void GiveMoneyForGame(int money)
    {
        _moneyForGame += money;
        Money += money;
        UpdateText();

        TaskCounter.IncereaseProgress(Convert.ToInt32(money), TaskType.CollectMoney.ToString());
    }

    public void MoneyMultiplyAd()
    {
        GiveMoney(_moneyForGame);
        _moneyForGame *= 2;
    }

    public void TakeDiamond(int diamond)
    {
        if (TryTakeDiamond(diamond))
        {
            _diamond -= diamond;
            UpdateText();
        }
    }

    public void Reset()
    {
        _moneyForGame = 0;
        _diamondForGame = 0;
        UpdateText();
    }

    private void GiveRewardMoney(string name, int amount)
    {
        if (name == Convert.ToString(ResourceType.Money))
        {
            GiveMoney(amount);
        }
    }
}
