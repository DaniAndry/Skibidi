using System.Collections.Generic;
using UnityEngine;

public class DanceSelecter : MonoBehaviour
{
    [SerializeField] private Dance _firstDance;

    private List<Dance> _boughtDancing = new List<Dance>();
    private Dance _selectedDance;
    private ShopDancing _shopDancing;

    public Dance FirstDance => _firstDance;

    private void Start()
    {
        _shopDancing = GetComponent<ShopDancing>();

        _selectedDance = _firstDance;
        _firstDance.ChangeStatus();
        _firstDance.Unlock();
        AddDance(_firstDance);
        Invoke("AddFirstSkin", 0.1f);
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

    private void AddFirstSkin()
    {
        _shopDancing.Player.GetNameDance(_firstDance.NameDanceAnim);
    }
}