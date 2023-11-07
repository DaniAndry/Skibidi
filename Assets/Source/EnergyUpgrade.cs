using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentPrice;
    [SerializeField] private TMP_Text _currentEnergy;

    private Button _button;
    private readonly int _additionPrice = 10;
    private readonly float _additionEnergy = 20;

    public event Action ClickingUpgrade;

    public int Price { get; private set; } = 10;
    public float AmountEnergy { get; private set; } = 50;

    private void Awake()
    {
        _button = GetComponent<Button>();
        LoadEnergyUpgrade();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickUpdate);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickUpdate);
    }

    public void Upgrade()
    {
        Price += _additionPrice;
        AmountEnergy += _additionEnergy;

        _currentEnergy.text = $"+{_additionEnergy}";
        _currentPrice.text = $"{Price}";

        SaveEnergyUpgrade();
    }

    public void ErrorUpgrade()
    {
        _currentPrice.color = Color.Lerp(Color.yellow, Color.red, 0.5f);
    }

    private void OnClickUpdate()
    {
        ClickingUpgrade?.Invoke();
    }

    private void SaveEnergyUpgrade()
    {
        SaveSystem.SaveEnergyUpgrade(this);
    }

    private void LoadEnergyUpgrade()
    {
        UpgradeData data = SaveSystem.LoadEnergyUpgrade();

        if (data != null)
        {
            AmountEnergy = data.AmountEnergy;
            Price = data.Price;

        }
            _currentEnergy.text = $"+{_additionEnergy}";
            _currentPrice.text = $"{Price}";
    }
}
