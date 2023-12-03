[System.Serializable]
public class PlayerData
{
    public float Energy;
    public float TotalDistance;

    public PlayerData(PlayerModel player)
    {
        Energy = player.MaxEnergy;
        TotalDistance = player.TotalDistanceTraveled;
    }
}
