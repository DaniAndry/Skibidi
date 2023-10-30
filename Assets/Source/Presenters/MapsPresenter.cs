using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsPresenter 
{
    private MapsView _view;
    private MapsModel _model;
    private Menu _viewMenu;

    public MapsPresenter(MapsView view, MapsModel model, Menu viewMenu)
    {
        _view = view;
        _model = model;
        _viewMenu = viewMenu;
    }

    public void OnEnable()
    {
        _view.ClickButtonClose += OnClickButtonClose;
        _viewMenu.ClickMaps += OnClickMaps;
    }

    public void OnDisable()
    {
        _view.ClickButtonClose -= OnClickButtonClose;
        _viewMenu.ClickMaps -= OnClickMaps;
    }

    private void OnClickButtonClose()
    {
        _view.CloseScreen();
    }

    private void OnClickMaps()
    {
        _view.Open();
    }
}
