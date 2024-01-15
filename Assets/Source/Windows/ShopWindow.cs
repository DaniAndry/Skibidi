using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : Window
{
    [SerializeField] private MenuWindow _mainMenu;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        CloseWithoutSound();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
    }

    public override void Open()
    {
        base.Open();
        _mainMenu.CloseWithoutSound();
    }

    public override void Close()
    {
        base.Close();
        _mainMenu.OpenWithoutSound();
    }
}
