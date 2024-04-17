using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private GameObject _prefabSkin;
    [SerializeField] private int _price;
    [SerializeField] private Image _buyFlag;
    [SerializeField] private Image _SelectFlag;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _isSelected;
    [SerializeField] private TMP_Text _priceText;

    private Button _skinChangeButton;

    public string Description => _description;
    public string Name => _name;
    public bool IsSelected => _isSelected;
    public int Price => _price;
    public bool IsBought { get; private set; } = false;

    public event Action<Skin> OnSelected;

    private void Awake()
    {
        _skinChangeButton = GetComponent<Button>();
        _buyFlag.gameObject.SetActive(IsBought);
        _skinChangeButton.onClick.AddListener(ShowInfo);
        _priceText.text = $"{_price}";
    }

    public PlayerView GetView()
    {
        return _playerView;
    }

    public GameObject GetPrefab()
    {
        return _prefabSkin;
    }

    public void TurnOffSkin()
    {
        Debug.Log(_playerView);
        _playerView.gameObject.SetActive(false);
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

    private void TurnOnSkin()
    {
        _playerView.gameObject.SetActive(true);
    }
}
