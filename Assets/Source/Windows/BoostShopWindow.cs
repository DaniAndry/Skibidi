using UnityEngine;
using UnityEngine.UI;

public class BoostShopWindow : Window
{
    [SerializeField] private Button _openButton;
    [SerializeField] private ShopDancingWindow _shopDancing;
    [SerializeField] private ShopSkinsWindow _shopSkins;

    private void Awake()
    {
        base.Close();
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

        _shopDancing.Close();
        _shopSkins.Close();
    }
}
