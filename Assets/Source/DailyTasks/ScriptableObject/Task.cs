using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Task", menuName = "Task", order = 51)]
public class Task : ScriptableObject
{
    [SerializeField] private string _descrition;
    [SerializeField] private int _amountMaxCollect;
    [SerializeField] private int _amountReward;
    [SerializeField] private Sprite _rewardIcon;
    [SerializeField] private string _rewardName;

    public int AmountMaxCollect => _amountMaxCollect;
    public Sprite RewardIcon => _rewardIcon;
    public string Description => _descrition;
    public string RewardName => _rewardName;
    public int AmountReward => _amountReward;
}
