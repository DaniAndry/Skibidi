using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dance : MonoBehaviour
{
    [SerializeField] private string _nameDanceAnim;
    [SerializeField] private string _nameDance;
    [SerializeField] private int _price;
    [SerializeField] private Image _buyFlag;
    [SerializeField] private Image _selectFlag;
    [SerializeField] private bool _isSelected;
    [SerializeField] private TMP_Text _priceText;

    private Button _button;

    public string NameDance => _nameDance;
    public bool IsSelected => _isSelected;
    public int Price => _price;
    public string NameDanceAnim => _nameDanceAnim;
    public bool IsBought { get; private set; } = false;

    public event Action<Dance> OnSelected;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buyFlag.gameObject.SetActive(IsBought);
        _selectFlag.gameObject.SetActive(IsSelected);
        _button.onClick.AddListener(Select);
        _priceText.text = $"{_price}";
    }

    public void Select()
    {
        OnSelected?.Invoke(this);
    }

    public void Unlock()
    {
        IsBought = true;
        _buyFlag.gameObject.SetActive(IsBought);
        _priceText.text = $"Bought";
    }

    public void ChangeStatus()
    {
        _isSelected = !_isSelected;
        _selectFlag.gameObject.SetActive(IsSelected);
    }
}
