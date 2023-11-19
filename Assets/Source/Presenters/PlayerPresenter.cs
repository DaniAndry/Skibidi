using System;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    private PlayerModel _model;
    private PlayerView _view;
    private Menu _viewMenu;
    private EndScreenView _viewEndScreen;
    private PlayerMoverView _viewMover;
    private EnergyUpgrade _energyUpgrade;
    private Shop _shop;

    public void Init(PlayerModel model, PlayerView view, Menu viewMenu, EndScreenView viewEndScreen, PlayerMoverView viewMover, EnergyUpgrade energyUpgrade, Shop shop)
    {
        _model = model;
        _view = view;
        _viewMenu = viewMenu;
        _viewEndScreen = viewEndScreen;
        _viewMover = viewMover;
        _energyUpgrade = energyUpgrade;
        _shop = shop;
    }

    public void Enable()
    {
        _model?.Init();
        UpdateMoney();
        _viewMenu.SetDistance(_model.TotalDistanceTraveled);

        _model.OnErrorUpgraded += ErrorUpgrade;
        _model.OnEnergyUpgraded += EnergyUpgraded;
        _model.OnEnergyGone += EndGame;
        _model.DistanceChanging += OnDistanceChanged;
        _model.StartedGame += OnStartedgame;
        _model.EnergyChanged += OnEnergyChanged;
        _view.EnergyChanging += OnViewEnergyChanged;
        _view.OnChangingMoney += OnMoneyChanged;
        _viewMenu.ClickingStart += OnClickStart;
        _energyUpgrade.ClickingUpgrade += OnClickUpgradeEnergy;
    }

    public void Disable()
    {
        _model.OnErrorUpgraded -= ErrorUpgrade;
        _model.OnEnergyUpgraded -= EnergyUpgraded;
        _model.OnEnergyGone -= EndGame;
        _model.DistanceChanging -= OnDistanceChanged;
        _model.StartedGame -= OnStartedgame;
        _model.EnergyChanged -= OnEnergyChanged;
        _view.EnergyChanging -= OnViewEnergyChanged;
        _view.OnChangingMoney -= OnMoneyChanged;
        _viewMenu.ClickingStart -= OnClickStart;
        _energyUpgrade.ClickingUpgrade -= OnClickUpgradeEnergy;
    }

    private void Update()
    {
        _model?.Update(_view.transform);
    }

    private void OnClickUpgradeEnergy()
    {
        _model.UpMaxEnergy(_energyUpgrade.Price, _energyUpgrade.AmountEnergy);
    }

    private void ErrorUpgrade()
    {
        _energyUpgrade.ErrorUpgrade();
    }

    private void EnergyUpgraded()
    {
        _energyUpgrade.Upgrade();
        UpdateMoney();
        OnEnergyChanged();
    }

    private void UpdateMoney()
    {
        _view.SetMoney(_model.Money);
        _viewMenu.SetMoney(_model.Money);
    }

    private void OnDistanceChanged()
    {
        _view.SetDistance(_model.TotalDistanceTraveled);
    }

    private void OnClickStart()
    {
        _model.Init();
        _model.StartGame();
    }

    private void EndGame()
    {
        _model.SavePlayer();
        _viewMover.EndGame();
        _viewEndScreen.OpenEndScreen();
        _viewEndScreen.SetData(_model.Money, _model.TotalDistanceTraveled);
    }

    private void OnStartedgame()
    {
        _view.StartGame();
    }

    private void OnEnergyChanged()
    {
        _view.SetEnergy(_model.CurrentEnergy);
    }

    private void OnMoneyChanged(int money)
    {
        Debug.Log("Model Try Buy");
        if (_model.TryBuySkin(money))
        {
        Debug.Log("true");
            UpdateMoney();
            _shop.BuySkin();
        }
    }

    private void OnViewEnergyChanged(float energyAmount)
    {
        _model.TakeEnergy(energyAmount);
    }
}
