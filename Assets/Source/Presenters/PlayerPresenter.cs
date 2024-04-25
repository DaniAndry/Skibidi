using System;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    private PlayerModel _model;
    private PlayerView _view;

    public event Action OnEndGame;

    private void Update()
    {
        _model?.Update(_view.transform);
    }

    public void Init(PlayerModel model, PlayerView view)
    {
        _model = model;
        _view = view;

        _view.UpdateUI(_model.MaxEnergy);
    }

    public void StartGame()
    {
        _model.Init();
        _model.StartGame();
    }

    public void ResurrectPlayer(float energy)
    {
        _model.Resurrect(energy);
    }

    public float TakeTotalDistance()
    {
        return _model.TotalDistanceTraveled;
    }

    public void ResetPlayer()
    {
        _model.ResetGame(_view.transform);
    }

    public void Enable()
    {
        _model?.Init();

        _view.MaxEnergyChanging += OnMaxEnergyChanging;
        _view.DistanceBoostChanging += UseDistanceDistanceBoost;
        _model.EnergyChanged += OnEnergyChanging;
        _model.OnEnergyGone += EndGame;
        _view.GameOvered += EndGame;
        _model.DistanceChanging += OnDistanceChanging;
        _view.EnergyChanging += OnViewEnergyChanged;
    }

    public void Disable()
    {
        _view.MaxEnergyChanging -= OnMaxEnergyChanging;
        _view.DistanceBoostChanging -= UseDistanceDistanceBoost;
        _model.EnergyChanged -= OnEnergyChanging;
        _model.OnEnergyGone -= EndGame;
        _view.GameOvered -= EndGame;
        _model.DistanceChanging -= OnDistanceChanging;
        _view.EnergyChanging -= OnViewEnergyChanged;
    }

    private void UseDistanceDistanceBoost(EnergyBoost energyBoost)
    {
        _model.TurnOnEnergyBoost(energyBoost.Bonus, energyBoost.Time);
    }

    private void OnEnergyChanging()
    {
        _view.SetEnergy(_model.CurrentEnergy);
    }

    private void OnDistanceChanging()
    {
        _view.SetDistance(_model.TotalDistanceTraveled);
    }

    private void OnViewEnergyChanged(float energyAmount)
    {
        _model.TakeEnergy(energyAmount);
    }

    private void OnMaxEnergyChanging(float maxEnergyAmount)
    {
        _model.ChangeMaxEnergy(maxEnergyAmount);
        _view.UpdateUI(_model.MaxEnergy);
    }

    private void EndGame()
    {
        OnEndGame?.Invoke();
    }
}
