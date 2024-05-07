using System;

public class EndStateGame
{
    private readonly Menu _menu;
    private readonly EndGameScreen _endScreen;
    private readonly PlayerMoverPresenter _presenterMover;
    private readonly PlayerPresenter _presenter;
    private readonly PlayerResurrect _playerResurrect;
    private readonly HudWindow _hudWindow;
    private readonly YandexLeaderboard _yandexLeaderboard;

    public EndStateGame(Menu menu, PlayerPresenter presenter, PlayerMoverPresenter presenterMover, PlayerResurrect playerResurrect, EndGameScreen endScreen, HudWindow hudWindow, YandexLeaderboard yandex)
    {
        _menu = menu;
        _presenterMover = presenterMover;
        _presenter = presenter;
        _playerResurrect = playerResurrect;
        _endScreen = endScreen;
        _hudWindow = hudWindow;
        _yandexLeaderboard = yandex;
    }

    public event Action OnEndGame;

    public void Enable()
    {
        _presenter.OnEndGame += End;
        _playerResurrect.OnRestart += OpenWindows;
    }

    public void Disable()
    {
        _presenter.OnEndGame -= End;
        _playerResurrect.OnRestart -= OpenWindows;
    }

    private void End()
    {
        AudioManager.Instance.Pause("Music");

        _presenterMover.EndPlayerMove();
        _playerResurrect.StartTimer();
        _endScreen.SetData(_presenter.TakeTotalDistance());
        _menu.SetDistance(_presenter.TakeTotalDistance());
        _yandexLeaderboard.SetPlayerScore(Convert.ToInt32(_presenter.TakeTotalDistance()));
    }

    private void OpenWindows()
    {
        AudioManager.Instance.Play("GameOver");
        AudioManager.Instance.Stop("Music");

        _menu.GetComponent<MenuWindow>().OpenWithoutSound();
        _endScreen.GetComponent<EndScreenWindow>().OpenWithoutSound();
        _hudWindow.CloseWithoutSound();

        OnEndGame?.Invoke();
    }
}
