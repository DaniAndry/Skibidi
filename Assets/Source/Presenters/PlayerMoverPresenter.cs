using UnityEngine;
using System;

public class PlayerMoverPresenter : MonoBehaviour
{
    private PlayerMoverModel _model;
    private PlayerMoverView _view;
    private Menu _viewMenu;

    public void Init(PlayerMoverModel model, PlayerMoverView view, Menu viewMenu)
    {
        _model = model;
        _view = view;
        _viewMenu = viewMenu;
    }

    public void Enable()
    {
        _model.StartedGame += OnStartedGame;
        _model.ChangedSpeed += OnSpeedChanged;
        _viewMenu.ClickingStart += StartGame;
        _view.OnMoving += Move;
        _view.ChangingSpeedCrash += ChangeSpeedCrash;
        _view.ChangingSpeedBoost += ChangeSpeedBoost;
        _view.OnEndGame += EndGame;
    }

    public void Disable()
    {
        _model.StartedGame -= OnStartedGame;
        _model.ChangedSpeed -= OnSpeedChanged;
        _view.OnMoving -= Move;
        _view.ChangingSpeedCrash -= ChangeSpeedCrash;
        _view.ChangingSpeedBoost -= ChangeSpeedBoost;
        _viewMenu.ClickingStart -= StartGame;
        _view.OnEndGame -= EndGame;
    }

    private void Update()
    {
        _model?.Update();
    }

    private void OnStartedGame()
    {
        _view.StartGame();
    }

    private void EndGame()
    {
        _model.EndGame();
    }

    private void StartGame()
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
