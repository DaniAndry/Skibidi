public class DistanceTaskSpawner : TaskSpawner
{
    public override void SpawnTasks()
    {
        base.SpawnTasks();

        for (int i = 0; i < 10; i++)
        {
            TurnOnTasks();
        }
    }
}
