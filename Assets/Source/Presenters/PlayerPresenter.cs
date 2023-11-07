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

    public void Init(PlayerModel model, PlayerView view, Menu viewMenu, EndScreenView viewEndScreen, PlayerMoverView viewMover, EnergyUpgrade energyUpgrade)
    {
        _model = model;
        _view = view;
        _viewMenu = viewMenu;
        _viewEndScreen = viewEndScreen;
        _viewMover = viewMover;
        _energyUpgrade = energyUpgrade;
    }

    private void Start()
    {
        _model?.Init();
        UpdateMoney();
    }

    public void Enable()
    {
        _model.OnErrorUpgraded += ErrorUpgrade;
        _model.OnEnergyUpgraded += EnergyUpgraded;
        _model.OnEnergyGone += EndGame;
        _model.DistanceChanging += OnDistanceChanged;
        _model.StartedGame += OnStartedgame;
        _model.EnergyChanged += OnEnergyChanged;
        _view.EnergyChanging += OnViewEnergyChanged;
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
        _model.StartGame();
        _model.Init();
    }

    private void EndGame()
    {
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

    private void OnViewEnergyChanged(float energyAmount)
    {
        _model.TakeEnergy(energyAmount);
    }
}
