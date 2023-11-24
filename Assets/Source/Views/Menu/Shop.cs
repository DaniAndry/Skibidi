using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private List<Skin> _skinForSale;

    private PlayerView _player;
    private ShopData _shopData;
    private Skin _selectedSkin;
    private SkinSelecter _selecter;

    private void Start()
    {
        _selecter = GetComponent<SkinSelecter>();
        LoadShop();
        _buyButton.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuySkin);

        foreach (var skin in _skinForSale)
        {
            skin.OnSelected += SelectSkin;
        }
    }

    public void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuySkin);

        foreach (var skin in _skinForSale)
        {
            skin.OnSelected -= SelectSkin;
        }
    }

    private void SelectSkin(Skin skin)
    {
        _selectedSkin = skin;
        _buyButton.gameObject.SetActive(true);
    }

    private void TryBuySkin()
    {
        _player = _selecter.Player;
        _player.ChangingMoney(_selectedSkin.Price);

        BuySkin();
    }

    public void BuySkin()
    {
        _selectedSkin.Unlock();
        _buyButton.gameObject.SetActive(false);
        _selecter.AddSkin(_selectedSkin);
        _skinForSale.Remove(_selectedSkin);
        _selectedSkin.OnSelected -= SelectSkin;

        SaveShop();
    }


    public void SaveShop()
    {
        SaveSystem.SaveShop(_shopData);
    }

    public void LoadShop()
    {
        //ShopData data = SaveSystem.LoadShop();

        // if (data != null)
        // {
        //CurrentPlayerSkin = data.PlayerSkin;

        //foreach(Skin skin in data.BoughtSkins)
        //{
        //    BoughtSkins.Add(skin);
        //}
        // }
    }
}
