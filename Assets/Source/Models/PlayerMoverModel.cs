using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoverModel
{
    private readonly float _maxSpeed = 4f;
    private readonly float _maxTurnSpeed = 1.5f;
    private readonly Rigidbody _rigidbody;

    private float _turnSpeed;
    private float _lastMoveSpeed;
    private float _moveVariableSpeed;
    private float _speedBonus;
    private float _speedTime;
    private float _jumpPower = 3f;
    private float _moveCoefficient;

    private bool _isMove = false;
    private bool _isSpeedBoost;
    private bool _isGrounded = false;
    private bool _enableJump = true;

    private PlayerInputHandler _inputHandler;

    public event Action Jumped;

    public event Action<float> OnChangeSpeed;
    public event Action<float> OnChangingBoostTime;

    public PlayerMoverModel(Rigidbody rigidbody, Animator animator)
    {
        _rigidbody = rigidbody;
        _inputHandler = PlayerInputHandler.Instance;
    }

    public float MoveSpeed { get; private set; }

    public void SetDataMove(float coefficient)
    {
        _moveCoefficient = coefficient;
    }

    public void Move()
    {
        if (_isMove)
        {
            Vector3 currentPosition = _rigidbody.position;

            float turn = DefineTurn();

            float newXPosition = currentPosition.x + _turnSpeed * turn * Time.deltaTime;
            newXPosition = Mathf.Clamp(newXPosition, -1.5f, 1.5f);

            _rigidbody.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);

            if (_enableJump)
                _rigidbody.velocity = new Vector3(0, 0, MoveSpeed);

            if (_inputHandler.JumpTriggered)
                Jump();

            if (_inputHandler.JumpMobileTriggered.y > _inputHandler.DeltaMobileJump)
                Jump();
        }
    }

    public void StartMove()
    {
        MoveSpeed = _maxSpeed;
        _moveVariableSpeed = _maxSpeed;
        _isMove = true;
        _turnSpeed = _maxTurnSpeed;
        OnChangeSpeed?.Invoke(MoveSpeed);

        _isSpeedBoost = false;
        OnChangingBoostTime?.Invoke(0);
    }

    public void ResetMove()
    {
        _rigidbody.velocity = Vector3.zero;
        _isMove = false;
        MoveSpeed = 0;
        _moveVariableSpeed = 0;
        _turnSpeed = 0;
    }

    public void EndMove()
    {
        _isMove = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void Update()
    {
        ChangeSpeed();
        CheckGround();
        Move();
    }

    public void ChangeSpeedCrash(float moveSpeed)
    {
        _moveVariableSpeed = moveSpeed;
        _isSpeedBoost = false;
    }

    public void TurnOnSpeedBoost(float bonus, float time)
    {
        if (_isSpeedBoost == false)
        {
            _speedBonus = bonus;
            _speedTime = time;
            _isSpeedBoost = true;

            _lastMoveSpeed = _moveVariableSpeed;
            _moveVariableSpeed += _speedBonus;
            _moveVariableSpeed = _moveVariableSpeed > 10 ? 10 : _moveVariableSpeed;
        }
        else
        {
            _speedTime += time;
        }
    }

    public void CheckGround()
    {
        Transform transform = _rigidbody.transform;

        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * 0.5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = 100f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            Debug.DrawLine(origin, direction * distance, Color.red);
            _isGrounded = false;
            _enableJump = false;
        }
        else
        {
            _isGrounded = true;
            _enableJump = true;
        }
    }

    public void Jump()
    {
        if (_enableJump && _isGrounded)
        {
            Jumped?.Invoke();
            _rigidbody.AddForce(0, _jumpPower, 0, ForceMode.Impulse);
            TaskCounter.IncereaseProgress(1, Convert.ToString(TaskType.Jump));
        }
    }

    public void Somersault()
    {
        _rigidbody.AddForce(0, _jumpPower, 1, ForceMode.Impulse);
    }

    private void ChangeSpeed()
    {
        if (MoveSpeed != _moveVariableSpeed && _isSpeedBoost == false)
            ChangingSpeed();

        if (MoveSpeed != _moveVariableSpeed && _isSpeedBoost)
        {
            _speedTime -= Time.deltaTime;
            OnChangingBoostTime?.Invoke(_speedTime);

            if (_speedTime > 0)
            {
                ChangingSpeed();
            }
            else
            {
                _moveVariableSpeed = _lastMoveSpeed;
                _isSpeedBoost = false;
            }
        }
    }

    private float DefineTurn()
    {
        float turn;

        if (_moveCoefficient == 0 && _inputHandler.TurnInput.x != 0)
            turn = _inputHandler.TurnInput.x;
        else if (_moveCoefficient != 0 && _inputHandler.TurnInput.x == 0)
            turn = _moveCoefficient;
        else
            turn = 0;

        return turn;
    }

    private void ChangingSpeed()
    {
        float turnMultiplier = 2f;

        MoveSpeed = MoveSpeed < _moveVariableSpeed ? MoveSpeed + 0.01f : MoveSpeed > _moveVariableSpeed ? MoveSpeed - 0.01f : _moveVariableSpeed;
        _turnSpeed = MoveSpeed / turnMultiplier;
        OnChangeSpeed?.Invoke(MoveSpeed);
    }
}