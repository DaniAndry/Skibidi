public class RestartStateGame
{
    private PlayerPresenter _playerPresenter;
    private PlayerMoverPresenter _playerMoverPresenter;
    private ChunksPlacer _chunksPlacer;
    private ChunksPlacer _backgroundChunksPlacer;
    private EndGameScreen _endGameScreen;

    public RestartStateGame(PlayerPresenter playerPresenter, PlayerMoverPresenter playerMoverPresenter, ChunksPlacer chunksPlacer, ChunksPlacer backgroundChunksPlacer, EndGameScreen endGameScreen)
    {
        _playerPresenter = playerPresenter;
        _playerMoverPresenter = playerMoverPresenter;
        _chunksPlacer = chunksPlacer;
        _backgroundChunksPlacer = backgroundChunksPlacer;
        _endGameScreen = endGameScreen;
    }

    public void Enable()
    {
        _endGameScreen.OnRestartGame += ResetGame;
    }

    public void Disable()
    {
        _endGameScreen.OnRestartGame -= ResetGame;
    }

    public void ResetGame()
    {
        _chunksPlacer.ResetFirstChunk();
        _backgroundChunksPlacer.ResetFirstChunk();
        _playerMoverPresenter.ResetPlayerMove();
        _playerPresenter.ResetPlayer();
    }
}
