using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsShopView : Screen
{
    [SerializeField] private PlayerView _firstPlayer;

    private List<PlayerView> _players = new List<PlayerView>();

    public event Action<PlayerView> ChangingSkin;

    private void Awake()
    {
        _players.Add(_firstPlayer);
        _firstPlayer.gameObject.SetActive(true);

        ChangingSkin?.Invoke(_firstPlayer);
    }

    public void SelectSkin(PlayerView player)
    {
        ChangingSkin?.Invoke(player);

        if(_players.Contains(player) == false)
            _players.Add(player);

        foreach (PlayerView playerView in _players)
        {
            playerView.gameObject.SetActive(false); 
        }

        player.gameObject.SetActive(true);
    }
}
