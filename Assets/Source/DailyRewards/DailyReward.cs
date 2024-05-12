public class DailyReward
{
    private int _amount;
    private int _index;
    private bool _isUnlock;
    private bool _isUnbox;

    public int Amount => _amount;
    public int Index => _index;
    public bool IsUnlock => _isUnlock;
    public bool IsUnbox => _isUnbox;

    public DailyReward(int amount, bool isUnlock, bool isUnbox, int index)
    {
        _amount = amount;
        _isUnlock = isUnlock;
        _isUnbox = isUnbox;
        _index = index;
    }
}