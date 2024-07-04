using System.Collections;
using UnityEngine;

public class ProtectCollectibleItem : OtherItem
{
    private bool _isActivated = true;
    private float _duration = 20;
    private WaitForSeconds _protectTime = new WaitForSeconds(1f);
    private Coroutine _protectCoroutine;
    private int _time;

    public override void Boost()
    {
        if (PlayerMoverView != null)
        {
            Delay = _duration + 1f;
            PlayerMoverView.Protect(_isActivated);
            _protectCoroutine = StartCoroutine(ProtectOnTime());
        }
    }

    private IEnumerator ProtectOnTime()
    {
        while (_time <= _duration)
        {
            _time += 1;
            Debug.Log(_time);

            if (_time == _duration)
            {
                _time = 0;
                Debug.Log(123);
                ProtectDisable();
                StopCoroutine(_protectCoroutine);
            }

            yield return _protectTime;
        }

    }

    private void ProtectDisable()
    {
        Debug.Log(55);
        PlayerMoverView.Protect(!_isActivated);
    }
}
