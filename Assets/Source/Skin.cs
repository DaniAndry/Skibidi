using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private CosmeticsShopView _cosmeticsShopView;

    private Button _skinChangeButton;

    private void Start()
    {
        _skinChangeButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _skinChangeButton?.onClick.AddListener(ChangeSkin);
    }

    private void OnDisable()
    {
        _skinChangeButton?.onClick.RemoveListener(ChangeSkin);
    }

    private void ChangeSkin()
    {
        _cosmeticsShopView.SelectSkin(_playerView);
    }
}
