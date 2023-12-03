using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _distance;
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private HudWindow _headUpDisplay;
    [SerializeField] private Menu _menu;
    [SerializeField] private EndGameScreen _endScreen;
    [SerializeField] private List<Button> _boosts;

    public event Action<float> EnergyChanging;
    public event Action<EnergyBoost> DistanceBoostChanging;

    private void OnEnable()
    {
        foreach (Button button in _boosts)
        {
            button.onClick.AddListener(() => DefineBoost(button.GetComponent<Boost>()));
        }
    }

    private void OnDisable()
    {
        foreach (Button button in _boosts)
        {
            button.onClick.RemoveListener(() => DefineBoost(button.GetComponent<Boost>()));
        }
    }

    private void DefineBoost(Boost boost)
    {
        EnergyBoost distanceBoost = boost.GetComponent<EnergyBoost>();

        if (distanceBoost)
            UseDistanceBoost(distanceBoost);
    }

    private void UseDistanceBoost(EnergyBoost energyBoost)
    {
        if (energyBoost.TryUse())
            DistanceBoostChanging?.Invoke(energyBoost);
        else
            Debug.Log("ErrorUseBoost");
    }

    public void StartGame()
    {
        _headUpDisplay.Open();
    }

    public void EndGame(float distance)
    {
        _headUpDisplay.Close();
        _menu.SetDistance(distance);
        _endScreen.OpenEndScreen();
        _endScreen.SetData(distance);
    }

    public void OnEnergyChanged(float energyAmount)
    {
        EnergyChanging?.Invoke(energyAmount);
    }

    public void SetDistance(float distance)
    {
        _distance.text = $"{Convert.ToInt32(distance)}";
    }

    public void SetEnergy(float energyAmount)
    {
        _energy.text = $"{Convert.ToInt32(energyAmount)}";
    }
}
