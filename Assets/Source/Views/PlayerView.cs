using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private Canvas _headUpDisplay;

    public event Action<float> EnergyChanging;

    public void StartGame()
    {
        _headUpDisplay.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        _headUpDisplay.gameObject.SetActive(false);
    }

    public void OnEnergyChanged(float energyAmount)
    {
        EnergyChanging?.Invoke(energyAmount);
    }

    public void SetDistance(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void SetEnergy(float energyAmount)
    {
        _energy.text = $"{Convert.ToInt32(energyAmount)}";
    }
}
