using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkins : MonoBehaviour
{
    [SerializeField] private Transform _placeSkin;
    [SerializeField] private Bank _bank;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
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
        _selectButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuySkin);
        _selectButton.onClick.AddListener(SelectSkin);

        foreach (var skin in _skinForSale)
        {
            skin.OnSelected += ShowInfoSkin;
        }
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuySkin);
        _selectButton.onClick.RemoveListener(SelectSkin);

        foreach (var skin in _skinForSale)
        {
            skin.OnSelected -= ShowInfoSkin;
        }
    }

    public void TurnOffSkin()
    {
        _modelSkin?.SetActive(false);
    }

    public void TurnOnSkinModel()
    {
        _modelSkin?.SetActive(true);
        _modelSkin?.GetComponent<Animator>().Play("Idle");
    }

    public void BuySkin()
    {
        _selectedSkin.Unlock();
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(true);
        _selecter.AddSkin(_selectedSkin);
        _selecter.SelectSkin(_selectedSkin);
        _skinForSale.Remove(_selectedSkin);

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

    private void SpawnSkin()
    {
        if (_modelSkin != null)
            Destroy(_modelSkin);

        _modelSkin = Instantiate(_selectedSkin.GetPrefab(), _placeSkin);
        Vector3 position = new Vector3(_placeSkin.position.x, _placeSkin.position.y, _placeSkin.position.z);
        _modelSkin.transform.position = position;
        _modelSkin.GetComponent<Animator>().Play("Idle");
    }

    private void ShowInfoSkin(Skin skin)
    {
        _selectedSkin = skin;
        _name.text = _selectedSkin.Name;
        _description.text = _selectedSkin.Description;

        if (_selectedSkin.IsBought)
        {
            _selectButton.gameObject.SetActive(true);
            _buyButton.gameObject.SetActive(false);
        }
        else
        {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
        }

        SpawnSkin();
    }

    private void SelectSkin()
    {
        _selecter.SelectSkin(_selectedSkin);
    }

    private void TryBuySkin()
    {
        if (_bank.TryTakeValue(_selectedSkin.Price))
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
}
