using UnityEngine;
using Agava.YandexGames;

public class SaveSystem : MonoBehaviour
{
    private const string PlayerDataKey = "playerData";
    private const string EnergyUpgradeDataKey = "energyUpgradeData";
    private const string ShopDataKey = "shopData";
    private const string BankDataKey = "bankData";

    static SaveData _saveData;

    private void Start()
    {
        LoadData();
    }

    public static void SavePlayer(PlayerModel player)
    {
        PlayerData data = new PlayerData(player);

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(PlayerDataKey, json);
        SaveData();
    }

    public static void SaveBank(Bank bank)
    {
        BankData data = new BankData(bank);

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(BankDataKey, json);
        SaveData();
    }

    public static void SaveEnergyUpgrade(EnergyUpgrade energyUpgrade)
    {
        UpgradeData data = new UpgradeData(energyUpgrade);
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(EnergyUpgradeDataKey, json);
        SaveData();
    }

    public static void SaveShop(ShopData shopData)
    {
        string json = JsonUtility.ToJson(shopData);
        PlayerPrefs.SetString(ShopDataKey, json);
        SaveData();
    }

    private static void SaveData()
    {
        string playerData = PlayerPrefs.GetString(PlayerDataKey);
        string energyData = PlayerPrefs.GetString(EnergyUpgradeDataKey);
        string bankData = PlayerPrefs.GetString(BankDataKey);
        string shopData = PlayerPrefs.GetString(PlayerDataKey);

        PlayerData playerDataSaved = JsonUtility.FromJson<PlayerData>(playerData);
        ShopData shopDataSaved = JsonUtility.FromJson<ShopData>(shopData);
        UpgradeData upgradeDataSaved = JsonUtility.FromJson<UpgradeData>(energyData);
        BankData bankDataSaved = JsonUtility.FromJson<BankData>(bankData);

        SaveData saveData = new SaveData(playerDataSaved, bankDataSaved, shopDataSaved, upgradeDataSaved);
        string json = JsonUtility.ToJson(saveData);

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.SetCloudSaveData(json);
        }
        else
        {
            Debug.LogError("Player is not authorized, cannot save data!");
        }
    }

    public static void LoadData()
    {
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.GetCloudSaveData(OnGetDataSuccess, OnGetCloudSaveDataError);
        }
        else
        {
            Debug.LogError("Player is not authorized, cannot load data!");
        }
    }

    private static void OnGetDataSuccess(string jsonData)
    {
        if (string.IsNullOrEmpty(jsonData))
        {
            Debug.Log("No player data found in cloud storage.");
            return;
        }

        SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);
        _saveData = saveData;
        Debug.Log(_saveData);

        Debug.Log("Data loaded successfully from cloud.");
    }
    private static void OnGetCloudSaveDataError(string error)
    {
        Debug.Log("Error loaded from cloud");
    }


    public static BankData LoadBank()
    {
        return _saveData.BankData;
    }

    public static PlayerData LoadPlayer()
    {
        return _saveData.PlayerData;
    }

    public static UpgradeData LoadEnergyUpgrade()
    {
        return _saveData.UpgradeData;
    }

    public static ShopData LoadShop()
    {
        return _saveData.ShopData;
    }
}
