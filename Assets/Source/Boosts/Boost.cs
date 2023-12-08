using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField] private float _bonus;
    [SerializeField] private float _time;

    private int _countBoosts;
    private int _countUpgrade = 0;
    private int _maxCountUpgrade = 5;
    private int _timeIncreaseNumber = 5;

    public int CountUpgrade => _countUpgrade;
    public int Count => _countBoosts;
    public float Bonus => _bonus;
    public float Time => _time;

    private void Decrease()
    {
        _countBoosts--;
    }

    public bool TryUse()
    {
        bool _canUse = _countBoosts > 0;

        if (_canUse)
            Decrease();

        return _canUse;
    }

    public void Increase()
    {
        _countBoosts++;
    }

    public void Upgrade()
    {
        if(_countUpgrade < _maxCountUpgrade)
        {
            _countUpgrade++;
            _time += _timeIncreaseNumber;
        }
    }

    public void SavaData()
    {

    }

    public void LoadData()
    {

    }
}
