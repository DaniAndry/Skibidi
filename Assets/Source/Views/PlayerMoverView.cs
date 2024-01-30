using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoverView : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Boost _speedBoost;
    [SerializeField] private GameObject _prefabForDanceShop;

    private Animator _animator;
    private string _nameDanceAnim;
    private Button _speedBoostButton;
    private float _speed;
    private bool _isProtected;

    public event Action<float> OnMoving;
    public event Action OnJumping;
    public event Action<float> ChangingSpeedCrash;
    public event Action<float, float> SpeedBoostChanging;
    public event Action OnStarted;
    public event Action OnStoped;
    public event Action OnKicked;

    public float CurrentSpeed => _speed;

    private void Awake()
    {
        _speedBoostButton = _speedBoost.GetComponent<Button>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        DecktopContorol();
        /*   MobileContorol();*/
    }

    private void OnEnable()
    {
        _cameraMover.GetPlayerTransform(transform);
        _speedBoostButton.onClick.AddListener(UseSpeedBoost);
    }

    private void OnDisable()
    {
        _speedBoostButton.onClick.RemoveListener(UseSpeedBoost);
    }

    private void DecktopContorol()
    {
        if (Input.GetKey(KeyCode.Space))
            OnJumping?.Invoke();
        if (Input.GetKey(KeyCode.A))
            OnMoving?.Invoke(-1);
        else if (Input.GetKey(KeyCode.D))
            OnMoving?.Invoke(1);
        else if (Input.GetKey(KeyCode.Space))
            OnJumping?.Invoke();
        else
            OnMoving?.Invoke(0);
    }

    private void MobileContorol()
    {
        if (_joystick.Horizontal < 0f && _joystick.Horizontal > -1)
            OnMoving?.Invoke(-1);
        else if (_joystick.Horizontal > 0f && _joystick.Horizontal < 1)
            OnMoving?.Invoke(1);
        else
            OnMoving?.Invoke(0);
    }

    private void UseSpeedBoost()
    {
        if (_speedBoost.TryUse())
            SpeedBoostChanging?.Invoke(_speedBoost.Bonus, _speedBoost.Time);
        else
            Debug.Log("ErrorUseBoost");
    }

    public GameObject GetPrefab()
    {
        return _prefabForDanceShop;
    }

    public void GetNameDance(string nameDance)
    {
        _nameDanceAnim = nameDance;
    }

    public void ChangeSpeed(float count, float time)
    {
        AudioManager.Instance.Play("UseBoost");
        SpeedBoostChanging?.Invoke(count, time);
    }

    public void ChangeCurrentSpeed(float speed)
    {
        _speed = speed;
    }

    public void Protect(bool protect)
    {
        _isProtected = protect;
    }

    public void Crash()
    {
        Debug.Log(_isProtected);
        if (!_isProtected)
        {
            float moveSpeed = 2;
            AudioManager.Instance.Play("Crash");
            ChangingSpeedCrash?.Invoke(moveSpeed);
        }
    }

    public void StartGame()
    {
        _cameraMover?.StartMove();
        OnStarted?.Invoke();
    }

    public void EndGame()
    {
        _cameraMover?.EndMove();
        OnStoped?.Invoke();
    }

    public void Kick()
    {
        OnKicked?.Invoke();
    }
}
