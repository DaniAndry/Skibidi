using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private Canvas _headUpDisplay;

    public event Action<float> EnergyChanged;
    public event Action<Transform> UpdatePlayer;

    private void Update()
    {
        UpdatePlayer?.Invoke(transform);
    }

    public void StartGame()
    {
        _headUpDisplay.gameObject.SetActive(true);
    }

    public void OnEnergyChanged(float energyAmount)
    {
        EnergyChanged?.Invoke(energyAmount);
    }

    public void SetEnergy(float energyAmount)
    {
        _energy.text = $"{Convert.ToInt32(energyAmount * -1)}";
    }
}
