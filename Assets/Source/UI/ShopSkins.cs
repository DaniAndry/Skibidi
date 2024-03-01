using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkins : MonoBehaviour
{
    [SerializeField] private Transform _placeSkin;
    [SerializeField] private Bank _bank;
    [SerializeField] private Button _buyButton;
    [SerializeField] private List<Skin> _skinForSale;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _name;

    private ShopData _shopData;
    private Skin _selectedSkin;
    private SkinSelecter _selecter;
    private GameObject _modelSkin;

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

        ShowInfoForSkin();
    }
    //тут немного грязно
    public void ShowInfoForSkin()
    {
        _name.text = _selectedSkin.Name;
        _description.text = _selectedSkin.Description;

        if (_modelSkin != null)
            Destroy(_modelSkin);

        _modelSkin = Instantiate(_selectedSkin.GetPrefab(), _placeSkin);
    }

    public void TurnOffSkin()
    {
        _modelSkin?.SetActive(false);
    }

    public void TurnOnSkinModel()
    {
        _modelSkin?.SetActive(true);
    }

    private void TryBuySkin()
    {
        if (_bank.TryTakeMoney(_selectedSkin.Price))
        {
            _bank.TakeMoney(_selectedSkin.Price);
            BuySkin();
        }
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
