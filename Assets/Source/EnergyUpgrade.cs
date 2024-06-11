using TMPro;
using UnityEngine;

public class EnergyUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentPrice;
    [SerializeField] private Bank _bank;

    private int _encreaceEnergy = 10;
    private int _encreaceMoney = 5;

    private UpgradeData _data;

    public int CurrentPrice { get; private set; } = 10;
    public int MaxCountEnergy { get; private set; }
    public float CurrentEnergy { get; private set; } = 0;

    private void Awake()
    {
        UpdateUI();
    }

    private void Start()
    {
        if(SaveSystem.LoadEnergyUpgrade() != null)
        {
            _data = SaveSystem.LoadEnergyUpgrade();
            MaxCountEnergy = _data.CountUpgrade;
        }
    }

    private void UpdateUI()
    {
        _currentPrice.text = CurrentPrice.ToString();
    }

    public float Upgrade()
    {
        if (_bank.TryTakeMoney(CurrentPrice))
        {
            _bank.TakeMoney(CurrentPrice);
            CurrentPrice += _encreaceMoney;
            UpdateUI();

            SaveSystem.SaveEnergyUpgrade(this);

            TaskCounter.IncereaseProgress(1, TaskType.UpgradeEnergy.ToString());

            if (CurrentEnergy < MaxCountEnergy)
            {
                CurrentEnergy += _encreaceEnergy;
                return CurrentEnergy;
            }
            else
            {
                CurrentEnergy = MaxCountEnergy;
                return CurrentEnergy;
            }

        }
        else
        {
            return 0;
        }
    }
}
