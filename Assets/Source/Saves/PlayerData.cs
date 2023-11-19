[System.Serializable]
public class PlayerData
{
    public int Money;
    public float Energy;
    public float TotalDistance;

    public PlayerData(PlayerModel player)
    {
        Money = player.Money;
        Energy = player.MaxEnergy;
        TotalDistance = player.TotalDistanceTraveled;
    }
}
