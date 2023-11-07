using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem 
{
    public static void SavePlayer(PlayerModel player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

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
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/upgradeEnergy.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        UpgradeData data = new UpgradeData(energyUpgrade);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UpgradeData LoadEnergyUpgrade()
    {
        string path = Application.persistentDataPath + "/upgradeEnergy.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UpgradeData data = formatter.Deserialize(stream) as UpgradeData;
            stream.Close();

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
    }
}
