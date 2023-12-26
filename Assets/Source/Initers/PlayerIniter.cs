using UnityEngine;

public class PlayerIniter : MonoBehaviour
{
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private EndGameScreen _viewEndScreen;
    [SerializeField] private PlayerMoverPresenter _moverPresenter;
    [SerializeField] private PlayerPresenter _presenter;
    [SerializeField] private SkinSelecter _selecter;
    [SerializeField] private ChunksPlacer _chunksPlacer;
    [SerializeField] private ChunksPlacer _backChunksPlacer;
    [SerializeField] private ShopDancing _shopDancing;

    private Rigidbody _rigidbody;
    private PlayerView _view;
    private PlayerMoverView _viewMover;
    private PlayerModel _model;
    private PlayerMoverModel _moverModel;
    private Animator _animator;

    private void OnEnable()
    {
        _selecter.OnChangingSkin += Init;

        _shopDancing.GetPlayer(_viewMover);
    }

    private void OnDisable()
    {
        _selecter.OnChangingSkin -= Init;

        _presenter.Disable();
        _moverPresenter.Disable();
    }

    public void Init(PlayerView playerView)
    {
        playerView.gameObject.SetActive(true);

        _view = playerView;
        _viewMover = playerView.GetComponent<PlayerMoverView>();
        _animator = playerView.GetComponent<Animator>();
        _rigidbody = playerView.GetComponent<Rigidbody>();
        _chunksPlacer.GetPlayerTransform(playerView.transform);
        _backChunksPlacer.GetPlayerTransform(playerView.transform);

        _shopDancing.GetPlayer(_viewMover);

        _model = new PlayerModel();
        _moverModel = new PlayerMoverModel(_rigidbody, _animator);

        _presenter.Init(_model, _view);
        _moverPresenter.Init(_moverModel, _viewMover);

        _chunksPlacer.GetPlayerTransform(playerView.transform);

        _presenter?.Enable();
        _moverPresenter?.Enable();
    }
}


