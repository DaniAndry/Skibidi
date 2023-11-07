using System;
using UnityEngine;

public class PlayerModel
{
    private Vector3 _lastPosition;
    private bool _isEnergyGone = false;

    public int Money { get; private set; }
    public float TotalDistanceTraveled { get; private set; }
    public float MaxEnergy { get; private set; } = 50f;
    public float CurrentEnergy { get; private set; }

    public event Action StartedGame;
    public event Action EnergyChanged;
    public event Action DistanceChanging;
    public event Action OnEnergyGone;

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
        TotalDistanceTraveled = 0;
    }

    public void UpMaxEnergy(float count)
    {
        MaxEnergy += count;
    }

    private void GiveEnergy(Transform transform)
    {
        if (CurrentEnergy > 0)
        {
            float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
            TotalDistanceTraveled += distanceMoved;

            CurrentEnergy -= distanceMoved;

            _lastPosition = transform.position;

            DistanceChanging?.Invoke();
            EnergyChanged?.Invoke();

            _isEnergyGone = false;
        }
        else if(_isEnergyGone == false)
        {
            OnEnergyGone?.Invoke();
            _isEnergyGone = true;
        }
    }

    public void Update(Transform transform)
    {
        GiveEnergy(transform);
    }
}
