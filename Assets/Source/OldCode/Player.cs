/*using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private Vector3 _lastPosition;

    private float _totalDistanceTraveled;

    private void Start()
    {
        _lastPosition = transform.position;
        _mover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
        _totalDistanceTraveled += distanceMoved;

        *//*_currentEnergy -= distanceMoved;

        if (_currentEnergy <= 0)
        {
            Crash();
        }
*//*
        _lastPosition = transform.position;
    }
}
*/