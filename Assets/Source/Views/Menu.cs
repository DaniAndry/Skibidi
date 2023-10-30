using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _cosmeticsShopButton;
    [SerializeField] private Button _upgradeEnergyButton;
    [SerializeField] private Button _mapsButton;

    public event Action ClickStart;
    public event Action ClickSettings;
    public event Action ClickCosmeticsShop;
    public event Action ClickUpgradeEnergy;
    public event Action ClickMaps;

    private void OnEnable()
    {
        _mapsButton.onClick.AddListener(OnClickMaps);
        _upgradeEnergyButton.onClick.AddListener(OnClickUpgradeEnergy);
        _startButton.onClick.AddListener(OnClickStart);
        _settingsButton.onClick.AddListener(OnClickSettings);
        _cosmeticsShopButton.onClick.AddListener(OnClickCosmeticsShop);
    }

    private void OnDisable()
    {
        _mapsButton.onClick.RemoveListener(OnClickMaps);
        _upgradeEnergyButton.onClick.RemoveListener(OnClickUpgradeEnergy);
        _startButton.onClick.RemoveListener(OnClickStart);
        _settingsButton.onClick.RemoveListener(OnClickSettings);
        _cosmeticsShopButton.onClick.RemoveListener(OnClickCosmeticsShop);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

    private void OnClickMaps()
    {
        ClickMaps?.Invoke();
    }

    private void OnClickUpgradeEnergy()
    {
        ClickUpgradeEnergy?.Invoke();
    }

   private void OnClickCosmeticsShop()
    {
        ClickCosmeticsShop?.Invoke();
    }

    private void OnClickSettings()
    {
        ClickSettings?.Invoke();
    }

    private void OnClickStart()
    {
        ClickStart?.Invoke();
    }
}
