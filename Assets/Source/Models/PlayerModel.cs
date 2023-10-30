using System;
using UnityEngine;

public class PlayerModel
{
    private Vector3 _lastPosition;
    private float _totalDistanceTraveled;

    public float MaxEnergy { get; private set; } = 50f;
    public float CurrentEnergy { get; private set; }

    public event Action StartedGame;
    public event Action EnergyChanged;

    public void Init()
    {
        CurrentEnergy = MaxEnergy;
    }

    public void TakeEnergy(float count)
    {
        CurrentEnergy += count;
    }

    public void StartGame()
    {
        StartedGame?.Invoke();
    }

    public void UpMaxEnergy(float count)
    {
        MaxEnergy += count;
    }

    private void GiveEnergy(Transform transform)
    {
        float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
        _totalDistanceTraveled += distanceMoved;

        CurrentEnergy -= distanceMoved;

        _lastPosition = transform.position;

        EnergyChanged?.Invoke();
    }

    public void Update(Transform transform)
    {
        GiveEnergy(transform);
    }
}
