using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Yandex
{
    public sealed class SDKInitializer : MonoBehaviour
    {
        private string _mainScene = "MainScene";

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(_mainScene);
            SaveSystem.LoadData();
        }
    }
}
