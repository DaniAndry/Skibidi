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
    private int _countUpgrades = 1;

    public event Action ClickingUpgrade;

    public int Price { get; private set; } = 10;
    public float AmountEnergy { get; private set; } = 50;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickUpdate);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickUpdate);
    }

    /* public void LoadSave()
     {
         _countUpgrades = PlayerPrefs.GetInt("asd");

         _amountEnergy += _additionEnergy * _countUpgrades;
         Price += _additionPrice * _countUpgrades;

         _currentEnergy.text = $"+{_additionEnergy}";
         _currentPrice.text = $"{Price}";
     }*/

    public void Upgrade()
    {
        _countUpgrades++;
        Price += _additionPrice;
        AmountEnergy += _additionEnergy;

        _currentEnergy.text = $"+{_additionEnergy}";
        _currentPrice.text = $"{Price}";
    }

    public void ErrorUpgrade()
    {
        _currentPrice.color = Color.Lerp(Color.yellow, Color.red, 0.5f);
    }

    private void OnClickUpdate()
    {
        ClickingUpgrade?.Invoke();
    }
}
