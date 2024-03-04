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
    [SerializeField] private EndGameScreen _endGameScreen;

    private Coroutine _waitForWindow;
    private int _price = 1;
    private int _time = 5;
    private WaitForSeconds _waitForWindowTime = new WaitForSeconds(1f);
    private HudWindow _hudWindow;
    private PlayerResurrectWindow _playerResurrectWindow;
    private float _distance;
    private MenuWindow _menu;

    private void Awake()
    {
        _hudWindow = GetComponentInParent<HudWindow>();
        _menu = _endGameScreen.GetComponentInParent<MenuWindow>();
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

    public void StartTimer(float distance)
    {
        Debug.Log("startTimer");
        _waitForWindow = StartCoroutine(WaitForWindow());
        _playerResurrectWindow.OpenWithoutSound();
        _distance = distance;
    }

    private void DiamondResurrect()
    {
        if (_bank.TryTakeDiamond(_price))
        {
            _bank.GiveDiamond(_price);
            _price *= 2;
            Resurrect();
        }       
    }

    private void WatchResurrect()
    {
        Resurrect();
    }

    private void Resurrect()
    {
       
    }

    private void OpenEndScreen()
    {
        _hudWindow.CloseWithoutSound();
        _playerResurrectWindow.CloseWithoutSound();
        _menu.OpenWithoutSound();
        _endGameScreen.OpenEndScreen();
        _endGameScreen.SetData(_distance);
    }

    private IEnumerator WaitForWindow()
    {
        int time = _time;
        while (time > 0)
        {
            time--;
            _timer.text = $"{time}";

            if (time <= 0)
            {
                OpenEndScreen();
                StopCoroutine(_waitForWindow);
            }

            yield return _waitForWindowTime;
        }
    }
}
