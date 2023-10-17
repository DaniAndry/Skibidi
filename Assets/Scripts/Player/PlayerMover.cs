using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    private float _moveSpeed = 5f;
    private float _turnSpeed = 3f;
    private Rigidbody _rigidbody;
    private Coroutine _speedCoroutine;
    private WaitForSeconds _waitRestoreSpeed = new WaitForSeconds(0.5f);

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(0, 0, _moveSpeed);

        DecktopContorol();
        MobileContorol();
    }

    private void DecktopContorol()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * -1, 0, _moveSpeed);
        }
        if (Input.GetKey(KeyCode.D) || _joystick.Horizontal > 0)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * 1, 0, _moveSpeed);
        }
    }

    private void MobileContorol()
    {
        if (_joystick.Horizontal < 0f && _joystick.Horizontal > -1)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * _joystick.Horizontal, 0, _moveSpeed);
        }
        if (_joystick.Horizontal > 0f && _joystick.Horizontal < 1)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * _joystick.Horizontal, 0, _moveSpeed);
        }
    }

    public void ChangeSpeed()
    {
        float moveSpeed = _moveSpeed;
        float turnSpeed = _turnSpeed;

        _moveSpeed = 1f;
        _turnSpeed = 1f;

        _speedCoroutine = StartCoroutine(RestoreSpeed(moveSpeed, turnSpeed));
    }

    private IEnumerator RestoreSpeed(float moveSpeed, float turnSpeed)
    {
        while (_moveSpeed < moveSpeed || _turnSpeed < turnSpeed)
        {
            if (_moveSpeed < moveSpeed)
                _moveSpeed++;

            if (_turnSpeed < turnSpeed)
                _turnSpeed++;

            yield return _waitRestoreSpeed;
        }
    }
}

