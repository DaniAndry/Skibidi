using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private Shop _cosmeticsShopView;
    [SerializeField] private int _price;
    [SerializeField] private Image _buyFlag;
    [SerializeField] private string _skinName;
    [SerializeField] private string _skinDescription;

    private bool _isSelected;
    private Button _skinChangeButton;

    public bool IsSelected => _isSelected;
    public int Price => _price;
    public bool IsBought { get; private set; } = false;

    private void Awake()
    {
        _skinChangeButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _skinChangeButton.onClick.AddListener(ShowSkin);
    }

    private void OnDisable()
    {
        _skinChangeButton.onClick.RemoveListener(ShowSkin);
    }

    private void ShowSkin()
    {
        _cosmeticsShopView.ShowSkin(this);
    }

    public PlayerView GetSkin()
    {
        return _playerView;
    }

    public void TurnOffSkin()
    {
        _playerView.gameObject.SetActive(false);
        _isSelected = false;
        SaveData();
    }

    public void TurnOnSkin()
    {
        _playerView.gameObject.SetActive(true);
        _isSelected = true;
        SaveData();
    }

    public void Buy()
    {
        IsBought = true;
        _buyFlag.gameObject.SetActive(true);
    }

    private void SaveData()
    {
        int isSelected = _isSelected ? 1 : 0;
        int isBought = IsBought ? 1 : 0;
        PlayerPrefs.SetInt(name + "isBought", isBought);
        PlayerPrefs.SetInt(name + "isSelected", isSelected);
    }

    public void LoadData()
    {
        int isBought = PlayerPrefs.GetInt(name + "isBought");
        int isSelected = PlayerPrefs.GetInt(name + "isSelected");
        IsBought = isBought == 1;
        _isSelected = isSelected == 1;

        if(IsBought)
            Buy();
    }
}
