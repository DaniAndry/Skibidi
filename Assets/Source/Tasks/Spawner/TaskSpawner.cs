using System.Collections.Generic;
using UnityEngine;

public abstract class TaskSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabTask;
    [SerializeField] private Transform _contentTasks;
    [SerializeField] private List<Task> _tasks = new List<Task>();
    [SerializeField] private TaskTimeInspector _timeInspector;

    private Queue<TaskView> _prefabTaskViews = new Queue<TaskView>();
    private List<TaskView> _activeTasks = new List<TaskView>();

    public TaskTimeInspector TaskInspector => _timeInspector;

    private void Awake()
    {
        TaskCounter.Init();
        RefreshTasks();
    }

    private void OnDisable()
    {
        foreach (var task in _prefabTaskViews)
        {
            task.OnComplete -= DestroyTask;
        }
    }

    public virtual void SpawnTasks()
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            GameObject gameObject = Instantiate(_prefabTask, _contentTasks, false);
            TaskView taskView = gameObject.GetComponent<TaskView>();
            taskView.transform.SetParent(_contentTasks);
            taskView.GetTask(_tasks[i]);
            taskView.Init();

            taskView.gameObject.SetActive(false);
            _prefabTaskViews.Enqueue(taskView);
        }

        foreach (var task in _prefabTaskViews)
        {
            task.OnComplete += DestroyTask;
        }
    }

    protected void TurnOnTasks()
    {
        if(_prefabTaskViews.Count > 0)
        {
            TaskView task = _prefabTaskViews.Peek();
            task.gameObject.SetActive(true);
            _activeTasks.Add(task);
            _prefabTaskViews.Dequeue();
        }
    }

    protected void RefreshTasks()
    {
        _prefabTaskViews.Clear();
         
        foreach(var task in _activeTasks)
        {
            Destroy(task.gameObject);
        }

        _activeTasks.Clear();

        SpawnTasks();
    }

    private void DestroyTask(TaskView taskView)
    {
        foreach (var task in _activeTasks)
        {
            if (taskView == task)
            {
                _activeTasks.Remove(task);
                TurnOnTasks();
                break;
            }
        }
    }
}
