using UnityEngine;

public class VideoAdView : MonoBehaviour
{
    public void Show(System.Action reward) => Agava.YandexGames.VideoAd.Show(OnOpenCallback, reward, OnCloseCallback);

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
