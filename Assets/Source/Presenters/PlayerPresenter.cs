using System;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    private PlayerModel _model;
    private PlayerView _view;
    private EnergyUpgrade _energyUpgrade;

    public event Action OnEndGame;

    public void Init(PlayerModel model, PlayerView view, EnergyUpgrade energyUpgrade)
    {
        _model = model;
        _view = view;
        _energyUpgrade = energyUpgrade;
    }

    public void Enable()
    {
        _model?.Init();
        UpdateMoney();

        _model.OnErrorUpgraded += ErrorUpgrade;
        _model.OnEnergyUpgraded += EnergyUpgraded;
        _model.OnEnergyGone += EndGame;
        _model.DistanceChanging += OnDistanceChanged;
        _model.EnergyChanged += OnEnergyChanged;
        _view.EnergyChanging += OnViewEnergyChanged;
        _view.OnChangingMoney += OnMoneyChanged;
        _energyUpgrade.ClickingUpgrade += OnClickUpgradeEnergy;
    }

    public void Disable()
    {
        _model.OnErrorUpgraded -= ErrorUpgrade;
        _model.OnEnergyUpgraded -= EnergyUpgraded;
        _model.OnEnergyGone -= EndGame;
        _model.DistanceChanging -= OnDistanceChanged;
        _model.EnergyChanged -= OnEnergyChanged;
        _view.EnergyChanging -= OnViewEnergyChanged;
        _view.OnChangingMoney -= OnMoneyChanged;
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
    }

    private void OnDistanceChanged()
    {
        _view.SetDistance(_model.TotalDistanceTraveled);
    }

    public void StartGame()
    {
        _model.Init();
        _model.StartGame();
        _view.StartGame();
    }

    private void EndGame()
    {
        OnEndGame?.Invoke();

       // _model.SavePlayer();
        _view.EndGame(_model.Money, _model.TotalDistanceTraveled);
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
        }
    }

    private void OnViewEnergyChanged(float energyAmount)
    {
        _model.TakeEnergy(energyAmount);
    }
}
