using UnityEngine;
using UnityEngine.UI;

public class ShopSkinsWindow : Window
{
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
    }

    public override void Close()
    {
        AudioManager.Instance.Play("Click");
        base.Close();
    }
}
