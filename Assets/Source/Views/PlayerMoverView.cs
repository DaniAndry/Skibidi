using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoverView : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private CameraMover _cameraMover;

    public event Action<float> OnMove;
    public event Action<float> ChangeSpeedCrash;
    public event Action<float> ChangeSpeedBoost;
    public event Action UpdateMover;

    private void Update()
    {
        DecktopContorol();
        /*   MobileContorol();*/
        UpdateMover?.Invoke();
    }

    public void TakeSpeed(float count)
    {
        ChangeSpeedBoost?.Invoke(count);
    }

    public void Crash()
    {
        float moveSpeed = 2;
        ChangeSpeedCrash?.Invoke(moveSpeed);
    }

    public void SetSpeed(float speed)
    {
        _speed.text = Convert.ToInt32(speed).ToString();
    }

    public void StartGame()
    {
        _cameraMover.enabled = true;
    }

    private void DecktopContorol()
    {
        if (Input.GetKey(KeyCode.A))
            OnMove?.Invoke(-1);
        else if (Input.GetKey(KeyCode.D) || _joystick.Horizontal > 0)
            OnMove?.Invoke(1);
        else
            OnMove?.Invoke(0);
    }

    private void MobileContorol()
    {
        if (_joystick.Horizontal < 0f && _joystick.Horizontal > -1)
            OnMove?.Invoke(-1);
        else if (_joystick.Horizontal > 0f && _joystick.Horizontal < 1)
            OnMove?.Invoke(1);
        else
            OnMove?.Invoke(0);
    }
}
