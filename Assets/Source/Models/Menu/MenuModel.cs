using System;
using UnityEngine;

public class MenuModel
{
    public event Action StartedGame;

    public void StartGame()
    {
        StartedGame?.Invoke();
    }
}
