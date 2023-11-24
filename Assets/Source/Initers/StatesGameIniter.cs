using UnityEngine;

public class StatesGameIniter : MonoBehaviour
{
    [SerializeField] private PlayerMoverPresenter _playerMoverPresenter;
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private Menu _menu;

    private StartStateGame _startStateGame;
    private EndStateGame _endStateGame;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _startStateGame.Enable();
        _endStateGame.Enable();
    }

    private void OnDisable()
    {
        _startStateGame.Disable();
        _endStateGame.Disable();
    }

    private void Init()
    {
        _startStateGame = new StartStateGame(_menu, _playerPresenter,_playerMoverPresenter);
        _endStateGame = new EndStateGame(_menu, _playerPresenter, _playerMoverPresenter);
    }
}
