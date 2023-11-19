using UnityEngine;

public class MenuInit : MonoBehaviour
{
    [SerializeField] private Settings _viewSettings;
    [SerializeField] private Menu _viewMenu;
    [SerializeField] private EndScreenView _viewEndScreen;

    private MenuPresenter _presenterMenu;
    private MenuModel _modelMenu;

    private void Awake()
    {
        Init();   
    }

    private void OnEnable()
    {
        _presenterMenu.OnEnable();
    }

    private void OnDisable()
    {
        _presenterMenu.OnDisable();
    }

    private void Init()
    {
        _modelMenu = new MenuModel();
        _presenterMenu = new MenuPresenter(_viewMenu, _modelMenu);
    }
}
