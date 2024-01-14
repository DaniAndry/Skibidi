using UnityEngine;
using UnityEngine.UI;

public class ShopSkinsWindow : Window
{
    [SerializeField] private Button _openButton;
    [SerializeField] private ShopDancingWindow _shopDancing;
    [SerializeField] private BoostShopWindow _shopBoosts;

    private ShopSkins _shop;

    private void Awake()
    {
        OpenWithoutSound();
        _shop = GetComponent<ShopSkins>();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Open);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Open);
    }

    public override void Open()
    {
        base.Open();
        _shop.TurnOnSkinModel();

        _shopBoosts.CloseWithoutSound();
        _shopDancing.Close();
    }

    public override void Close()
    {
        base.CloseWithoutSound();
        _shop.TurnOffSkin();
    }
}
