using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPresenter
{
    private SettingsView _view;
    private SettingsModel _model;
    private Menu _viewMenu;

    public SettingsPresenter(SettingsView view, SettingsModel model, Menu viewMenu)
    {
        _view = view;
        _model = model;
        _viewMenu = viewMenu;
    }

    public void OnEnable()
    {
        _view.ChangingSoundValue += OnChangeSoundValue;
        _view.ClickButtonClose += OnClickButtonClose;
        _viewMenu.ClickingSettings += OnClickSettings;
    }

    public void OnDisable()
    {
        _view.ChangingSoundValue -= OnChangeSoundValue;
        _view.ClickButtonClose -= OnClickButtonClose;
        _viewMenu.ClickingSettings -= OnClickSettings;
    }

    private void OnClickSettings()
    {
        _view.Open();
    }

    private void OnClickButtonClose()
    {
        _view.CloseScreen();
    }

    private void OnChangeSoundValue(float value)
    {
        _model.ChangeSound(value);
    }
}