using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private EndScreenView _viewEndScreen;
    [SerializeField] private PlayerMoverPresenter _moverPresenter;
    [SerializeField] private PlayerPresenter _presenter;
    [SerializeField] private EnergyUpgrade _energyUpgrade;
    [SerializeField] private Shop _shop;
    [SerializeField] private List<PlayerView> _playerViews = new List<PlayerView>();
    [SerializeField] private GameObject _core;
    [SerializeField] private ChunksPlacer _chunksPlacer;

    private Rigidbody _rigidbody;
    private PlayerView _view;
    private PlayerMoverView _viewMover;
    private PlayerModel _model;
    private PlayerMoverModel _moverModel;
    private Animator _animator;

    private void Awake()
    {
        _core.SetActive(false);
    }

    private void OnEnable()
    {
        _shop.OnChangingSkin += Init;
    }

    private void OnDisable()
    {
        _shop.OnChangingSkin -= Init;

        _presenter.Disable();
        _moverPresenter.Disable();
    }

    public void Init(PlayerView playerView)
    {
        _core.SetActive(false);

        _view = playerView;
        _viewMover = playerView.GetComponent<PlayerMoverView>();
        _animator = playerView.GetComponent<Animator>();
        _rigidbody = playerView.GetComponent<Rigidbody>();

        foreach (PlayerView player in _playerViews)
        {
            if (player == playerView)
            {
                _model = new PlayerModel();
                _moverModel = new PlayerMoverModel(_rigidbody, _animator);

                _presenter.Init(_model, _view, _viewMenu, _viewEndScreen, _viewMover, _energyUpgrade, _shop);
                _moverPresenter.Init(_moverModel, _viewMover, _viewMenu);

                _chunksPlacer.GetPlayerTransform(player.transform);

                _core.SetActive(true);

                _presenter?.Enable();
                _moverPresenter?.Enable();
            }
        }
    }
}


