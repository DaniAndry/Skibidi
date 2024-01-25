using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private List<ItemView> _items = new List<ItemView>();

    public event Action ItemsClearedDueToMismatch;
    public event Action ItemsClearedDueToMatch;

    public void AddItem(ItemView newItem)
    {
        if (_items.Any() && _items.Any(item => item.Name != newItem.Name))
        {
            ActivationDeboost();
        }
        else
        {
            _items.Add(newItem);

            if (_items.Count == 3 && _items.All(item => item.Name == newItem.Name))
            {
                ActivationBoost();
            }
        }
    }

    private void ActivationBoost()
    {
        ClearPanel();
        ItemsClearedDueToMismatch?.Invoke();
    }

    private void ActivationDeboost()
    {
        ClearPanel();
        ItemsClearedDueToMatch?.Invoke();
    }

    private void ClearPanel()
    {
        foreach (var itemView in _items)
        {
            if (itemView != null)
            {
                Destroy(itemView.gameObject);
            }
        }

        _items.Clear();
    }
}
