using UnityEngine.UI;
using UnityEngine;

public class DailyRewardView : MonoBehaviour
{
    [SerializeField] private Image _openImage;
    [SerializeField] private Image _image;
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _isUnbox;
    private bool _isUnlock;
    private int _index;
    private int _amount;
    private DailyRewardSystem _system;

    private void Start()
    {
        SelectImage();
    }

    public void Init(int amount, bool isUnlock, bool isUnbox, int index, DailyRewardSystem rewardSystem)
    {
        _isUnbox = isUnbox;
        _isUnlock = isUnlock;
        _index = index;
        _system = rewardSystem;
        _amount = amount;
    }

    public void TryToGetReward()
    {
        if (_isUnlock)
        {
            _system.GiveReward(_index, _amount);
            _isUnbox = true;
            Open();
        }
    }

    private void SelectImage()
    {
        _image.enabled = !_isUnbox;
        _openImage.enabled = _isUnbox;
    }

    private void Open()
    {
        _image.enabled = false;
        _openImage.enabled = true;
        _particleSystem.Play();
    }
}