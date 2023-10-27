using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSetup : MonoBehaviour
{
    [SerializeField] private Menu _view;

    private MenuPresenter _presenter;
    private MenuModel _model;

    private void Awake()
    {
        _model = new MenuModel();
        _presenter = new MenuPresenter(_view, _model);
    }

    private void OnEnable()
    {
        _presenter.OnEnable();
    }

    private void OnDisable()
    {
        _presenter.OnDisable();
    }
}
