using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private TMP_Text _maxEnergy;
    [SerializeField] private HudWindow _headUpDisplay;
    [SerializeField] private EnergyBoost _energyBoost;
    [SerializeField] private EnergyUpgrade _energyUpgrade;
    [SerializeField] private Bank _bank;

    private Button _energyBoostButton;
    private Button _energyUpgradeButton;

    public event Action<float> EnergyChanging;
    public event Action<float> MaxEnergyChanging;
    public event Action<float,bool>OnMoneyChanging;
    public event Action<EnergyBoost> DistanceBoostChanging;
    public event Action GameOvered;

    private void OnEnable()
    {
        _energyBoostButton.onClick.AddListener(UseEnergyBoost);
        _energyUpgradeButton.onClick.AddListener(OnChangeMaxEnergy);
    }

    private void Awake()
    {
        _energyBoostButton = _energyBoost.GetComponent<Button>();
        _energyUpgradeButton = _energyUpgrade.GetComponent<Button>();
    }

    private void OnDisable()
    {
        _energyBoostButton.onClick.RemoveListener(UseEnergyBoost);
        _energyUpgradeButton.onClick.RemoveListener(OnChangeMaxEnergy);
    }

    public void GameOver()
    {
        GameOvered?.Invoke();
    }

    public void OnEnergyChanged(float energyAmount)
    {
        AudioManager.Instance.Play("UseBoost");
        EnergyChanging?.Invoke(energyAmount);
    }

    public void OnChangeMaxEnergy()
    {
        MaxEnergyChanging?.Invoke(_energyUpgrade.Upgrade());
    }

    public void SetDistance(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void SetEnergy(float energyAmount)
    {
        _energy.text = $"{Convert.ToInt32(energyAmount)}";
    }

    public void UpdateUI(float maxEnergy)
    {
        _maxEnergy.text = maxEnergy.ToString();
    }

    public void AddMoney(int count, bool isBoost)
    {
        _bank.GiveMoney(count);
        OnMoneyChanging?.Invoke(count, isBoost);
    }
    private void UseEnergyBoost()
    {
        if (_energyBoost.TryUse())
            DistanceBoostChanging?.Invoke(_energyBoost);
        else
            Debug.Log("ErrorUseBoost");
    }
}
