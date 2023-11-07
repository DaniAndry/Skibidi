using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenPresenter
{
    private EndScreenView _view;
    private Menu _viewMenu;
    private EndScreenModel _model;

    public EndScreenPresenter(EndScreenView view, EndScreenModel model, Menu viewMenu)
    {
        _view = view;
        _model = model;
        _viewMenu = viewMenu;
    }

    public void Enable()
    {
        _view.ClickingExitMenu += OnClickExitMenu;
    }

    public void Disable()
    {
        _view.ClickingExitMenu -= OnClickExitMenu;
    }

    private void OnClickExitMenu()
    {
        _view.CloseEndScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
