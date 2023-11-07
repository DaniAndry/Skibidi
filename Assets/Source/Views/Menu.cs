using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _cosmeticsShopButton;
    [SerializeField] private Button _upgradeEnergyButton;
    [SerializeField] private Button _mapsButton;
    [SerializeField] private TMP_Text _currentDistanceText;
    [SerializeField] private TMP_Text _recordDistanceText;

    private float _recordDistance;

    public event Action ClickingStart;
    public event Action ClickingSettings;
    public event Action ClickingCosmeticsShop;
    public event Action ClickingUpgradeEnergy;
    public event Action ClickingMaps;

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

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
    }

    private void OnClickMaps()
    {
        ClickingMaps?.Invoke();
    }

    private void OnClickUpgradeEnergy()
    {
        ClickingUpgradeEnergy?.Invoke();
    }

   private void OnClickCosmeticsShop()
    {
        ClickingCosmeticsShop?.Invoke();
    }

    private void OnClickSettings()
    {
        ClickingSettings?.Invoke();
    }

    private void OnClickStart()
    {
        ClickingStart?.Invoke();
    }

    public void SetDistance(float distance)
    {
        _currentDistanceText.text = $"{Convert.ToInt32(distance)}";

        if(distance > _recordDistance)
        {
            _recordDistanceText.text = $"{Convert.ToInt32(distance)}";
        }
    }
}
