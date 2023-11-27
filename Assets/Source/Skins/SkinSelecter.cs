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

    private void OnDisable()
    {
        foreach (var skin in _boughtSkins)
        {
            skin.OnSelected -= SelectSkin;
        }
    }

    public void AddSkin(Skin skin)
    {
        _boughtSkins.Add(skin);
        SelectSkin(skin);
        skin.OnSelected += SelectSkin;
    }

    private void SelectSkin(Skin skin)
    {
        Debug.Log(skin);
        if (skin != _selectedSkin)
        {
            Debug.Log(_selectedSkin.ToString());
            _selectedSkin.ChangeStatus();
            _selectedSkin = skin;

            _selectedSkin.ChangeStatus();
            InitSkin();
            Debug.Log(_selectedSkin.ToString());
        }
    }

    private void InitSkin()
    {
        Player = _selectedSkin.GetView();
        OnChangingSkin?.Invoke(Player);

        foreach (Skin skin in _boughtSkins)
        {
            if (!skin.IsSelected)
            {
                skin.TurnOffSkin();
            }
        }
    }

    private void SaveData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
    }

    private void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
    }
}
