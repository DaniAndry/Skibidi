using UnityEngine;
using System;

public class PlayerMoverPresenter
{
    private PlayerMoverModel _model;
    private PlayerMoverView _view;
    private Menu _viewMenu;
    private IUpdateable _iupdateable = null;

    public void Init()
    {
        if (_model is IUpdateable)
            _iupdateable = (IUpdateable)_model;
    }

    public PlayerMoverPresenter(PlayerMoverModel model, PlayerMoverView view, Menu viewMenu)
    {
        _model = model;
        _view = view;
        _viewMenu = viewMenu;
    }

    public void Enable()
    {
        _model.StartedGame += OnStartedGame;
        _model.ChangedSpeed += OnSpeedChanged;
        _viewMenu.ClickStart += OnClickStart;
        _view.OnMove += Move;
        _view.ChangeSpeedCrash += ChangeSpeedCrash;
        _view.ChangeSpeedBoost += ChangeSpeedBoost;
        _view.UpdateMover += Update;
    }

    public void Disable()
    {
        _model.StartedGame -= OnStartedGame;
        _model.ChangedSpeed -= OnSpeedChanged;
        _view.OnMove -= Move;
        _view.ChangeSpeedCrash -= ChangeSpeedCrash;
        _view.ChangeSpeedBoost -= ChangeSpeedBoost;
        _view.UpdateMover -= Update;
        _viewMenu.ClickStart -= OnClickStart;
    }

    private void Update()
    {
        _iupdateable?.Update();
    }

    private void OnStartedGame()
    {
        _view.StartGame();
    }

    private void OnClickStart()
    {
        _model.StartGame();
    }

    private void OnSpeedChanged()
    {
        _view.SetSpeed(_model.MoveSpeed);
    }

    private void ChangeSpeedCrash(float moveSpeed)
    {
        _model.ChangeSpeedCrash(moveSpeed);
    }

    private void ChangeSpeedBoost(float moveSpeed)
    {
        _model.ChangeSpeedBoost(moveSpeed);
    }

    public void Move(float coefficient)
    {
        _model.Move(coefficient);
    }
}
