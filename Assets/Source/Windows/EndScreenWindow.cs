using UnityEngine;

public class EndScreenWindow : Window
{
    private void Awake()
    {
        Close();
    }

    public override void Open()
    {
        OpenWithoutSound();
    }

    public override void Close()
    {
        CloseWithoutSound();
    }
}
