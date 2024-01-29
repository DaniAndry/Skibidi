using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoverModel
{
    private readonly float _maxSpeed = 3f;
    private readonly Rigidbody _rigidbody;
    private readonly Animator _animator;

    private readonly int RunState = Animator.StringToHash("RunState");
    private readonly int CrashState = Animator.StringToHash("CrashState");
    private readonly int JumpState = Animator.StringToHash("JumpState");
    private readonly int LoseState = Animator.StringToHash("LoseState");
    private readonly int KickState = Animator.StringToHash("Kick");

    private float _turnSpeed;
    private float _lastMoveSpeed;
    private float _moveVariableSpeed;
    private float _speedBonus;
    private float _speedTime;
    private float _jumpPower = 2f;
    private float _moveCoefficient;

    private bool _isMove = false;
    private bool _isSpeedBoost;
    private bool _isGrounded = false;
    private bool _enableJump = true;
    private KeyCode _jumpKey = KeyCode.Space;

    public event Action StartedGame;

    public event UnityAction<float> OnChangeSpeed;

    public PlayerMoverModel(Rigidbody rigidbody, Animator animator)
    {
        _rigidbody = rigidbody;
        _animator = animator;
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

            float newXPosition = currentPosition.x + _turnSpeed * _moveCoefficient * Time.deltaTime;
            newXPosition = Mathf.Clamp(newXPosition, -1f, 1f);

            _rigidbody.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);

            if (_enableJump)
                _rigidbody.velocity = new Vector3(0, 0, MoveSpeed);
        }
    }

    public void StartGame()
    {
        MoveSpeed = _maxSpeed;
        _moveVariableSpeed = _maxSpeed;
        _turnSpeed = _maxSpeed;
        _isMove = true;

        StartedGame?.Invoke();

        _animator.Play(RunState);
        OnChangeSpeed?.Invoke(MoveSpeed);
    }

    public void EndGame()
    {
        _isMove = false;
        _rigidbody.velocity = Vector3.zero;
        _animator.Play(LoseState);
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
        _animator.Play(CrashState);
    }

    public void Kick()
    {
        _animator.Play(KickState);
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
            _speedTime = time;
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
        if (_enableJump && Input.GetKeyDown(_jumpKey) && _isGrounded)
        {
            _rigidbody.AddForce(0, _jumpPower, 0f, ForceMode.Impulse);
            _animator.Play(JumpState);
        }
    }

    private void ChangeSpeed()
    {
        if (MoveSpeed != _moveVariableSpeed && _isSpeedBoost == false)
            ChangingSpeed();

        if (MoveSpeed != _moveVariableSpeed && _isSpeedBoost)
        {
            _speedTime -= Time.deltaTime;

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

    private void ChangingSpeed()
    {
        float turnMultiplier = 1.6f;

        MoveSpeed = MoveSpeed < _moveVariableSpeed ? MoveSpeed + 0.01f : MoveSpeed > _moveVariableSpeed ? MoveSpeed - 0.01f : _moveVariableSpeed;
        _turnSpeed = MoveSpeed / turnMultiplier;
        OnChangeSpeed?.Invoke(MoveSpeed);
    }
}