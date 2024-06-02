[System.Serializable]
public class UpgradeData
{
    public int CountUpgrade { get; private set; }

    public UpgradeData(EnergyUpgrade energyUpgrade)
    {
        CountUpgrade = energyUpgrade.MaxCountEnergy;
    }
}
