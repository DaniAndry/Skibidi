using UnityEngine;

public class ShopBoosts : MonoBehaviour
{
    [SerializeField] private Bank _bank;

    public void Buy(Boost boost, int price)
    {
        if (_bank.TryTakeValue(price))
        {
            _bank.TakeMoney(price);
            boost.Increase();
        }
        else
            Debug.Log("Error Buy Boost");
    }

    public void BuyUpgrade(Boost boost, int price)
    {
        if (_bank.TryTakeValue(price))
        {
            _bank.TakeMoney(price);
            boost.Upgrade();
        }
        else
            Debug.Log("Error Buy Boost");
    }
}
