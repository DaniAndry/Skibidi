using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    [SerializeField] private PlayerView _view;
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private PlayerMoverView _viewMover;
    [SerializeField] private EndScreenView _viewEndScreen;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerMoverPresenter _moverPresenter;
    [SerializeField] private PlayerPresenter _presenter;
    [SerializeField] private EnergyUpgrade _energyUpgrade;
    [SerializeField] private Animator _animator;

    private PlayerModel _model;
    private PlayerMoverModel _moverModel;

    private void Awake()
    {
        _model = new PlayerModel();
        _moverModel = new PlayerMoverModel(_rigidbody, _animator);

        _presenter.Init(_model, _view, _viewMenu, _viewEndScreen,_viewMover, _energyUpgrade);
        _moverPresenter.Init(_moverModel, _viewMover, _viewMenu);
    }

    private void OnEnable()
    {
        _presenter.Enable();
        _moverPresenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();    
        _moverPresenter.Disable();
    }
}
