using System;
using UnityEngine;

public class MenuModel : MonoBehaviour
{
    public event Action StartedGame;

    public void StartGame()
    {
        StartedGame?.Invoke();
    }
}
