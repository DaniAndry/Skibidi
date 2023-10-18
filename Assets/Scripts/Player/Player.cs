using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private Vector3 _lastPosition;

    private float _totalDistanceTraveled;
    private float _maxEnergy = 50f;
    private float _currentEnergy;

    private void Start()
    {
        _lastPosition = transform.position;
        _mover = GetComponent<PlayerMover>();
        _currentEnergy = _maxEnergy;
    }

    private void FixedUpdate()
    {
        float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
        _totalDistanceTraveled += distanceMoved;

        _currentEnergy -= distanceMoved;

        if (_currentEnergy <= 0)
        {
            Crash();
        }

        _lastPosition = transform.position;
    }


    public void TakeEnergy(int count)
    {
        _currentEnergy += count;
    }

    public void TakeSpeed(float count)
    {
        count += _mover.MoveSpeed;

        _mover.ChangeSpeed(count);
    }

    public void Crash()
    {
        int moveSpeed = 2;

        _mover.ChangeSpeed(moveSpeed);
    }
}
