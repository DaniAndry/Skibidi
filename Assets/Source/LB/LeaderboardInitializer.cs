using Agava.YandexGames;
using UnityEngine;

public class LeaderboardInitializer : MonoBehaviour
{

    private void openLeaderboard()
    {
        PlayerAccount.Authorize();

        if(PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if(PlayerAccount.IsAuthorized == false)
            return;
    }
}
