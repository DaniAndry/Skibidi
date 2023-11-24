using System;
using TMPro;
using UnityEngine;

public class PlayerMoverView : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private CameraMover _cameraMover;

    public event Action<float> OnMoving;
    public event Action<float> ChangingSpeedCrash;
    public event Action<float> ChangingSpeedBoost;

    private void Update()
    {
        DecktopContorol();
        /*   MobileContorol();*/
    }

    private void OnEnable()
    {
        _cameraMover.GetPlayerTransform(transform);
    }

    public void TakeSpeed(float count)
    {
        ChangingSpeedBoost?.Invoke(count);
    }

    public void Crash()
    {
        float moveSpeed = 2;
        ChangingSpeedCrash?.Invoke(moveSpeed);
    }

    public void SetSpeed(float speed)
    {
        _speed.text = Convert.ToInt32(speed).ToString();
    }

    public void StartGame()
    {
        _cameraMover?.StartMove();
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

    public void EndGame()
    {
        _cameraMover?.EndMove();
    }
}
