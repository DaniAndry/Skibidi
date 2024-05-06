public class DailyTaskSpawner : TaskSpawner
{
    private void OnEnable()
    {
        TaskInspector.OnGoneDailyTime += RefreshTasks;
    }

    private void OnDisable()
    {
        TaskInspector.OnGoneDailyTime -= RefreshTasks;    
    }

    public override void SpawnTasks()
    {
        base.SpawnTasks();

        for (int i = 0; i < 3; i++)
        {
            TurnOnTasks();
        }
    }
}
