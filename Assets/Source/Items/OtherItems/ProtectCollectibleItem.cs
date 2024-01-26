using System.Collections;
using UnityEngine;

public class ProtectCollectibleItem : OtherItem
{
    private bool _isActivated = true;
    private int _duration = 5;

    public override void Boost()
    {
        PlayerMoverView.Protect(_isActivated);
    }

    public override void DeBoost()
    {
        PlayerMoverView.Protect(!_isActivated);
    }

    private IEnumerator ProtectOnTime()
    {
        yield return new WaitForSeconds(_duration);

        DeBoost();
    }
}
