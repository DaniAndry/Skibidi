using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : Screen
{
    [SerializeField] private Slider _sound;

    private float _currentSoundValue = 1f;

    public event Action<float> ChangingSoundValue;

    private void Update()
    {
        if(_sound.value != _currentSoundValue)
        {
            _currentSoundValue = _sound.value;
            ChangingSoundValue(_currentSoundValue);
        }
    }
}
