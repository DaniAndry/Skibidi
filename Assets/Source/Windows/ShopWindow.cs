using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : Window
{
    [SerializeField] private Button _openButton;

    private Button _closeButton;

    private void Awake()
    {
        _closeButton = GetComponentInChildren<CloseButton>().GetComponent<Button>();
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
