using System;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    private PlayerModel _model;
    private PlayerView _view;
    private Menu _viewMenu;
    private EndScreenView _viewEndScreen;
    private PlayerMoverView _viewMover;

    public void Init(PlayerModel model, PlayerView view, Menu viewMenu, EndScreenView viewEndScreen, PlayerMoverView viewMover)
    {
        _model = model;
        _view = view;
        _viewMenu = viewMenu;
        _viewEndScreen = viewEndScreen;
        _viewMover = viewMover;
    }

    private void Start()
    {
        _model?.Init();
    }

    public void Enable()
    {
        _model.OnEnergyGone += EndGame;
        _model.DistanceChanging += OnDistanceChanged;
        _model.StartedGame += OnStartedgame;
        _model.EnergyChanged += OnEnergyChanged;
        _view.EnergyChanging += OnViewEnergyChanged;
        _viewMenu.ClickingStart += OnClickStart;
    /*    _viewMenu.ClickUpgradeEnergy += OnClickUpgradeEnergy;*/
    }

    public void Disable()
    {
        _model.OnEnergyGone -= EndGame;
        _model.DistanceChanging -= OnDistanceChanged;
        _model.StartedGame -= OnStartedgame;
        _model.EnergyChanged -= OnEnergyChanged;
        _view.EnergyChanging -= OnViewEnergyChanged;
        _viewMenu.ClickingStart -= OnClickStart;
    /*    _viewMenu.ClickUpgradeEnergy -= OnClickUpgradeEnergy;*/
    }

    private void Update()
    {
        _model?.Update(_view.transform);
    }

/*    private void OnClickUpgradeEnergy(float count)
    {
        _model.UpMaxEnergy(count);
    }*/

    private void EndGame()
    {
        _view.EndGame();
        _viewEndScreen.OpenEndScreen();
        _viewEndScreen.SetDate(_model.Money, _model.CurrentEnergy);
        _viewMover.EndGame();
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
