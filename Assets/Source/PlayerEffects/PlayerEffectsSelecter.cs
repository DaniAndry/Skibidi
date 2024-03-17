using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectsSelecter : MonoBehaviour
{
    [SerializeField] private List<PlayerEffectController> _playersEffects;

   private PlayerEffectController _playerEffectController;

    private void Start()
    {
        foreach (var playerEffect in _playersEffects)
        {
            if (playerEffect.enabled == true)
            {
                _playerEffectController = playerEffect;
            }
        }
    }

    public PlayerEffectController GetEffects()
    {
        return _playerEffectController;
    }
}
