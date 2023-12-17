using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDancing : MonoBehaviour
{
    [SerializeField] private Transform _placeSkin;
    [SerializeField] private List<Dance> _danceForSale;
    [SerializeField] private Bank _bank;
    [SerializeField] private Button _buyButton;

    private Dance _selectedDance;
    private DanceSelector _selecter;
    private PlayerMoverView _player;
    private GameObject _modelDance;

    private void Start()
    {
        _selecter = GetComponent<DanceSelector>();
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuySkin);

        foreach (var dance in _danceForSale)
        {
            dance.OnSelected += SelectDance;
        }
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuySkin);

        foreach (var dance in _danceForSale)
        {
            dance.OnSelected -= SelectDance;
        }
    }

    private void SelectDance(Dance dance)
    {
        _selectedDance = dance;
        _buyButton.gameObject.SetActive(true);

        ShowInfoForSkin();
    }

    private void TryBuySkin()
    {
        if (_bank.TryTakeMoney(_selectedDance.Price))
        {
            _bank.TakeMoney(_selectedDance.Price);
            BuySkin();
        }
        else
            ThrowErrorBuySkin();
    }

    private void ThrowErrorBuySkin()
    {
        Debug.Log("ErrorBuy");
    }

    public void GetPlayer(PlayerMoverView player)
    {
        _player = player;
    }

    public void ShowInfoForSkin()
    {
        if (_modelDance != null)
            Destroy(_modelDance);

        _modelDance = Instantiate(_player.GetPrefab(), _placeSkin);

        _modelDance.GetComponent<Animator>().Play(_selectedDance.NameDanceAnim);
    }

    public void BuySkin()
    {
        _selectedDance.Unlock();
        _buyButton.gameObject.SetActive(false);
        _selecter.AddDance(_selectedDance);
        _danceForSale.Remove(_selectedDance);
        _selectedDance.OnSelected -= SelectDance;
        _player.GetNameDance(_selectedDance.NameDanceAnim);
    }

    public void TurnOffDanceModel()
    {
        _modelDance?.SetActive(false);
    }

    public void TurnOnDanceModel()
    { 
        _modelDance?.SetActive(true);
        _modelDance?.GetComponent<Animator>().Play(_selectedDance.NameDanceAnim);
    }
}
