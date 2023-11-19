using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private TMP_Text _currentDistanceText;
    [SerializeField] private TMP_Text _recordDistanceText;
    [SerializeField] private TMP_Text _money;

    private float _recordDistance;

    public event Action ClickingStart;
    public event Action ClickingSettings;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnClickStart);
        _settingsButton.onClick.AddListener(OnClickSettings);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnClickStart);
        _settingsButton.onClick.RemoveListener(OnClickSettings);
    }

    public void CloseMenu()
    {
        GetComponent<MenuWindow>().Close();
    }

    public void OpenMenu()
    {
        GetComponent<MenuWindow>().Open();
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
