using UnityEngine;

public class MenuInit : MonoBehaviour
{
    [SerializeField] private SettingsView _viewSettings;
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private CosmeticsShopView _viewCosmeticsShop;
    [SerializeField] private UpgradeView _viewUpgrade;
    [SerializeField] private MapsView _viewMaps;
    [SerializeField] private EndScreenView _viewEndScreen;

    private EndScreenModel _modelEndScreen;
    private EndScreenPresenter _presenterEndScreen;
    private MapsPresenter _presenterMaps;
    private CosmeticsShopPresenter _presenterCosmeticsShop;
    private SettingsPresenter _presenterSettings;
    private MenuPresenter _presenterMenu;
    private CosmeticsShopModel _modelCosmeticsShop;
    private SettingsModel _modelSettings;
    private MenuModel _modelMenu;
    private MapsModel _modelMaps;

    private void Awake()
    {
        Init();   
    }

    private void OnEnable()
    {
        _presenterEndScreen.Enable();
        _presenterMaps.OnEnable();
        _presenterCosmeticsShop.OnEnable();
        _presenterMenu.OnEnable();
        _presenterSettings.OnEnable();
    }

    private void OnDisable()
    {
        _presenterEndScreen.Disable();
        _presenterMaps.OnDisable();
        _presenterCosmeticsShop.OnDisable();
        _presenterMenu.OnDisable();
        _presenterSettings.OnDisable();
    }

    private void Init()
    {
        _modelEndScreen = new EndScreenModel();
        _modelMaps = new MapsModel();
        _modelCosmeticsShop = new CosmeticsShopModel();
        _modelMenu = new MenuModel();
        _modelSettings = new SettingsModel();
        _presenterSettings = new SettingsPresenter(_viewSettings, _modelSettings, _viewMenu);
        _presenterMenu = new MenuPresenter(_viewMenu, _modelMenu);
        _presenterCosmeticsShop = new CosmeticsShopPresenter(_viewCosmeticsShop, _modelCosmeticsShop, _viewMenu);
        _presenterMaps = new MapsPresenter(_viewMaps, _modelMaps, _viewMenu);
        _presenterEndScreen = new EndScreenPresenter(_viewEndScreen, _modelEndScreen, _viewMenu);
    }
}
