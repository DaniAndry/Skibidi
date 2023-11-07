using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsModel
{
    public void ChangeSound(float value)
    {
        AudioListener.volume = value;
    }
}
