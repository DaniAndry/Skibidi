using UnityEngine;
using System.IO;

public class SaveSystem
{
    public static void SavePlayer(PlayerModel player)
    {
        PlayerData data = new PlayerData(player);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/player.json", json);

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.dataPath + "/player.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            Debug.Log("Save file not found in" + path);
            return null;
        }
    }

    public static void SaveEnergyUpgrade(EnergyUpgrade energyUpgrade)
    {
        UpgradeData data = new UpgradeData(energyUpgrade);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/EnergyUpgrade", json);
    }

    public static UpgradeData LoadEnergyUpgrade()
    {
        string path = Application.dataPath + "/EnergyUpgrade.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UpgradeData data = JsonUtility.FromJson<UpgradeData>(json);
            return data;
        }
        else
        {
            Debug.Log("Save file not found in" + path);
            return null;
        }
    }

    public static void SaveShop(ShopData shopData)
    {
        string json = JsonUtility.ToJson(shopData);
        File.WriteAllText(Application.dataPath + "/shop.json", json);
    }

    public static ShopData LoadShop()
    {
        string path = Application.dataPath + "/shop.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ShopData data = JsonUtility.FromJson<ShopData>(json);
            return data;
        }
        else
        {
            Debug.Log("Save file not found in" + path);
            return null;
        }
    }

    public static void DeleteUpgradeSaveData()
    {
        string path = Application.persistentDataPath + "/upgradeEnergy.json";
        File.Delete(path);
    }

    public static void DeletePlayerSaveData()
    {
        string path = Application.persistentDataPath + "/player.json";
        File.Delete(path);

        path = Application.persistentDataPath + "/shop.json";
        File.Delete(path);
    }
}
