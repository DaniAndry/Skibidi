using System.Collections;
using UnityEngine;

public class ProtectCollectibleItem : OtherItem
{
    private bool _isActivated = false;
    private float _duration = 7;
    private WaitForSeconds _protectTime = new WaitForSeconds(1f);
    private Coroutine _protectCoroutine;
    private float _time;

    public override void Boost()
    {
        if (PlayerMoverView != null)
        {
            _time = _duration;
            _isActivated = true;
            Delay = _duration + 1f;
            PlayerMoverView.Protect(_isActivated);
            _protectCoroutine = StartCoroutine(ProtectOnTime());
        }
    }

    private IEnumerator ProtectOnTime()
    {
        while (_isActivated)
        {
            _time--;

            if (_time > 0)
            {
                Debug.Log(_time);
            }
            else
            {
                Debug.Log(123);
                _time = _duration;
                ProtectDisable();
                _isActivated = false;
            }

            yield return _protectTime;
        }
    }

    private void ProtectDisable()
    {
        PlayerMoverView.Protect(!_isActivated);
    }
}
