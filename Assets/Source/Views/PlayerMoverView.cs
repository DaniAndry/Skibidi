using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoverView : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Boost _speedBoost;
    [SerializeField] private GameObject _prefabForDanceShop;

    private Vector3 _startPlayerPosition;
    private string _nameDanceAnim;
    private Button _speedBoostButton;
    private float _speed;
    private bool _isProtected;
    private bool _canMove = false;
    private bool _canJump = true;
    private PlayerInputHandler _inputHandler;

    public event Action<float> OnMoving;
    public event Action<float> OnChangingSpeed;
    public event Action<float> OnChangingSpeedCrash;
    public event Action<float, float> OnSpeedBoostChanging;
    public event Action<bool> OnProtected;

    public event Action OnStarted;
    public event Action OnStoped;
    public event Action OnKicked;
    public event Action OnJumped;
    public event Action OnJumping;
    public event Action OnSomersault;
    public event Action OnCrashed;
    public event Action OnRestart;
    public event Action OnDance;

    public string NameDanceAnim => _nameDanceAnim;
    public float CurrentSpeed => _speed;

    private void OnEnable()
    {
        _cameraMover.GetPlayerTransform(transform);
        _speedBoostButton.onClick.AddListener(UseSpeedBoost);
        _inputHandler.OnMobileJumpButtonClick += MobileJump;
        _inputHandler.OnJumpButtonClick += Jump;
    }

    private void Awake()
    {
        _inputHandler = PlayerInputHandler.Instance;
        _startPlayerPosition = transform.position;
        _speedBoostButton = _speedBoost.GetComponent<Button>();
        _inputHandler.OnMobileJumpButtonClick -= MobileJump;
        _inputHandler.OnJumpButtonClick -= Jump;
    }

    private void Update()
    {
        if (_canMove)
        {
            PlayerInputContorol();
        }
    }

    private void OnDisable()
    {
        _speedBoostButton.onClick.RemoveListener(UseSpeedBoost);
    }

    private void OnCollisionStay(Collision collision)
    {
        _canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {

        _canJump = false;
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
        OnSpeedBoostChanging?.Invoke(count, time);
    }

    public void ChangeCurrentSpeed(float speed)
    {
        _speed = speed;
        OnChangingSpeed?.Invoke(speed);
    }

    public void Protect(bool protect)
    {
        _isProtected = protect;
        OnProtected?.Invoke(protect);
    }

    public void Crash()
    {
        if (!_isProtected)
        {
            float moveSpeed = 3;
            AudioManager.Instance.Play("Crash");
            OnChangingSpeedCrash?.Invoke(moveSpeed);

            TaskCounter.IncereaseProgress(1, TaskType.CrashWall.ToString());
        }
    }

    public void CrashOnCar()
    {
        OnCrashed?.Invoke();
    }

    public void StartMove()
    {
        _cameraMover?.StartMove();
        _canMove = true;
        OnStarted?.Invoke();
    }

    public void ResetMove()
    {
        _cameraMover?.ResetCameraPosition();
        transform.position = _startPlayerPosition;
        OnRestart?.Invoke();
    }

    public void EndMove()
    {
        _cameraMover?.EndMove();
        _canMove = false;
        OnStoped?.Invoke();
    }

    public void Kick()
    {
        OnKicked?.Invoke();
    }

    public void Jumped()
    {
        OnJumped?.Invoke();
    }

    public void Somersault()
    {
        OnSomersault?.Invoke();
    }

    public void Dance()
    {
        OnDance?.Invoke();
    }

    public void SetSpeedBoostTimer(float time)
    {
        _speedBoost.SetTimeText(time);
    }

    private void PlayerInputContorol()
    {
        if (_joystick.Horizontal < 0f && _joystick.Horizontal > -1)
            OnMoving?.Invoke(_joystick.Horizontal);
        else if (_joystick.Horizontal > 0f && _joystick.Horizontal < 1)
            OnMoving?.Invoke(_joystick.Horizontal);
        else
            OnMoving?.Invoke(0);
    }

    private void MobileJump(Vector2 swape)
    {
        if (_canJump && swape.y > _inputHandler.DeltaMobileJump)
            OnJumping?.Invoke();
    }

    private void Jump() 
    {
        if (_canJump)
            OnJumping?.Invoke();
    }

    private void UseSpeedBoost()
    {
        if (_speedBoost.TryUse())
            OnSpeedBoostChanging?.Invoke(_speedBoost.Bonus, _speedBoost.Time);
        else
            Debug.Log("ErrorUseBoost");
    }
}
