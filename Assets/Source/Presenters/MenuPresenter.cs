using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPresenter
{
    private Menu _view;
    private MenuModel _model;

    public MenuPresenter(Menu view, MenuModel model)
    {
        _view = view;
        _model = model;
    }

    public void OnEnable()
    {
        _model.StartedGame += OnStartedGame;
        _view.ClickingStart += OnClickStart;
    }

    public void OnDisable()
    {
        _model.StartedGame -= OnStartedGame;
        _view.ClickingStart -= OnClickStart;
    }

    private void OnStartedGame()
    {
        _view.CloseMenu();
    }

    private void OnClickStart()
    {
        _model.StartGame();
    }
}
