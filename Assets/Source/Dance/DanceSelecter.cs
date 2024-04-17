using System.Collections.Generic;
using System;
using UnityEngine;

public class DanceSelecter : MonoBehaviour
{
    [SerializeField] private Dance _firstDance;

    private List<Dance> _boughtDancing = new List<Dance>();
    private Dance _selectedDance;

    public PlayerView Player { get; private set; }

   // public event Action<PlayerView> OnChangingDance;

    private void Start()
    {
        _selectedDance = _firstDance;
        _firstDance.ChangeStatus();
        _firstDance.Unlock();
        AddDance(_firstDance);
    }

    public void Init(PlayerView view)
    {
        Player = view;
    }

    public void AddDance(Dance dance)
    {
        _boughtDancing.Add(dance);
    }

    public void SelectDance(Dance dance)
    {
        if (dance != _selectedDance)
        {
            _selectedDance.ChangeStatus();
            _selectedDance = dance;

            _selectedDance.ChangeStatus();
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
