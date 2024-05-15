public class WeeklyTaskSpawner : TaskSpawner
{
    private void OnEnable()
    {
        TaskInspector.OnGoneWeeklyTime += RefreshTasks;
    }

    private void OnDisable()
    {
        TaskInspector.OnGoneWeeklyTime -= RefreshTasks;
    }

    public override void SpawnTasks()
    {
        base.SpawnTasks();

        for (int i = 0; i < 2; i++)
        {
            TurnOnTasks();
        }
    }
}
