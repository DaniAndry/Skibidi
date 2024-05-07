using UnityEngine;

public class EndScreenWindow : Window
{
    [SerializeField] private GameObject _place;

    private void Awake()
    {
        Close();
    }

    public override void Open()
    {
        OpenWithoutSound();
        _place.SetActive(true);
    }

    public override void Close()
    {
        CloseWithoutSound();
        _place.SetActive(false);
    }
}
