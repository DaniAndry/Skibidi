using System;
using UnityEngine;

public class PlayerMoverModel
{
    private float _turnSpeed;
    private float _moveVariableSpeed;
    private bool _isMove = false;
    private readonly float _maxSpeed = 5f;
    private readonly Rigidbody _rigidbody;

    public event Action StartedGame;
    public event Action ChangedSpeed;

    public PlayerMoverModel(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public float MoveSpeed { get; private set; }

    public void Move(float coefficient)
    {
        if (_isMove)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * coefficient, 0, MoveSpeed);
        }
    }

    public void StartGame()
    {
        MoveSpeed = _maxSpeed;
        _moveVariableSpeed = _maxSpeed;
        _turnSpeed = _maxSpeed;
        _isMove = true;

        StartedGame?.Invoke();
        ChangedSpeed?.Invoke();
    }

    public void EndGame()
    {
        _isMove = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void Update()
    {
        ChangeSpeed();
    }

    public void ChangeSpeedCrash(float moveSpeed)
    {
        _moveVariableSpeed = moveSpeed;
    }

    public void ChangeSpeedBoost(float moveSpeed)
    {
        moveSpeed += MoveSpeed;
        _moveVariableSpeed = moveSpeed;
    }

    private void ChangeSpeed()
    {
        if (MoveSpeed != _moveVariableSpeed)
        {
            float turnMultiplier = 1.6f;

            MoveSpeed = MoveSpeed < _moveVariableSpeed ? MoveSpeed + 0.01f : MoveSpeed > _moveVariableSpeed ? MoveSpeed - 0.01f : _moveVariableSpeed;
            _turnSpeed = MoveSpeed / turnMultiplier;

            ChangedSpeed?.Invoke();
        }
    }
}