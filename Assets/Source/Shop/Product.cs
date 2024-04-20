using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Product : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Image _buyFlag;
    [SerializeField] private Image _SelectFlag;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _isSelected;
    [SerializeField] private TMP_Text _priceText;

    private Button _showButton;

    public string Description => _description;
    public string Name => _name;
    public bool IsSelected => _isSelected;
    public int Price => _price;
    public bool IsBought { get; private set; } = false;

    public event Action<Product> OnSelected;

    private void Awake()
    {
        _showButton = GetComponent<Button>();
        _showButton.onClick.AddListener(ShowInfo);
        _buyFlag.gameObject.SetActive(IsBought);
        _priceText.text = $"{_price}";
    }

    private void OnDisable()
    {
        _showButton.onClick?.RemoveListener(ShowInfo);
    }

    public void Unlock()
    {
        IsBought = true;
        _buyFlag.gameObject.SetActive(IsBought);
        _priceText.text = $"Bought";
    }

    public void ShowInfo()
    {
        OnSelected?.Invoke(this);
    }

    public void ChangeStatus()
    {
        _isSelected = !_isSelected;
        _SelectFlag.gameObject.SetActive(_isSelected);
    }
}
