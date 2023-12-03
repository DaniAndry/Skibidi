using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _currentDistanceText;
    [SerializeField] private TMP_Text _recordDistanceText;
    [SerializeField] private TMP_Text _money;

    private float _recordDistance;
    private MenuWindow _menuWindow;

    public event Action ClickingStart;

    private void Awake()
    {
        _menuWindow = GetComponent<MenuWindow>();
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnClickStart);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnClickStart);
    }

    private void Close()
    {
        _menuWindow.Close();
    }

    private void Open()
    {
        _menuWindow.Open();
    }

    private void OnClickStart()
    {
        ClickingStart?.Invoke();
        _menuWindow.Close();
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
