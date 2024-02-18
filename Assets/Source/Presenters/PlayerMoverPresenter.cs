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
        _view.OnMoving += SetDataMove;
        _view.OnJumping += Jump;
        _view.OnChangingSpeedCrash += ChangeSpeedCrash;
        _view.OnSpeedBoostChanging += OnSpeedChanging;
        _view.OnSomersault += Somerslaut;
        _view.OnCrashed += EndGame;
        _model.OnChangeSpeed += _view.ChangeCurrentSpeed;
        _model.Jumped += _view.Jump;
    }

    public void Disable()
    {
        _view.OnMoving -= SetDataMove;
        _view.OnJumping -= Jump;
        _view.OnChangingSpeedCrash -= ChangeSpeedCrash;
        _view.OnSpeedBoostChanging -= OnSpeedChanging;
        _view.OnSomersault -= Somerslaut;
        _view.OnCrashed -= EndGame;
        _model.OnChangeSpeed -= _view.ChangeCurrentSpeed;
        _model.Jumped -= _view.Jump;
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

    private void SetDataMove(float coefficient)
    {
        _model.SetDataMove(coefficient);
    }

    private void Jump()
    {
        _model.Jump();
    }

    private void Somerslaut()
    {
        _model.Somersault();
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
