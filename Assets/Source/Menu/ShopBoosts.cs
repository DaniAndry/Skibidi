using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBoosts : MonoBehaviour
{
    [SerializeField] private List<Button> _boostCards;
    [SerializeField] private Bank _bank;

    private Boost _currentBoost;

    private void OnEnable()
    {
        foreach (Button button in _boostCards)
        {
            button.onClick.AddListener(() => Buy(button.GetComponentInParent<BoostBuyButton>()));
        }
    }

    private void OnDisable()
    {
        foreach (Button button in _boostCards)
        {
            button.onClick.RemoveListener(() => Buy(button.GetComponentInParent<BoostBuyButton>()));
        }
    }

    private void Buy(BoostBuyButton _boost)
    {
        _currentBoost = _boost.GetBoost();

        if (_bank.TryTakeMoney(_boost.Price))
            _currentBoost.Increase();
        else
            Debug.Log("Error Buy Boost");
    }
}
