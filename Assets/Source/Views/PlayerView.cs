using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private HudWindow _headUpDisplay;
    [SerializeField] private Menu _menu;
    [SerializeField] private EndGameScreen _endScreen;
    [SerializeField] private EnergyBoost _energyBoost;
    [SerializeField] private EnergyUpgrade _energyUpgrade;
    [SerializeField] private Bank _bank;

    private Button _energyBoostButton;
    private Button _energyUpgradeButton;

    public event Action<float> EnergyChanging;
    public event Action<float> MaxEnergyChanging;
    public event Action<EnergyBoost> DistanceBoostChanging;

    private void Awake()
    {
        _energyBoostButton = _energyBoost.GetComponent<Button>();
        _energyUpgradeButton = _energyUpgrade.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _energyBoostButton.onClick.AddListener(UseEnergyBoost);
        _energyUpgradeButton.onClick.AddListener(() => OnChangeMaxEnergy(_energyUpgrade.AmountEnergy));
    }

    private void OnDisable()
    {
        _energyBoostButton.onClick.RemoveListener(UseEnergyBoost);
        _energyUpgradeButton.onClick.RemoveListener(() => OnChangeMaxEnergy(_energyUpgrade.AmountEnergy));
    }

    private void UseEnergyBoost()
    {
        if (_energyBoost.TryUse())
            DistanceBoostChanging?.Invoke(_energyBoost);
        else
            Debug.Log("ErrorUseBoost");
    }

    public void StartGame()
    {
        _headUpDisplay.Open();
    }

    public void EndGame(float distance)
    {
        _headUpDisplay.Close();
        _menu.SetDistance(distance);
        _endScreen.OpenEndScreen();
        _endScreen.SetData(distance);
    }

    public void OnEnergyChanged(float energyAmount)
    {
        AudioManager.Instance.Play("UseBoost");
        EnergyChanging?.Invoke(energyAmount);
    }

    public void OnChangeMaxEnergy(float maxEnergyAmount)
    {
        if (_bank.TryTakeMoney(_energyUpgrade.Price))
        {
            _bank.TakeMoney(_energyUpgrade.Price);
            _energyUpgrade.Upgrade();
            MaxEnergyChanging?.Invoke(maxEnergyAmount);
        }
    }

    public void SetDistance(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void SetEnergy(float energyAmount)
    {
        _energy.text = $"{Convert.ToInt32(energyAmount)}";
    }

    public void AddMoney(int count)
    {
        _bank.GiveMoney(count);
    }
}
