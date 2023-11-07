using UnityEngine;

public class CosmeticsShopPresenter
{
    private CosmeticsShopView _view;
    private CosmeticsShopModel _model;
    private Menu _viewMenu;

    public CosmeticsShopPresenter(CosmeticsShopView view, CosmeticsShopModel model, Menu viewMenu)
    {
        _view = view;
        _model = model;
        _viewMenu = viewMenu;
    }

    public void OnEnable()
    {
        _view.ClickButtonClose += OnClickButtonClose;
        _viewMenu.ClickingCosmeticsShop += OnClickCosmeticsShop;
    }

    public void OnDisable() 
    { 
        _view.ClickButtonClose -= OnClickButtonClose;
        _viewMenu.ClickingCosmeticsShop -= OnClickCosmeticsShop;
    }

    private void OnClickCosmeticsShop()
    {
        _view.Open();
    }

    private void OnClickButtonClose()
    {
        _view.CloseScreen();
    }
}
