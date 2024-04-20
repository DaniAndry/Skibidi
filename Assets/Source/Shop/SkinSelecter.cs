using System;
using System.Collections.Generic;
using UnityEngine;


public class SkinSelecter : MonoBehaviour
{
    [SerializeField] private Skin _firstSkin;

    private List<Skin> _boughtSkins = new List<Skin>();
    private Skin _selectedSkin;

    public PlayerView Player { get; private set; }

    public event Action<PlayerView> OnChangingSkin;

    private void Start()
    {
        _selectedSkin = _firstSkin;
        _firstSkin.ChangeStatus();
        _firstSkin.Unlock();
        AddSkin(_firstSkin);
        InitSkin();
    }

    public void AddSkin(Skin skin)
    {
        _boughtSkins.Add(skin);
    }

    public void SelectSkin(Skin skin)
    {
        if (skin != _selectedSkin)
        {
            _selectedSkin.ChangeStatus();
            _selectedSkin = skin;

            _selectedSkin.ChangeStatus();
            InitSkin();
        }
    }

    private void InitSkin()
    {
        foreach (Skin skin in _boughtSkins)
        {
            if (skin.IsSelected == false)
            {
                skin.TurnOffSkin();
            }
        }

        Player = _selectedSkin.GetView();
        OnChangingSkin?.Invoke(Player);
    }
}
