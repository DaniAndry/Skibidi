using UnityEngine;

public class BoostBuyButton : MonoBehaviour
{
    [SerializeField] private Boost _boost;
    [SerializeField] private int _price;

    public int Price => _price;

    public Boost GetBoost()
    {
        return _boost;
    }
}
