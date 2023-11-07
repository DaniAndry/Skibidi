using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _cosmeticsShopButton;
    [SerializeField] private Button _mapsButton;
    [SerializeField] private TMP_Text _currentDistanceText;
    [SerializeField] private TMP_Text _recordDistanceText;
    [SerializeField] private TMP_Text _money;

    private float _recordDistance;

    public event Action ClickingStart;
    public event Action ClickingSettings;
    public event Action ClickingCosmeticsShop;
    public event Action ClickingMaps;

    private void OnEnable()
    {
        _mapsButton.onClick.AddListener(OnClickMaps);
        _startButton.onClick.AddListener(OnClickStart);
        _settingsButton.onClick.AddListener(OnClickSettings);
        _cosmeticsShopButton.onClick.AddListener(OnClickCosmeticsShop);
    }

    private void OnDisable()
    {
        _mapsButton.onClick.RemoveListener(OnClickMaps);
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

    public void SetMoney(int money)
    {
        _money.text = $"{money}";
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
