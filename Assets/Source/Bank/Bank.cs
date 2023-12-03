using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _moneyText;

    private int _money = 50;

    private void Start()
    {
        UpdateMoneyText();
    }

    private void TakeMoney(int money)
    {
        _money -= money;
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
        {
            TakeMoney(money);
            return true;
        }
        else 
        {
            return false; 
        }
    }

    public void GiveMoney(int money)
    {
        _money += money;
        UpdateMoneyText();
    }
}
