using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResurrect : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;
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

    public event Action OnRestart;
    public event Action<float> OnResurrect;

    private void Awake()
    {
        _playerResurrectWindow = GetComponent<PlayerResurrectWindow>();
    }

    private void OnEnable()
    {
        _diamondContinue.onClick.AddListener(DiamondResurrect);
        _watchContinue.onClick.AddListener(WatchResurrect);
    }

    private void OnDisable()
    {
        _diamondContinue.onClick.RemoveListener(DiamondResurrect);
        _watchContinue.onClick.RemoveListener(WatchResurrect);
    }

    public void StartTimer()
    {
        _waitForWindow = StartCoroutine(WaitForWindow());
        _playerResurrectWindow.OpenWithoutSound();
    }

    private void DiamondResurrect()
    {
        if (_bank.TryTakeValue(_price))
        {
            _bank.TakeDiamond(_price);
            _price *= 2;
            Resurrect(_energyGiftForDiamond);
        }       
    }

    private void WatchResurrect()
    {
        Resurrect(_energyGiftForWatch);
    }

    private void Resurrect(float energy)
    {
        _isTimeRunning = false;
        _playerResurrectWindow.CloseWithoutSound();
        OnResurrect?.Invoke(energy);
    }

    private void EndTime()
    {
        _playerResurrectWindow.CloseWithoutSound();
        _price = 1;
        OnRestart?.Invoke();
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
