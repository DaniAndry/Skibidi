using System.Collections.Generic;
using UnityEngine;
using YG;

public class DanceSelecter : MonoBehaviour
{
    [SerializeField] private Dance _firstDance;

    private List<Dance> _boughtDances = new List<Dance>();
    private Dance _selectedDance;
    private ShopDancing _shopDancing;

    private void Start()
    {
        _shopDancing = GetComponent<ShopDancing>();
        Load();
    }

    public void AddDance(Dance dance)
    {
        _boughtDances.Add(dance);
    }
     
    public void SelectDance(Dance dance)
    {
        if (dance != _selectedDance)
        {
            _selectedDance.ChangeStatus();
            _selectedDance = dance;
            _selectedDance.ChangeStatus();

            ChooseDance();
        }
    }

    public void ChooseDance()
    {
        _shopDancing.Player.GetNameDance(_selectedDance.NameDanceAnim);
        Save();
    }

    private void Load()
    {
        foreach (var dance in YandexGame.savesData.BoughtDances)
        {
            _boughtDances.Add(dance);
        }

        _selectedDance = YandexGame.savesData.SelectedDance;

        if (_boughtDances.Count == 0)
        {
            _selectedDance = _firstDance;
            _firstDance.ChangeStatus();
            _firstDance.Unlock();
            AddDance(_firstDance);
            Invoke("ChooseDance", 0.1f);
        }
        else
        {
            foreach (Dance dance in _boughtDances)
            {
                dance.LoadProgress(false, true);

                if (dance == _selectedDance)
                    dance.LoadProgress(true, true);
            }
        }

        if (_selectedDance == null)
        {
            _selectedDance = _firstDance;
            _selectedDance.ChangeStatus();
            _firstDance.Unlock();
        }

        Invoke("ChooseDance", 0.1f);
    }

    private void Save()
    {
        YandexGame.savesData.BoughtDances = _boughtDances;
        YandexGame.savesData.SelectedDance = _selectedDance;
        YandexGame.SaveProgress();
    }
}