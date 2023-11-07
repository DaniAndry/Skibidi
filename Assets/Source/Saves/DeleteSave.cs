using UnityEngine;

public class DeleteSave : MonoBehaviour
{
    public void DeleteAll()
    {
        SaveSystem.DeletePlayerSaveData();
        SaveSystem.DeleteUpgradeSaveData();
    }
}
