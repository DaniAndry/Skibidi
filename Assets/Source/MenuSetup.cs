using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSetup : MonoBehaviour
{
    [SerializeField] private SettingsView _viewSettings;
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private CosmeticsShopView _viewCosmeticsShop;

    private CosmeticsShopPresenter _presenterCosmeticsShop;
    private SettingsPresenter _presenterSettings;
    private MenuPresenter _presenterMenu;
    private CosmeticsShopModel _modelCosmeticsShop;
    private SettingsModel _modelSettings;
    private MenuModel _modelMenu;

    private void Awake()
    {
        Init();   
    }

    private void OnEnable()
    {
        _presenterCosmeticsShop.OnEnable();
        _presenterMenu.OnEnable();
        _presenterSettings.OnEnable();
    }

    private void OnDisable()
    {
        _presenterCosmeticsShop.OnDisable();
        _presenterMenu.OnDisable();
        _presenterSettings.OnDisable();
    }

    private void Init()
    {
        _modelCosmeticsShop = new CosmeticsShopModel();
        _modelMenu = new MenuModel();
        _modelSettings = new SettingsModel();
        _presenterSettings = new SettingsPresenter(_viewSettings, _modelSettings, _viewMenu);
        _presenterMenu = new MenuPresenter(_viewMenu, _modelMenu);
        _presenterCosmeticsShop = new CosmeticsShopPresenter(_viewCosmeticsShop, _modelCosmeticsShop, _viewMenu);
    }
}
