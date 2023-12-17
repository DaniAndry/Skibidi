using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dance : MonoBehaviour
{
    [SerializeField] private string _nameDanceAnim;
    [SerializeField] private int _price;
    [SerializeField] private Image _buyFlag;
    [SerializeField] private bool _isSelected;

    private Button _button;

    public bool IsSelected => _isSelected;
    public int Price => _price;
    public string NameDanceAnim => _nameDanceAnim;
    public bool IsBought { get; private set; } = false;

    public event Action<Dance> OnSelected;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buyFlag.gameObject.SetActive(IsBought);
        _button.onClick.AddListener(Select);
    }

    public void Select()
    {
        OnSelected?.Invoke(this);
    }

    public void Unlock()
    {
        IsBought = true;
        _buyFlag.gameObject.SetActive(IsBought);
    }

    public void ChangeStatus()
    {
        _isSelected = !_isSelected;
    }
}
