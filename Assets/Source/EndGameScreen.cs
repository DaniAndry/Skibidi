using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _distance;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnClickExitMenu);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnClickExitMenu);
    }

    private void OnClickExitMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetData(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void OpenEndScreen()
    {
        gameObject.SetActive(true);
    }

    public void CloseEndScreen()
    {
        gameObject.SetActive(false);
    }
}
