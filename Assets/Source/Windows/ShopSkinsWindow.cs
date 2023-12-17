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
        base.Open();
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
        AudioManager.Instance.Play("Click");
        base.Open();
        _shop.TurnOnSkinModel();

        _shopBoosts.Close();
        _shopDancing.Close();
    }

    public override void Close()
    {
        base.Close();
        _shop.TurnOffSkin();
    }
}
