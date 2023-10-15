using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 5f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(0, 0, _moveSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * -1, 0, _moveSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(_turnSpeed * 1, 0, _moveSpeed);
        }
    }
}

