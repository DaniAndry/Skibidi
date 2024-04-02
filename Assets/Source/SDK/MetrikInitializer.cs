using Agava.YandexGames;
using UnityEngine;

public class MetrikInitializer : MonoBehaviour
{
    private void Awake()
    {
        OnCallGameReadyButtonClick();
    }

    public void OnCallGameReadyButtonClick()
    {
        YandexGamesSdk.GameReady();
    }
}
