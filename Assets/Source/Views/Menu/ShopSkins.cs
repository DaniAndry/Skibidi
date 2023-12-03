using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkins : MonoBehaviour
{
    [SerializeField] private Transform _placeSkin;
    [SerializeField] private Bank _bank;
    [SerializeField] private Button _buyButton;
    [SerializeField] private List<Skin> _skinForSale;

    private ShopData _shopData;
    private Skin _selectedSkin;
    private SkinSelecter _selecter;
    private GameObject _prefabSkin;

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

        if(_prefabSkin != null)
            Destroy(_prefabSkin);

        _prefabSkin = _selectedSkin.GetPrefab();
        Instantiate(_prefabSkin, _placeSkin);
    }

    private void TryBuySkin()
    {
        if (_bank.TryTakeMoney(_selectedSkin.Price))
            BuySkin();
        else
            ThrowErrorBuySkin();

    }

    private void ThrowErrorBuySkin()
    {
        Debug.Log("ErrorBuy");
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
