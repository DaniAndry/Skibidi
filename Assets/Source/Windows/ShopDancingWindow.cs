using UnityEngine;
using UnityEngine.UI;

public class ShopDancingWindow : Window
{
    [SerializeField] private Button _openButton;
    [SerializeField] private BoostShopWindow _shopBoosts;
    [SerializeField] private ShopSkinsWindow _shopSkins;

    private ShopDancing _shop;

    private void Awake()
    {
        base.Close();
        _shop = GetComponent<ShopDancing>();
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
        _shop.TurnOnDanceModel();

        _shopBoosts.Close();
        _shopSkins.Close();
    }

    public override void Close()
    {
        base.Close();
        _shop.TurnOffDanceModel();
    }
}
