using System;
using System.Collections.Generic;
using UnityEngine;
using YG;


public class SkinSelecter : MonoBehaviour
{
    [SerializeField] private Skin _firstSkin;

    private List<Skin> _boughtSkins = new List<Skin>();
    private Skin _selectedSkin;

    public PlayerView Player { get; private set; }

    public event Action<PlayerView> OnChangingSkin;

    private void Start()
    {
        Load();
    }

    public void AddSkin(Skin skin)
    {
        if (_boughtSkins.Contains(skin) == false)
        {
            _boughtSkins.Add(skin);
        }
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

        Save();
    }

    private void Load()
    {
        foreach (var skin in YandexGame.savesData.BoughtSkins)
        {
            _boughtSkins.Add(skin);
        }

        _selectedSkin = YandexGame.savesData.SelectedSkin;

        if (_boughtSkins.Count == 0)
        {
            _selectedSkin = _firstSkin;
            _selectedSkin.ChangeStatus();
            _selectedSkin.Unlock();
            AddSkin(_selectedSkin);
            InitSkin();
        }
        else
        {
            foreach (Skin skin in _boughtSkins)
            {
                skin.LoadProgress(false, true);

                if (skin == _selectedSkin)
                    skin.LoadProgress(true, true);
            }
        }

        if (_selectedSkin == null)
        {
            _selectedSkin = _firstSkin;
            _selectedSkin.ChangeStatus();
            _firstSkin.Unlock();
        }

        InitSkin();
    }

    private void Save()
    {
        YandexGame.savesData.BoughtSkins = _boughtSkins;
        YandexGame.savesData.SelectedSkin = _selectedSkin;
        YandexGame.SaveProgress();
    }
}
