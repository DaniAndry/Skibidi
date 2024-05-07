using System;
using UnityEngine;

public class PlayerModel
{
    private Vector3 _lastPosition;
    private bool _isEnergyGone = false;
    private float _energyBonus;
    private float _energyTime;
    private bool _isEnergyBoost = false;

    public event Action DistanceChanging;
    public event Action OnEnergyGone;
    public event Action EnergyChanged;

    public float TotalDistanceTraveled { get; private set; }
    public float MaxEnergy { get; private set; } = 40f;
    public float CurrentEnergy { get; private set; }


    public void Init()
    {
        /*LoadPlayer();*/
        CurrentEnergy = MaxEnergy;
    }

    public void TakeEnergy(float count)
    {
        CurrentEnergy += count;
    }

    public void StartGame()
    {      
        CurrentEnergy = MaxEnergy;
        _isEnergyGone = false;
    }

    public void Resurrect(float energy)
    {
        CurrentEnergy = energy;
        _isEnergyGone = false;
    }

    public void ResetGame(Transform transformPosition)
    {
        _lastPosition = transformPosition.position;
        CurrentEnergy = MaxEnergy;
        TotalDistanceTraveled = 0;
        CurrentEnergy = MaxEnergy;
    }

    public void Update(Transform transform)
    {
        GiveEnergy(transform);
    }

    public void ChangingEnergy(float distanceMoved)
    {
        if (_isEnergyBoost == false)
        {
            CurrentEnergy -= distanceMoved;
        }
        else if (_isEnergyBoost)
        {
            _energyTime -= Time.deltaTime;

            if (_energyTime > 0)
            {
                distanceMoved /= _energyBonus;
                CurrentEnergy -= distanceMoved;
            }
            else if(_energyTime <= 0)
            {
                _isEnergyBoost = false;
            }
        }
    }

    public void TurnOnEnergyBoost(float bonus, float time)
    {
        _energyBonus = bonus;
        _energyTime = time;
        _isEnergyBoost = true;
    }

    public void ChangeMaxEnergy(float maxEnergyAmount)
    {
        MaxEnergy += maxEnergyAmount;
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
            TotalDistanceTraveled = data.TotalDistance;
        }
    }

    private void GiveEnergy(Transform transform)
    {
        if (CurrentEnergy > 0 && _isEnergyGone == false)
        {
            float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
            TotalDistanceTraveled += distanceMoved;

            ChangingEnergy(distanceMoved);

            _lastPosition = transform.position;

            DistanceChanging?.Invoke();
            EnergyChanged?.Invoke();

            if (CurrentEnergy <= 0)
            {
                _isEnergyGone = true;
                OnEnergyGone?.Invoke();
            }
        }
    }
}
