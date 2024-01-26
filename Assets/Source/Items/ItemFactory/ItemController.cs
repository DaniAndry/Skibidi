using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private List<ItemView> _items = new List<ItemView>();

    public event Action ItemsClearedDueToMismatch;
    public event Action ItemsClearedDueToMatch;

    public void AddItem(ItemView newItem, OtherItem otherItem)
    {
        if (_items.Any() && _items.Any(existingItem => existingItem.Name != newItem.Name))
        {
            ActivationDeboost(otherItem);
        }
        else
        {
            _items.Add(newItem);

            if (_items.Count == 3 && _items.All(existingItem => existingItem.Name == newItem.Name))
            {
                ActivationBoost(otherItem);
            }
        }
    }

    private void ActivationBoost(OtherItem otherItem)
    {
        ClearPanel();
        ItemsClearedDueToMatch?.Invoke();
        otherItem.Boost();
    }

    private void ActivationDeboost(OtherItem otherItem)
    {
        ClearPanel();
        ItemsClearedDueToMismatch?.Invoke();
        otherItem.DeBoost();
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
