using UnityEngine;

public class StatesGameIniter : MonoBehaviour
{
    [SerializeField] private PlayerMoverPresenter _playerMoverPresenter;
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private Menu _menu;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private ChunksPlacer _chunksPlacer;
    [SerializeField] private ChunksPlacer _backgroundChunksPlacer;

    private RestartStateGame _restartStateGame;
    private StartStateGame _startStateGame;
    private EndStateGame _endStateGame;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _restartStateGame.Enable();
        _startStateGame.Enable();
        _endStateGame.Enable();
    }

    private void OnDisable()
    {
        _restartStateGame.Disable();
        _startStateGame.Disable();
        _endStateGame.Disable();
    }

    private void Init()
    {
        _restartStateGame = new RestartStateGame(_playerPresenter, _playerMoverPresenter, _chunksPlacer, _backgroundChunksPlacer, _endGameScreen);
        _startStateGame = new StartStateGame(_menu, _playerPresenter,_playerMoverPresenter);
        _endStateGame = new EndStateGame(_menu, _playerPresenter, _playerMoverPresenter);
    }
}
