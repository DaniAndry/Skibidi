using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _sound;

    private float _currentSoundValue = 1f;

    private void Update()
    {
        if(_sound.value != _currentSoundValue)
        {
            ChangeSound();
        }
    }

    private void ChangeSound()
    {
        _currentSoundValue = _sound.value;
        AudioListener.volume = _currentSoundValue;
    }
}
