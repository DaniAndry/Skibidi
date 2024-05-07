using System.Collections.Generic;
using UnityEngine;
using System;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private PlayerResurrect _playerResurrect;
    [SerializeField] private List<BoostBuyButton> _boostButtons = new List<BoostBuyButton>();
    [SerializeField] private EndGameScreen _endScreen;
    [SerializeField] private MoneyRewardButton _moneyReward;

    private VideoAdView _view;

    private void Awake()
    {
        _view = GetComponent<VideoAdView>();
    }

    private void OnEnable()
    {
        foreach(var button in _boostButtons)
        {
            button.OnBuyBoostAd += OnRewardCallback;
            button.OnUpgradeBoostAd += OnRewardCallback;
        }

        _moneyReward.OnRewardButtonClick += OnRewardCallback;
        _endScreen.OnRewardButtonClick += OnRewardCallback;
        _playerResurrect.OnCallAd += OnRewardCallback;
        _playerResurrect.OnResurrecting += OnRewardCallback;
        _playerResurrect.OnRestart += RefreshAdButtons;
    }

    private void OnDisable()
    {
        foreach (var button in _boostButtons)
        {
            button.OnBuyBoostAd -= OnRewardCallback;
            button.OnUpgradeBoostAd -= OnRewardCallback;
        }

        _moneyReward.OnRewardButtonClick -= OnRewardCallback;
        _endScreen.OnRewardButtonClick -= OnRewardCallback;
        _playerResurrect.OnCallAd -= OnRewardCallback;
        _playerResurrect.OnResurrecting -= OnRewardCallback;
        _playerResurrect.OnRestart -= RefreshAdButtons;
    }

    private void OnRewardCallback(Action reward)
    {
        _view.Show(reward);
    }

    private void RefreshAdButtons()
    {
        foreach( var button in _boostButtons)
        {
            button.SelectAdButtons();
        }

        _moneyReward.RefreshAmountButton();
    }
}
