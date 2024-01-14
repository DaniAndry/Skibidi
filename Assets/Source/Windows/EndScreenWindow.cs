using UnityEngine;

public class EndScreenWindow : Window
{
    [SerializeField] private Camera _endScreenCanvasCamera;

    private void Awake()
    {
        Close();
    }

    public override void Open()
    {
        OpenWithoutSound();

        _endScreenCanvasCamera.gameObject.SetActive(true);
    }

    public override void Close()
    {
        CloseWithoutSound();

        _endScreenCanvasCamera.gameObject.SetActive(false);
    }
}
