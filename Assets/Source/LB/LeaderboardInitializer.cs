using Agava.YandexGames;
using UnityEngine;

public class LeaderboardInitializer : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if(PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if(PlayerAccount.IsAuthorized == false)
            return;
    }
}
