using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : Window
{
    [SerializeField] private Camera _canvasCamera;
    [SerializeField] private MenuWindow _mainMenu;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        CloseWithoutSound();
        _canvasCamera.gameObject.SetActive(false);
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

        _canvasCamera.gameObject.SetActive(true);
        _mainMenu.CloseWithoutSound();
    }

    public override void Close()
    {
        base.Close();

        _canvasCamera.gameObject.SetActive(false);
        _mainMenu.OpenWithoutSound();
    }
}
