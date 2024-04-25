using System.Collections.Generic;
using UnityEngine;

public class ShopDancing : Shop
{
    [SerializeField] private List<Dance> _danceForSale;

    private Dance _selectedDance;
    private DanceSelecter _selecter;

    private void Start()
    {
        _selecter = GetComponent<DanceSelecter>();
    }

    private void OnEnable()
    {
        BuyButton.onClick.AddListener(TryBuyProduct);
        SelectButton.onClick.AddListener(SelectProduct);

        foreach (var dance in _danceForSale)
        {
            dance.OnSelected += ShowInfoProduct;
        }
    }

    private void OnDisable()
    {
        BuyButton.onClick.RemoveListener(TryBuyProduct);
        SelectButton.onClick.RemoveListener(SelectProduct);

        foreach (var dance in _danceForSale)
        {
            dance.OnSelected -= ShowInfoProduct;         
        }
    }

    public override void BuyProduct()
    {
        base.BuyProduct();
        _selectedDance.Unlock();
        _selecter.AddDance(_selectedDance);
        _danceForSale.Remove(_selectedDance);
        SelectProduct();
    }

    public override void ShowInfoProduct(Product dance)
    {
        _selectedDance = dance.GetComponent<Dance>();
        Description.text = _selectedDance.Description;

        if (_selectedDance.IsBought)
        {
            SelectButton.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(false);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);
            SelectButton.gameObject.SetActive(false);
        }

        SpawnDance(_selectedDance);
    }

    public override void SelectProduct()
    {
        _selecter.SelectDance(_selectedDance);
        Player.GetNameDance(_selectedDance.NameDanceAnim);
    }

    public override void TryBuyProduct()
    {
        if (BankMoney.TryTakeMoney(_selectedDance.Price))
        {
            BankMoney.TakeMoney(_selectedDance.Price);
            BuyProduct();
        }
        else
            ThrowErrorBuySkin();
    }

    public override void TurnOnModel()
    {
        base.TurnOnModel();
        ModelSkin?.GetComponent<Animator>().Play(_selectedDance.NameDanceAnim);
    }

    private void ThrowErrorBuySkin()
    {
        Debug.Log("ErrorBuy");
    }

}
