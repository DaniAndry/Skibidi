using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    public event Action ClickStart;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnClickStart);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnClickStart);
    }

    public void HideInterface()
    {
        gameObject.SetActive(false);
    }

    private void OnClickStart()
    {
        ClickStart?.Invoke();
    }
}
