using System;
using TMPro;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private float _bonus;

    private float _time = 5;
    private int _countBoosts;
    private int _countUpgrade = 0;
    private int _maxCountUpgrade = 5;
    private int _timeIncreaseNumber = 5;

    public int CountUpgrade => _countUpgrade;
    public int Count => _countBoosts;
    public float Bonus => _bonus;
    public float Time => _time;

    public event Action OnUpdateCount;

    private void Decrease()
    {
        _countBoosts--;
        UpdateText();
    }

    private void UpdateText()
    {
        OnUpdateCount?.Invoke();
    }

    public bool TryUse()
    {
        bool _canUse = _countBoosts > 0;

        if (_canUse)
        {
            Decrease();
            AudioManager.Instance.Play("UseBoost");
        }

        return _canUse;
    }

    public void Increase()
    {
        _countBoosts++;
        UpdateText();
    }

    public void Upgrade()
    {
        if (_countUpgrade < _maxCountUpgrade)
        {
            _countUpgrade++;
            _time += _timeIncreaseNumber;
            AudioManager.Instance.Play("UpgradeBoost");
        }
    }

    public void SavaData()
    { }

    public void LoadData()
    { }
}
