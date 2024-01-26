using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabTask;
    [SerializeField] private Transform _contentDailyTask;
    [SerializeField] private Transform _contentWeeklyTask;
    [SerializeField] private List<Task> _dailyTasks = new List<Task>();
    [SerializeField] private List<Task> _weeklyTasks = new List<Task>();

    private Queue<TaskView> _prefabDailyTaskViews = new Queue<TaskView>();
    private Queue<TaskView> _prefabWeeklyTaskViews = new Queue<TaskView>();
    private List<TaskView> _activeDailyTasks = new List<TaskView>();
    private List<TaskView> _activeWeeklyTasks = new List<TaskView>();

    private void Awake()
    {
        SpawnTasks();
        TaskCounter.Init();
    }

    private void OnDisable()
    {
        foreach (var task in _prefabDailyTaskViews)
        {
            task.OnComplete -= DestroyTask;
        }
    }

    private void SpawnTasks()
    {
        SpawnDailyTasks();
        SpawnWeeklyTasks();

        for (int i = 0; i < 2; i++)
        {
            TurnOnDailyTask();
            TurnOnWeeklyTask();
        }
    }

    private void SpawnDailyTasks()
    {
        for (int i = 0; i < _dailyTasks.Count; i++)
        {
            GameObject gameObject = Instantiate(_prefabTask, _contentDailyTask, false);
            TaskView taskView = gameObject.GetComponent<TaskView>();
            taskView.transform.SetParent(_contentDailyTask);
            taskView.GetTask(_dailyTasks[i]);
            taskView.Init();

            taskView.gameObject.SetActive(false);
            _prefabDailyTaskViews.Enqueue(taskView);
        }

        foreach (var task in _prefabDailyTaskViews)
        {
            task.OnComplete += DestroyTask;
        }
    }

    private void SpawnWeeklyTasks()
    {
        for (int i = 0; i < _weeklyTasks.Count; i++)
        {
            GameObject gameObject = Instantiate(_prefabTask, _contentWeeklyTask, false);
            TaskView taskView = gameObject.GetComponent<TaskView>();
            taskView.transform.SetParent(_contentWeeklyTask);
            taskView.GetTask(_weeklyTasks[i]);
            taskView.Init();

            taskView.gameObject.SetActive(false);
            _prefabWeeklyTaskViews.Enqueue(taskView);
        }

        foreach (var task in _prefabWeeklyTaskViews)
        {
            task.OnComplete += DestroyTask;
        }
    }

    private void TurnOnDailyTask()
    {
        if (_prefabDailyTaskViews.Count > 0)
        {
            TaskView task = _prefabDailyTaskViews.Peek();
            task.gameObject.SetActive(true);
            _activeDailyTasks.Add(task);
            _prefabDailyTaskViews.Dequeue();
        }
    }

    private void TurnOnWeeklyTask()
    {
        if (_prefabWeeklyTaskViews.Count > 0)
        {
            TaskView task = _prefabWeeklyTaskViews.Peek();
            task.gameObject.SetActive(true);
            _activeWeeklyTasks.Add(task);
            _prefabWeeklyTaskViews.Dequeue();
        }
    }

    private void DestroyTask(TaskView taskView)
    {
        foreach (var task in _activeDailyTasks)
        {
            if (taskView == task)
            {
                _activeDailyTasks.Remove(task);
                TurnOnDailyTask();
                break;
            }
        }

        foreach(var task in _activeWeeklyTasks)
        {
            if (taskView == task)
            {
                _activeDailyTasks.Remove(task);
                TurnOnWeeklyTask();
                break;
            }
        }
    }
}
