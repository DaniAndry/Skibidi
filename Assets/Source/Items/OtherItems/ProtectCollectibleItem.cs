using System.Collections;
using UnityEngine;

public class ProtectCollectibleItem : OtherItem
{
    private bool _isActivated = true;
    private int _duration = 5;

    public override void Boost()
    {
        if (PlayerMoverView != null)
        {
            Delay = _duration + 1f;
            PlayerMoverView.Protect(_isActivated);
            StartCoroutine(ProtectOnTime());
        }
    }

    private IEnumerator ProtectOnTime()
    {
        yield return new WaitForSeconds(_duration);

        ProtectDisable();
    }

    private void ProtectDisable()
    {
        PlayerMoverView.Protect(!_isActivated);
    }
}
