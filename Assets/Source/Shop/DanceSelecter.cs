using System.Collections.Generic;
using UnityEngine;

public class DanceSelecter : MonoBehaviour
{
    [SerializeField] private Dance _firstDance;

    private List<Dance> _boughtDancing = new List<Dance>();
    private Dance _selectedDance;
    private ShopDancing _shopDancing;

    private void Start()
    {
        _shopDancing = GetComponent<ShopDancing>();

        _selectedDance = _firstDance;
        _firstDance.Unlock();
        AddDance(_firstDance);

        Invoke("AddFirstDance", 0.1f);
    }

    public void AddDance(Dance dance)
    {
        _boughtDancing.Add(dance);
    }
     
    public void SelectDance(Dance dance)
    {
        if (dance != _selectedDance)
        {
            if (dance != null)
            {
                _selectedDance.ChangeStatus();
                _selectedDance = dance;
                _selectedDance.ChangeStatus();
            }

            _shopDancing.Player.GetNameDance(_selectedDance.NameDanceAnim);
        }
    }

    private void AddFirstDance()
    {
        _shopDancing.Player.GetNameDance(_firstDance.NameDanceAnim);
    }
}