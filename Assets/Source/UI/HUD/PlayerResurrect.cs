using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PlayerResurrect : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _priceDiamondText;
    [SerializeField] private Button _diamondContinue;
    [SerializeField] private Button _watchContinue;
    [SerializeField] private Bank _bank;

    private Coroutine _waitForWindow;
    private int _price = 1;
    private int _time = 5;
    private bool _isTimeRunning = true;
    private WaitForSeconds _waitForWindowTime = new WaitForSeconds(1f);
    private PlayerResurrectWindow _playerResurrectWindow;
    private float _energyGiftForWatch = 200;
    private float _energyGiftForDiamond = 100;
    private int _id = 6;

    public event Action OnRestart;
    public event Action<float> OnResurrected;

    private void Awake()
    {
        _playerResurrectWindow = GetComponent<PlayerResurrectWindow>();
        _priceDiamondText.text = _price.ToString();
    }

    private void OnEnable()
    {
        _diamondContinue.onClick.AddListener(DiamondResurrect);
        _watchContinue.onClick.AddListener(OnResurrect);
    }

    private void OnDisable()
    {
        _diamondContinue.onClick.RemoveListener(DiamondResurrect);
        _watchContinue.onClick.RemoveListener(OnResurrect);
    }

    public void StartTimer()
    {
        AudioManager.Instance.Play("Clock");
        _waitForWindow = StartCoroutine(WaitForWindow());
        _playerResurrectWindow.OpenWithoutSound();
    }

    public void ResurrectWatch()
    {
        _price *= 2;
        _priceDiamondText.text = _price.ToString();
        Resurrect(_energyGiftForWatch);
    }

    private void OnResurrect()
    {
        YandexGame.RewVideoShow(_id);
    }

    private void DiamondResurrect()
    {
        if (_bank.TryTakeDiamond(_price))
        {
            _bank.TakeDiamond(_price);
            _price *= 2;
            _priceDiamondText.text = _price.ToString();
            Resurrect(_energyGiftForDiamond);
        }       
    }

    private void Resurrect(float energy)
    {
        AudioManager.Instance.Play("Ressurect");
        AudioManager.Instance.UnPause("Music");

        _isTimeRunning = false;
        _playerResurrectWindow.CloseWithoutSound();
        OnResurrected?.Invoke(energy);
    }

    private void EndTime()
    {
        AudioManager.Instance.Stop("Clock");
        _playerResurrectWindow.CloseWithoutSound();
        _price = 1;
        _priceDiamondText.text = _price.ToString();
        OnRestart?.Invoke();
        YandexGame.FullscreenShow();
    }

    private IEnumerator WaitForWindow()
    {
        _isTimeRunning = true;
        int time = _time;

        while (time > 0 && _isTimeRunning)
        {
            time--;
            _timer.text = $"{time}";

            if (time <= 0)
            {
                EndTime();
                StopCoroutine(_waitForWindow);
            }

            yield return _waitForWindowTime;
        }

        if(_isTimeRunning == false)
            StopCoroutine(_waitForWindow);
    }
}
