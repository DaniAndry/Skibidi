using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerModel
{
    private Vector3 _lastPosition;
    private bool _isEnergyGone = false;

    public int Money { get; private set; } = 50;
    public float TotalDistanceTraveled { get; private set; }
    public float MaxEnergy { get; private set; } = 50f;
    public float CurrentEnergy { get; private set; }

    public event Action EnergyChanged;
    public event Action DistanceChanging;
    public event Action OnEnergyGone;
    public event Action OnEnergyUpgraded;
    public event Action OnErrorUpgraded;

    public void Init()
    {
        LoadPlayer();
        CurrentEnergy = MaxEnergy;
    }

    public void TakeEnergy(float count)
    {
        CurrentEnergy += count;
    }

    public void StartGame()
    {
        TotalDistanceTraveled = 0;
    }

    public void UpMaxEnergy(int price, float energy)
    {
        if (TryChangeMoney(price))
        {
            MaxEnergy += energy;
            OnEnergyUpgraded?.Invoke();
        }
        else
            OnErrorUpgraded?.Invoke();
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
        else if (_isEnergyGone == false)
        {
            OnEnergyGone?.Invoke();
            _isEnergyGone = true;
        }
    }

    public void Update(Transform transform)
    {
        GiveEnergy(transform);
    }

    public bool TryBuySkin(int price)
    {
        return TryChangeMoney(price);
    }

    private bool TryChangeMoney(int price)
    {
        if (Money >= price)
        {
            Money -= price;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            MaxEnergy = data.Energy;
            Money = data.Money;
            TotalDistanceTraveled = data.TotalDistance;
        }
    }
}
