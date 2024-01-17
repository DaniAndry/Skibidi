using UnityEngine;

public class Bonus : MonoBehaviour
{
    private int _bonusCount;

    public Bonus(int bonus)
    {
        _bonusCount = bonus;
    }

    public int Activate()
    {
        return _bonusCount;
    }
}
