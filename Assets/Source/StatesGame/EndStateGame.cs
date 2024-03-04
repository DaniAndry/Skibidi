public class EndStateGame
{
    private Menu _menu;
    private PlayerMoverPresenter _presenterMover;
    private PlayerPresenter _presenter;

    public EndStateGame(Menu menu, PlayerPresenter presenter, PlayerMoverPresenter presenterMover)
    {
        _menu = menu;
        _presenterMover = presenterMover;
        _presenter = presenter;
    }

    public void Enable()
    {
        _presenter.OnEndGame += End;
    }

    public void Disable()
    {
        _presenter.OnEndGame -= End;
    }

    private void End()
    {
        _presenterMover.EndGame();
    }
}
