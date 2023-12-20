using UnityEngine;

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
        _view.OnJumping += Jump;
        _view.ChangingSpeedCrash += ChangeSpeedCrash;
        _view.SpeedBoostChanging += OnSpeedChanging;
    }

    public void Disable()
    {
        _view.OnMoving -= Move;
        _view.OnJumping -= Jump;
        _view.ChangingSpeedCrash -= ChangeSpeedCrash;
        _view.SpeedBoostChanging -= OnSpeedChanging;
    }

    private void FixedUpdate()
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

    private void Move(float coefficient)
    {
        _model.Move(coefficient);
    }

    private void Jump()
    {
        _model.Jump();
    }

    private void ChangeSpeedCrash(float moveSpeed)
    {
        _model.ChangeSpeedCrash(moveSpeed);
    }

    private void OnSpeedChanging(float bonus, float time)
    {
        _model.TurnOnSpeedBoost(bonus, time);
    }

}
