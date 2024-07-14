using UnityEngine;
using UnityEngine.UI;
using YG;

public class LeaderboardWindow : Window
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        CloseWithoutSound();
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
        if (YandexGame.auth == false)
        {
            YandexGame.AuthDialog();
            Close();
        }
        else
        {
            base.Open();
        }
    }
}
