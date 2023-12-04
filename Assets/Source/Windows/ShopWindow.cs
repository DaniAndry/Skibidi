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
        base.Close();
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
        AudioManager.Instance.Play("Click");
        base.Open();

        _canvasCamera.gameObject.SetActive(true);
        _mainMenu.Close();
    }

    public override void Close()
    {
        AudioManager.Instance.Play("Click");
        base.Close();

        _canvasCamera.gameObject.SetActive(false);
        _mainMenu.Open();
    }
}
