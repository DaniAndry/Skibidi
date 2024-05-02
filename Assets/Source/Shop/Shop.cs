using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Shop : MonoBehaviour
{
    [SerializeField] private Transform _placeSkin;
    [SerializeField] private Bank _bank;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private TMP_Text _description;

    private PlayerMoverView _playerView;

    public PlayerMoverView Player => _playerView;
    public Bank BankMoney => _bank;
    public Transform PlaceSkin => _placeSkin;
    public Button BuyButton => _buyButton;
    public Button SelectButton => _selectButton;
    public TMP_Text Description => _description;

    public GameObject ModelSkin { get; private set; }

    private void Start()
    {
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(false);
    }

    public void GetView(PlayerMoverView view)
    {
        _playerView = view;
    }

    public void TurnOffModel()
    {
        ModelSkin?.SetActive(false);
    }

    public void SpawnDance(Dance dance)
    {
        if (ModelSkin != null)
            Destroy(ModelSkin);

        ModelSkin = Instantiate(_playerView.GetPrefab(), _placeSkin);
        ModelSkin.GetComponent<Animator>().Play(dance.NameDanceAnim);

        SetPositionModel();
    }

    virtual public void TurnOnModel()
    {
        ModelSkin?.SetActive(true);
    }

    virtual public void BuyProduct()
    {
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(true);
    }

    public void SpawnSkin(Skin skin)
    {
        if (ModelSkin != null)
            Destroy(ModelSkin);

        ModelSkin = Instantiate(skin.GetPrefab(), _placeSkin);

        SetPositionModel();
    }

    public abstract void ShowInfoProduct(Product skin);

    public abstract void SelectProduct();

    public abstract void TryBuyProduct();

    private void SetPositionModel()
    {
        Vector3 position = new Vector3(_placeSkin.position.x, _placeSkin.position.y, _placeSkin.position.z);
        ModelSkin.transform.position = position;
        ModelSkin.GetComponent<Animator>().Play("Idle");
    }
}
