using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private Canvas _headUpDisplay;
    [SerializeField] private TMP_Text _money;

    public event Action<float> EnergyChanging;
    public event Action<int> OnChangingMoney;

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

    public void SetMoney(int money)
    {
        _money.text = $"{money}";
    }

    public void ChangingMoney(int money)
    {
        Debug.Log("view");
        OnChangingMoney?.Invoke(money); 
    }

    public void SetEnergy(float energyAmount)
    {
        _energy.text = $"{Convert.ToInt32(energyAmount)}";
    }
}
