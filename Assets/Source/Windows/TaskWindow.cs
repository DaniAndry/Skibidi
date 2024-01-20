using UnityEngine;
using UnityEngine.UI;

public class TaskWindow : Window
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _openDailyList;
    [SerializeField] private Button _openWeeklyList;
    [SerializeField] private Image DailyTaskList;
    [SerializeField] private Image WeeklyTaskList;

    private void Awake()
    {
        CloseWithoutSound();
        OpenDailyList();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
        _openDailyList.onClick.AddListener(OpenDailyList);
        _openWeeklyList.onClick.AddListener(OpenWeeklyList);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
        _openDailyList.onClick.RemoveListener(OpenDailyList);
        _openWeeklyList.onClick.RemoveListener(OpenWeeklyList);
    }

    private void OpenDailyList()
    {
        DailyTaskList.gameObject.SetActive(true);
        WeeklyTaskList.gameObject.SetActive(false);
    }

    private void OpenWeeklyList()
    {
        DailyTaskList.gameObject.SetActive(false);
        WeeklyTaskList.gameObject.SetActive(true);
    }
}
