using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _money;

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

    public void SetData(int money, float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
        _money.text = $"{money}";
    }

    public void OpenEndScreen()
    {
        gameObject.SetActive(true);
    }

    public void CloseEndScreen()
    {
        gameObject.SetActive(false);
    }
}
