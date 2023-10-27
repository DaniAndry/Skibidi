using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerView _view;
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private PlayerMoverView _moverView;
    [SerializeField] private Rigidbody _rigidbody;

    private PlayerModel _model;
    private PlayerMoverModel _moverModel;
    private PlayerPresenter _presenter;
    private PlayerMoverPresenter _moverPresenter;

    private void Awake()
    {
        _model = new PlayerModel();
        _presenter = new PlayerPresenter(_model, _view, _viewMenu);
        _moverModel = new PlayerMoverModel(_rigidbody);
        _moverPresenter = new PlayerMoverPresenter(_moverModel, _moverView, _viewMenu);

        _moverPresenter.Init();
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
