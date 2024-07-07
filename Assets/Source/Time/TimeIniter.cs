using UnityEngine;

public class TimeIniter : MonoBehaviour
{
    [SerializeField] private TaskTimeInspector _taskInspector;

    private void Awake()
    {
        _taskInspector.Load();
        _taskInspector.RefreshTime();
    }
}
