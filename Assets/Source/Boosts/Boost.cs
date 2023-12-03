using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField] private float _bonus;
    [SerializeField] private float _time;

    private Button _button;
    private int _count;

    public int Count => _count;
    public float Bonus => _bonus;
    public float Time => _time;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public bool TryUse()
    {
        bool _canUse = _count > 0;

        if (_canUse)
            Decrease();

        return _canUse;
    }

    public void Increase()
    {
        _count++;
    }

    public void Decrease()
    {
        _count--;
    }
}
