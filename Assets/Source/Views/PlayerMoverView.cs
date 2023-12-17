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

    public event Action<float> OnMoving;
    public event Action OnJumping;
    public event Action<float> ChangingSpeedCrash;
    public event Action<float, float> SpeedBoostChanging;

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
        if (Input.GetKey(KeyCode.A))
            OnMoving?.Invoke(-1);
        else if (Input.GetKey(KeyCode.D) || _joystick.Horizontal > 0)
            OnMoving?.Invoke(1);
        else
            OnMoving?.Invoke(0);

        if (Input.GetKey(KeyCode.Space))
            OnJumping?.Invoke();

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
        SpeedBoostChanging?.Invoke(count, time);
    }

    public void Crash()
    {
        float moveSpeed = 2;
        ChangingSpeedCrash?.Invoke(moveSpeed);
    }

    public void StartGame()
    {
        _cameraMover?.StartMove();
    }

    public void EndGame()
    {
        _cameraMover?.EndMove();
    }
}
