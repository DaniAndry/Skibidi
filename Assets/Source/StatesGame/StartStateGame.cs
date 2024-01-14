public class StartStateGame
{
    private Menu _menu;
    private PlayerPresenter _presenter;
    private PlayerMoverPresenter _presenterMover;

    public StartStateGame(Menu menu, PlayerPresenter presenter, PlayerMoverPresenter presenterMover)
    {
        _menu = menu;
        _presenter = presenter;
        _presenterMover = presenterMover;
    }

    public void Enable()
    {
        _menu.ClickingStart += Start;
    }

    public void Disable()
    {
        _menu.ClickingStart += Start;
    }

    private void Start()
    {
        AudioManager.Instance.Play("StartGame");
        AudioManager.Instance.Play("Music");

        _presenter.StartGame();
        _presenterMover.StartGame();
    }
}
