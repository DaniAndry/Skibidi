using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public static PlayerInputHandler Instance;

    [SerializeField] private InputActionAsset _playerControls;
    [SerializeField] private string _actionMapName = "Player";
    [SerializeField] private string _turn = "Turn";
    [SerializeField] private string _jump = "Jump";
    [SerializeField] private string _jumpMobile = "JumpMobile";
    [SerializeField] private string _pause = "Pause";

    private InputAction _turnAction;
    private InputAction _jumpAction;
    private InputAction _jumpMobileAction;
    private InputAction _pauseAction;

    public event Action OnPauseButtonClick;

    public Vector2 TurnInput { get; private set; }
    public Vector2 JumpMobileTriggered { get; private set; }
    public bool JumpTriggered { get; private set; }
    public float DeltaMobileJump { get; private set; } = 100;

    private void OnEnable()
    {
        _turnAction.Enable();
        _jumpAction.Enable();
        _jumpMobileAction.Enable();
        _pauseAction.Enable();
    }
   
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _turnAction = _playerControls.FindActionMap(_actionMapName).FindAction(_turn);
        _jumpAction = _playerControls.FindActionMap(_actionMapName).FindAction(_jump);
        _jumpMobileAction = _playerControls.FindActionMap(_actionMapName).FindAction(_jumpMobile);
        _pauseAction = _playerControls.FindActionMap(_actionMapName).FindAction(_pause);

        RegisterInputActions();
    }

    private void OnDisable()
    {
        _turnAction.Disable();
        _jumpAction.Disable();
        _jumpMobileAction.Disable();
        _pauseAction.Disable();
    }

    private void RegisterInputActions()
    {
        _turnAction.performed += context => TurnInput = context.ReadValue<Vector2>();
        _turnAction.canceled += context => TurnInput = Vector2.zero;

        _jumpAction.performed += context => JumpTriggered = true;
        _jumpAction.canceled += context => JumpTriggered = false;

        _pauseAction.performed += context => OnPauseButtonClick?.Invoke();

        _jumpMobileAction.performed += context => JumpMobileTriggered = context.ReadValue<Vector2>();
        _jumpMobileAction.canceled += context => JumpMobileTriggered = Vector2.zero;
    }  
}
