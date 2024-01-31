using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    ProtectBoost,
    SpeedBoost,
    EnergyBoost,
    EnergyDeboost,
    CoinBoost,
    CoinDeboost,
    Deboost
}

public class PlayerEffectController : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _effects;

    private PlayerView _view;
    private PlayerMoverView _viewMover;
    private EffectType _effectType;

    private Dictionary<EffectType, ParticleSystem> _effectsDictionary = new Dictionary<EffectType, ParticleSystem>();

    private void OnDisable()
    {
        _viewMover.OnProtected -= ProtectBoostEffect;
        _viewMover.OnChangingSpeed -= SpeedBoostEffect;

    }

    public void Init(PlayerMoverView playerMoverView, PlayerView playerView)
    {
        _view = playerView;
        _viewMover = playerMoverView;

        for (int i = 0; i < _effects.Count; i++)
        {
            _effectsDictionary.Add((EffectType)i, _effects[i]);
        }

        _viewMover.OnProtected += ProtectBoostEffect;
        _viewMover.OnChangingSpeed += SpeedBoostEffect;
        _view.EnergyChanging += EnergyBoostEffect;
        _view.OnMoneyChanging += CoinBoostEffect;
    }

    private void PlayEffect()
    {
        if (_effectsDictionary.TryGetValue(_effectType, out var effect))
        {
            effect.Play();
        }
    }

    private void StopEffect()
    {
        if (_effectsDictionary.TryGetValue(_effectType, out var effect))
        {
            effect.Stop();
        }
    }

    private void ProtectBoostEffect(bool isProtect)
    {
        _effectType = EffectType.ProtectBoost;

        if (isProtect)
        {
            PlayEffect();
        }
        else if (!isProtect)
        {
            StopEffect();
        }
    }

    private void SpeedBoostEffect(float speed)
    {
        _effectType = EffectType.SpeedBoost;

        if (IsBoost(speed))
        {
            PlayEffect();
        }
        else
        {
            StopEffect();
        }
    }

    private void EnergyBoostEffect(float count)
    {
        if (IsBoost(count))
        {
            _effectType = EffectType.EnergyBoost;
            PlayEffect();
        }
        else
        {
            EnergyDeboostEffect();
        }
    }

    private void EnergyDeboostEffect()
    {
        _effectType = EffectType.EnergyDeboost;
        PlayEffect();
    }

    private void CoinBoostEffect(float count, bool isBoost)
    {
        if (IsBoost(count) && isBoost)
        {
            _effectType = EffectType.CoinBoost;
            PlayEffect();
        }
        else if (isBoost)
        {
            CoinDeboostEffect();
        }
    }

    private void CoinDeboostEffect()
    {
        _effectType = EffectType.CoinDeboost;
        PlayEffect();
    }

    private bool IsBoost(float count)
    {
        return count > 20;
    }
}
