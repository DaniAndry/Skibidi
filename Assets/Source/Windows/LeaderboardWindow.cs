using UnityEngine;
using UnityEngine.UI;

public class LeaderboardWindow : Window
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private YandexLeaderboard _yandexleaderboard;
    private LeaderboardInitializer _initializer;

    private void Awake()
    {
        CloseWithoutSound();
        _initializer = GetComponent<LeaderboardInitializer>();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
    }

    public override void Open()
    {
        base.Open();
        _initializer.OpenLeaderboard();
        _yandexleaderboard.Fill();
    } 
}
