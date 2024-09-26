using System;
using UnityEngine;

public class WealthChecker : MonoBehaviour
{
    [SerializeField] private int _initialWealth = 40;
    [SerializeField] private WealthCheckerUI _wealthCheckerUI;
    [SerializeField] private Player _player;
    public int Wealth { get; private set; }

    private void Start()
    {
        Wealth = _initialWealth;
        _wealthCheckerUI.UpdateWealthUI(Wealth, _player.MaxWealth, _player.CurrentState);
    }

    public void AddMoney(int value, int maxWealth, PlayerState currentState)
    {
        Wealth += value;
        _wealthCheckerUI.UpdateWealthUI(Wealth, maxWealth, currentState);
    }

    public void MultiplyMoney(int multiplyer)
    {
        if (multiplyer > 0)
        {
            Wealth *= multiplyer;
            _wealthCheckerUI.UpdateWealthUI(Wealth, _player.MaxWealth * 2, _player.CurrentState);
        }
        else
        {
            throw new Exception("Cant multiply wealth by negative number");
        }

    }
    //сюда бы я перенёс логику счёта монет из класса Player, чтобы не нарушать SRP =)

    //В проекте, как и в коде имеются косяки, моментами я даже харкодил, очень сильно сказывается усталость и "смазанность" взгляда. 24ч делать одно и тоже тяжело, но интересно))
}
