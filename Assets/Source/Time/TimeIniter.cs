using UnityEngine;

public class TimeIniter : MonoBehaviour
{
    [SerializeField] private TaskTimeInspector _taskInspector;

    private void Start()
    {
        _taskInspector.Load();
        _taskInspector.RefreshTime();
    }
}
