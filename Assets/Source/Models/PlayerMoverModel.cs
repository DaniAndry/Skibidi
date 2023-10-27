using System;
using UnityEngine;

public class PlayerMoverModel : IPhysics, IUpdateable
{
    private float _turnSpeed = 3f;
    private float _moveVariableSpeed = 2f;
    private Rigidbody _rigidbody;
    private bool _isMove = false;

    public float MoveSpeed { get; private set; } = 5f;

    public event Action StartedGame;
    public event Action ChangedSpeed;

    public PlayerMoverModel(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public Vector3 GetVelocity()
    {
        return _rigidbody.velocity;
    }

    public void Move(float coefficient)
    {
        if (_isMove)
        {
            Vector3 velocity = GetVelocity();
            velocity = new Vector3(_turnSpeed * coefficient, 0, MoveSpeed);
            SetVelocity(velocity);
        }
    }

    public void StartGame()
    {
        _isMove = true;
        StartedGame?.Invoke();
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