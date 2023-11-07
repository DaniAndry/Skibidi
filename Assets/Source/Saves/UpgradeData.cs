[System.Serializable]
public class UpgradeData
{
    public int Price;
    public float AmountEnergy;

    public UpgradeData(EnergyUpgrade energyUpgrade)
    {
        Price = energyUpgrade.Price;
        AmountEnergy = energyUpgrade.AmountEnergy;
    }
}
