using TMPro;
using UnityEngine;

public class EnergyUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentPrice;
    [SerializeField] private Bank _bank;

    private int _maxCountEnergy = 50;
    private int _encreaceEnergy = 10;
    private int _encreaceMoney = 5;

    public int CurrentPrice { get; private set; } = 10;
    public float CurrentEnergy { get; private set; } = 0;

    private void Awake()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _currentPrice.text = CurrentPrice.ToString();
    }

    public float Upgrade()
    {
        if (_bank.TryTakeValue(CurrentPrice))
        {
            _bank.TakeMoney(CurrentPrice);
            CurrentPrice += _encreaceMoney;
            UpdateUI();

            if (CurrentEnergy < _maxCountEnergy)
            {
                CurrentEnergy += _encreaceEnergy;
                return CurrentEnergy;
            }
            else
            {
                CurrentEnergy = _maxCountEnergy;
                return CurrentEnergy;
            } 
        }
        else
        {
            return 0;
        }
    }
}
