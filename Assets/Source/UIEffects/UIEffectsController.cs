using System.Collections.Generic;
using UnityEngine;

public class UIEffectsController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _buyEffect;
    [SerializeField] private ParticleSystem _upgradeEffect;
    [SerializeField] private Bank _bank;

    private void OnEnable()
    {
        _bank.OnBuy += BuyEffect;

    }

    private void OnDisable()
    {
        _bank.OnBuy -= BuyEffect;
    }


    private void BuyEffect()
    {
        _buyEffect.Play();
    }

    private void UpgradeEffect()
    {
        _upgradeEffect.Play();
    }
}
