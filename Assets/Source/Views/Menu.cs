using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _cosmeticsShopButton;

    public event Action ClickStart;
    public event Action ClickSettings;
    public event Action ClickCosmeticsShop;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnClickStart);
        _settingsButton.onClick.AddListener(OnClickSettings);
        _cosmeticsShopButton.onClick.AddListener(OnClickCosmeticsShop);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnClickStart);
        _settingsButton.onClick.RemoveListener(OnClickSettings);
        _cosmeticsShopButton.onClick.RemoveListener(OnClickCosmeticsShop);
    }

    public void HideInterface()
    {
        gameObject.SetActive(false);
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
