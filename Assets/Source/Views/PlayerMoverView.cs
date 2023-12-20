using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoverView : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private CameraMover _cameraMover;

    public event Action<float> OnMoving;
    public event Action<float> ChangingSpeedCrash;
    public event Action<float> ChangingSpeedBoost;
    public event Action OnStarted;
    public event Action OnStoped;

    private void Update()
    {
        DecktopContorol();
        /*   MobileContorol();*/
    }

    private void OnEnable()
    {
        _cameraMover.GetPlayerTransform(transform);
    }

    private void DecktopContorol()
    {
        if (Input.GetKey(KeyCode.A))
            OnMoving?.Invoke(-1);
        else if (Input.GetKey(KeyCode.D) || _joystick.Horizontal > 0)
            OnMoving?.Invoke(1);
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

    public void ChangeSpeed(float count)
    {
        ChangingSpeedBoost?.Invoke(count);
    }

    public void Crash()
    {
        float moveSpeed = 2;
        ChangingSpeedCrash?.Invoke(moveSpeed);
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
}
