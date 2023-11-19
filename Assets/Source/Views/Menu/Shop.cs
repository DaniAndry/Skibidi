using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour 
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Skin _firstSkin;

    private Skin _selectedSkin;

    public event Action<PlayerView> OnChangingSkin;

    public PlayerView CurrentPlayerSkin { get; private set; }
    public List<Skin> BoughtSkins { get; private set; } = new List<Skin>();

    private void Start()
    {
        LoadShop();
        InitSkins();

        _buyButton.onClick.AddListener(TryBuySkin);
        _selectButton.onClick.AddListener(SelectSkin);
    }

    public void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuySkin);
        _selectButton.onClick.AddListener(SelectSkin);
    }

    public void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuySkin);
        _selectButton.onClick.RemoveListener(SelectSkin);
    }

    public void ShowSkin(Skin skin)
    {
        _selectedSkin = skin;

        if (skin.IsBought && skin.IsSelected == false)
        {
            _selectButton.gameObject.SetActive(true);
            _selectButton.interactable = true;
        }
        else if(skin.IsBought && skin.IsSelected)
        {
            _selectButton.gameObject.SetActive(true);
            _selectButton.interactable = false;
        }
        else
        {
            _buyButton.gameObject.SetActive(true);
        }
    }

    private void SelectSkin()
    {
        OnChangingSkin?.Invoke(_selectedSkin.GetSkin());

        foreach (Skin skin in BoughtSkins)
        {
            skin.TurnOffSkin();
        }

        _selectedSkin.TurnOnSkin();
        _selectButton.interactable = false;
    }

    private void TryBuySkin()
    {
        CurrentPlayerSkin.ChangingMoney(_selectedSkin.Price);
    }

    public void BuySkin()
    {
        _selectedSkin.Buy();
        if(BoughtSkins.Contains(_selectedSkin) == false)
            BoughtSkins.Add(_selectedSkin);
        _buyButton.gameObject.SetActive(false);
        SelectSkin();

        SaveShop();
    }

    private void InitSkins()
    {
        if (BoughtSkins.Contains(_firstSkin) == false)
        {
            BoughtSkins.Add(_firstSkin);
            _firstSkin.Buy();
            _firstSkin.TurnOnSkin();
        }

        foreach (Skin skin in BoughtSkins)
        {
            skin.LoadData();

            if (skin.IsSelected == true)
            {
                skin.TurnOnSkin();
                CurrentPlayerSkin = skin.GetSkin();
                OnChangingSkin?.Invoke(CurrentPlayerSkin);
            }
        }
    }

    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }

    public void LoadShop()
    {
        ShopData data = SaveSystem.LoadShop();

        if (data != null)
        {
            CurrentPlayerSkin = data.PlayerSkin;

            foreach(Skin skin in data.BoughtSkins)
            {
                BoughtSkins.Add(skin);
            }
        }
    }
}
