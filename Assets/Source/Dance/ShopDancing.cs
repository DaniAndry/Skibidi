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
    [SerializeField] private Button _selectButton;
    [SerializeField] private TMP_Text _name;

    private Dance _selectedDance;
    private DanceSelecter _selecter;
    private PlayerMoverView _player;
    private GameObject _modelDance;

    private void Start()
    {
        _selecter = GetComponent<DanceSelecter>();
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuySkin);
        _selectButton.onClick.AddListener(SelectDance);

        foreach (var dance in _danceForSale)
        {
            dance.OnSelected += ShowDance;
        }
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuySkin);
        _selectButton.onClick.RemoveListener(SelectDance);

        foreach (var dance in _danceForSale)
        {
            dance.OnSelected -= ShowDance;
        }
    }

    public void GetPlayer(PlayerMoverView player)
    {
        _player = player;
    }

    public void SpawnDanceModel()
    {
        if (_modelDance != null)
            Destroy(_modelDance);

        _modelDance = Instantiate(_player.GetPrefab(), _placeSkin);
        Vector3 position = new Vector3(_placeSkin.position.x, _placeSkin.position.y, _placeSkin.position.z);
        _modelDance.transform.position = position;

        _modelDance.GetComponent<Animator>().Play(_selectedDance.NameDanceAnim);
    }

    public void BuySkin()
    {
        _selectedDance.Unlock();
        _buyButton.gameObject.SetActive(false);
        _selecter.AddDance(_selectedDance);
        _danceForSale.Remove(_selectedDance);
        SelectDance();
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

    private void SelectDance()
    {
        _selecter.SelectDance(_selectedDance);
        _player.GetNameDance(_selectedDance.NameDanceAnim);
    }

    private void ShowDance(Dance dance)
    {
        _name.text = dance.NameDance;
        _selectedDance = dance;
        _buyButton.gameObject.SetActive(true);

        if (_selectedDance.IsBought)
        {
            _selectButton.gameObject.SetActive(true);
            _buyButton.gameObject.SetActive(false);
        }
        else
        {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
        }

        SpawnDanceModel();
    }

    private void TryBuySkin()
    {
        if (_bank.TryTakeValue(_selectedDance.Price))
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
}
