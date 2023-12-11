using UnityEngine;
using System;

public class PlayerMoverPresenter : MonoBehaviour
{
    private PlayerMoverModel _model;
    private PlayerMoverView _view;

    public void Init(PlayerMoverModel model, PlayerMoverView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _view.OnMoving += Move;
        _view.ChangingSpeedCrash += ChangeSpeedCrash;
        _view.ChangingSpeedBoost += ChangeSpeedBoost;
    }

    public void Disable()
    {
        _view.OnMoving -= Move;
        _view.ChangingSpeedCrash -= ChangeSpeedCrash;
        _view.ChangingSpeedBoost -= ChangeSpeedBoost;
    }

    private void Update()
    {
        _model?.Update();
    }

    public void EndGame()
    {
        _model.EndGame();
        _view.EndGame();
    }

    public void StartGame()
    {
        _model.StartGame();
        _view.StartGame();
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
