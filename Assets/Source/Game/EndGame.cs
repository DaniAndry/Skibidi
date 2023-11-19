using System;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _money;

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

    public void SetData(int money, float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
        _money.text = $"{money}";
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
