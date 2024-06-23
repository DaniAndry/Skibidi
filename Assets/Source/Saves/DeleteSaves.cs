using UnityEngine;
using YG;

public class DeleteSaves : MonoBehaviour
{
    public void Delete()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
    }
}
