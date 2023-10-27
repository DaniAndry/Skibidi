using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 5f;

    private void FixedUpdate()
    {
        Vector3 newCamPosition = new Vector3(_player.position.x + _offSet.x, _player.position.y + _offSet.y, _player.position.z + _offSet.z);
        Quaternion newCamRotation = Quaternion.Euler(20, 0, 0);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newCamRotation, _speed * Time.deltaTime);
    }
}
