using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        transform.position = _player.position + _offSet;
    }
}
