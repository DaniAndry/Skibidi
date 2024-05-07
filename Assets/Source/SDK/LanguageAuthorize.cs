using Agava.YandexGames;
using UnityEngine;

public class LanguageAuthorize : MonoBehaviour
{
    public void Start()
    {
        if (YandexGamesSdk.Environment.i18n.lang == "ru")
        {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
        }
        else if (YandexGamesSdk.Environment.i18n.lang == "en")
        {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
        }
        else if(YandexGamesSdk.Environment.i18n.lang == "tr")
        {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Turkish");
        }
        else
        {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
        }
    }
}
