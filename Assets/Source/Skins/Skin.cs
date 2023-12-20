using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private GameObject _prefabSkin;
    [SerializeField] private int _price;
    [SerializeField] private Image _buyFlag;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _isSelected;

    private Button _skinChangeButton;

    public string Description => _description;
    public string Name => _name;
    public bool IsSelected => _isSelected;
    public int Price => _price;
    public bool IsBought { get; private set; } = false;

    public event UnityAction<Skin> OnSelected;

    private void Awake()
    {
        _skinChangeButton = GetComponent<Button>();
        _buyFlag.gameObject.SetActive(IsBought);
        _skinChangeButton.onClick.AddListener(Select);
    }

    public PlayerView GetView()
    {
        return _playerView;
    }

    public GameObject GetPrefab()
    {
        return _prefabSkin;
    }

    public void TurnOffSkin()
    {
        _playerView.gameObject.SetActive(false);
    }

    public void Unlock()
    {
        IsBought = true;
        _buyFlag.gameObject.SetActive(IsBought);
    }

    public void Select()
    {
        OnSelected?.Invoke(this);

        if (IsBought && _isSelected)
        {
            TurnOnSkin();
        }
    }

    public void ChangeStatus()
    {
        _isSelected = !_isSelected;
    }

    private void TurnOnSkin()
    {
        _playerView.gameObject.SetActive(true);
    }
}