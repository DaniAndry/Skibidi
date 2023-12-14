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
        base.Open();

        _endScreenCanvasCamera.gameObject.SetActive(true);
    }
    public override void Close()
    {
        base.Close();

        _endScreenCanvasCamera.gameObject.SetActive(false);
    }
}
