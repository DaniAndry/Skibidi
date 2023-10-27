/*using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 3f;

    private Rigidbody _rigidbody;
    private Coroutine _speedCoroutine;
    private WaitForSeconds _waitRestoreSpeed = new WaitForSeconds(0.1f);

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(0, 0, _moveSpeed);

        DecktopContorol();
        *//*MobileContorol();*//*
    }

    private void DecktopContorol()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * -1, 0, _moveSpeed);
        }
        if (Input.GetKey(KeyCode.D) *//*|| _joystick.Horizontal > 0*//*)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * 1, 0, _moveSpeed);
        }
    }

  *//*  private void MobileContorol()
    {
        if (_joystick.Horizontal < 0f && _joystick.Horizontal > -1)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * _joystick.Horizontal, 0, _moveSpeed);
        }
        if (_joystick.Horizontal > 0f && _joystick.Horizontal < 1)
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * _joystick.Horizontal, 0, _moveSpeed);
        }
    }*//*

    public void ChangeSpeed(float moveSpeed)
    {
        _speedCoroutine = StartCoroutine(RestoreSpeed(moveSpeed));
    }

    private IEnumerator RestoreSpeed(float moveSpeed)
    {
        float turnMultiplier = 1.6f;

        while (_moveSpeed != moveSpeed)
        {
            _moveSpeed = _moveSpeed < moveSpeed ? _moveSpeed + 1 : _moveSpeed > moveSpeed ? _moveSpeed - 1 : _moveSpeed;
            _turnSpeed = _moveSpeed / turnMultiplier;
            yield return _waitRestoreSpeed;
        }
    }
}
*/
