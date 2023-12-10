using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoostBuyButton : MonoBehaviour
{
    [SerializeField] private Boost _boost;
    [SerializeField] private int _priceBuyBoost;
    [SerializeField] private int _priceUpgradeBoost;
    [SerializeField] private Button _buyForMoney;
    [SerializeField] private Button _buyForAd;
    [SerializeField] private Button _upgradeForMoney;
    [SerializeField] private Button _upgradeForAd;
    [SerializeField] private TMP_Text _workTimeText;

    private int _countUpgrade = 1;
    private float _workTime = 10;
    private TMP_Text _priceBuyText;
    private TMP_Text _priceUpgradeText;
    private ShopBoosts _shopBoosts;

    public int Price => _priceBuyBoost;

    private void Awake()
    {
        _priceBuyText = _buyForMoney.GetComponentInChildren<TMP_Text>();
        _priceUpgradeText = _upgradeForMoney.GetComponentInChildren<TMP_Text>();
        _shopBoosts = GetComponentInParent<ShopBoosts>();

        UpdateText();
    }

    private void OnEnable()
    {
        _buyForMoney.onClick.AddListener(BuyForMoney);
        _buyForAd.onClick.AddListener(BuyForAd);
        _upgradeForMoney.onClick.AddListener(UpgradeForMoney);
        _upgradeForAd.onClick.AddListener(UpgradeForAd);
    }

    private void OnDisable()
    {
        _buyForMoney.onClick.RemoveListener(BuyForMoney);
        _buyForAd.onClick.RemoveListener(BuyForAd);
        _upgradeForMoney.onClick.RemoveListener(UpgradeForMoney);
        _upgradeForAd.onClick.RemoveListener(UpgradeForAd);
    }

    private void UpdateText()
    {
        _priceBuyText.text = _priceBuyBoost.ToString();
        _priceUpgradeText.text = _priceUpgradeBoost.ToString();
        _workTimeText.text = _workTime.ToString();
    }

    private void BanUpgrade()
    {
        _upgradeForAd.interactable = false;
        _upgradeForMoney.interactable = false;
    }

    public void BuyForMoney()
    {
        _shopBoosts.Buy(_boost, _priceBuyBoost);
        _workTime = _boost.Time;
        UpdateText();
    }

    public void BuyForAd()
    {
    }

    public void UpgradeForMoney()
    {
        _shopBoosts.BuyUpgrade(_boost, _priceUpgradeBoost);
        _workTime = _boost.Time;
        _countUpgrade++;
        UpdateText();

        if (_countUpgrade > 5)
            BanUpgrade();
    }

    public void UpgradeForAd()
    {
    }

    public void LoadData()
    {
        _countUpgrade = _boost.CountUpgrade;
        _workTime = _boost.Time;

        if (_countUpgrade > 5)
            BanUpgrade();

        UpdateText();
    }
}
