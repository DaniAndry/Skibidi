using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Canvas _exitScreen;

    public event Action ClickingExitMenu;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnClickExitMenu);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnClickExitMenu);
    }

    private void OnClickExitMenu()
    {
        ClickingExitMenu?.Invoke();
    }

    public void SetDate(int money, float distance)
    {
        _distance.text = $"{distance}";
        _money.text = $"{money}";
    }

    public void OpenEndScreen()
    {
        _exitScreen.enabled = true;
    }

    public void CloseEndScreen()
    {
        _exitScreen.enabled = false;
    }
}
