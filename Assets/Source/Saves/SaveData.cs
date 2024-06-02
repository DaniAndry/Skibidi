public class SaveData
{
    public PlayerData PlayerData { get; private set; }
    public BankData BankData { get; private set; }
    public ShopData ShopData { get; private set; }
    public UpgradeData UpgradeData { get; private set; }

    public SaveData(PlayerData playerData, BankData bankData, ShopData shopData, UpgradeData upgradeData)
    {
        PlayerData = playerData;
        BankData = bankData;
        ShopData = shopData;
        UpgradeData = upgradeData;
    }
}