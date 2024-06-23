using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private Button _rewardButton;
    [SerializeField] private Bank _bank;

    private int _id = 5;

    private void Start()
    {
        RefreshAdButton();
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(CloseEndScreen);
        _rewardButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(CloseEndScreen);
        _rewardButton.onClick.RemoveListener(OnClick);
    }

    public void SetData(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void CloseEndScreen()
    {
        GetComponent<EndScreenWindow>().CloseWithoutSound();
        _bank.Reset();
        RefreshAdButton();
    }

    private void RefreshAdButton()
    {
        int chance = UnityEngine.Random.Range(0, 100);

        if (chance <= 10)
            _rewardButton.gameObject.SetActive(true);
        else
            _rewardButton.gameObject.SetActive(false);
    }

    private void OnClick()
    {
        YandexGame.RewVideoShow(_id);
        _rewardButton.gameObject.SetActive(false);
    }
}
