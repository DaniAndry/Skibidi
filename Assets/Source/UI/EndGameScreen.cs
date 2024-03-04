using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _distance;

    public event Action OnRestartGame;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(CloseEndScreen);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(CloseEndScreen);
    }

    public void SetData(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void OpenEndScreen()
    {
        GetComponent<EndScreenWindow>().Open();
        OnRestartGame?.Invoke();
    }

    public void CloseEndScreen()
    {
        GetComponent<EndScreenWindow>().Close();
    }
}
