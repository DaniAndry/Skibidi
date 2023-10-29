using System;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    public event Action ClickButtonClose;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnClickCloseButton);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnClickCloseButton);
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }

    private void OnClickCloseButton()
    {
        ClickButtonClose?.Invoke();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
}
