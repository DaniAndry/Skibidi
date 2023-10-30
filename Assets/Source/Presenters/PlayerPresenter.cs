using System;
using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel _model;
    private PlayerView _view;
    private Menu _viewMenu;

    public PlayerPresenter(PlayerModel model, PlayerView view, Menu viewMenu)
    {
        _model = model;
        _view = view;
        _viewMenu = viewMenu;
    }

    public void Enable()
    {
        _model.StartedGame += OnStartedgame;
        _model.EnergyChanged += OnEnergyChanged;
        _view.EnergyChanged += OnViewEnergyChanged;
        _view.UpdatePlayer += Update;
        _viewMenu.ClickStart += OnClickStart;
    /*    _viewMenu.ClickUpgradeEnergy += OnClickUpgradeEnergy;*/
    }

    public void Disable()
    {
        _model.StartedGame -= OnStartedgame;
        _model.EnergyChanged -= OnEnergyChanged;
        _view.EnergyChanged -= OnViewEnergyChanged;
        _view.UpdatePlayer -= Update;
        _viewMenu.ClickStart -= OnClickStart;
    /*    _viewMenu.ClickUpgradeEnergy -= OnClickUpgradeEnergy;*/
    }

    public void Update(Transform transform)
    {
        _model.Update(transform);
    }

    private void OnClickUpgradeEnergy(float count)
    {
        _model.UpMaxEnergy(count);
    }

    private void OnClickStart()
    {
        _model.StartGame();
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
