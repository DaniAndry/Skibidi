using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyRewardButton : MonoBehaviour
{
    [SerializeField] private Bank _bank;
    [SerializeField] private TMP_Text _amountRewardText;
    [SerializeField] private Button _rewardButton;

    private int _amountReward;
    private int _moneyTight = 150;
    private int _moneyNormal = 500;
    private int _muchMoney = 1000;

    public event Action<Action> OnRewardButtonClick;

    private void Awake()
    {
        _rewardButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _rewardButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _rewardButton.onClick.RemoveListener(OnButtonClick);
    }

    public void RefreshAmountButton()
    {
        int chance = UnityEngine.Random.Range(0, 100);

        if (_bank.Money <= _moneyTight && chance <= 30)
        {
            RefreshAmountPrice(_moneyTight);
            _rewardButton.gameObject.SetActive(true);
        }
        else if(_bank.Money <= _moneyNormal && chance <= 20)
        {
            RefreshAmountPrice(_moneyNormal);
            _rewardButton.gameObject.SetActive(true);
        }
        else if(_bank.Money <= _muchMoney && chance <= 20)
        {
            RefreshAmountPrice(_muchMoney);
            _rewardButton.gameObject.SetActive(true);
        }
        else if(_bank.Money >= _muchMoney && chance <= 20)
        {
            RefreshAmountPrice(_muchMoney * 2);
            _rewardButton.gameObject.SetActive(true);
        }
        else
        {
            _rewardButton.gameObject.SetActive(false);
        }      
    }

    private void RefreshAmountPrice(int amount)
    {
        _amountReward = amount;
        _amountRewardText.text = _amountReward.ToString();
    }

    private void OnRewardCallback()
    {
        _bank.GiveMoney(_amountReward);
    }

    private void OnButtonClick()
    {
        OnRewardButtonClick?.Invoke(OnRewardCallback);
    }
}
