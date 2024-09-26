using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ColorGrades
{
    [field: SerializeField] public Color Color;

    [SerializeField][Range(0, 1)] private float value;
    public float Value { get => value;}
}

public class WealthCheckerUI : MonoBehaviour
{
    [SerializeField] private ColorGrades[] _colorGrades;
    [SerializeField] private Image _fillArea;
    [SerializeField] private float _fillDuration;
    [SerializeField] private float _colorChangingDuration;
    [SerializeField] private TextMeshProUGUI _playerWealthState;
    [SerializeField] private TextMeshProUGUI _wealthText;


    public void UpdateWealthUI(int wealth, int maxWealth, PlayerState currentState)
    {
        float value = (float)wealth / maxWealth;
        print($"Value {value} wealth {wealth} maxWealth {maxWealth}");
        var color = GetColor(value);

        UpdateWealthText(wealth);
        UpdateBar(value, color);
        UpdateText(value, currentState, color);
    }
    private void UpdateWealthText(int value)
    {
        _wealthText.SetText(value.ToString());
    }
    private void UpdateBar(float value, Color color)
    {
        _fillArea.DOFillAmount(value, _fillDuration);
        _fillArea.DOColor(color, _colorChangingDuration);
    }

    private void UpdateText(float value, PlayerState currentState, Color color)
    {
        string textValue = "";

        switch (currentState)
        {
            case PlayerState.Idle:
                textValue = "Обычный";
                break;
            case PlayerState.Death:
                textValue = "Мертвец";
                break;
            case PlayerState.Poor:
                textValue = "Бедный";
                break;
            case PlayerState.Casual:
                textValue = "Казуал";
                break;
            case PlayerState.Middle:
                textValue = "Средняк";
                break;
            case PlayerState.Buisiness:
                textValue = "Бизнесмен";
                break;
            case PlayerState.Bling:
                textValue = "Блинг";
                break;
            case PlayerState.EndLevel:
                textValue = "Финальный";
                break;
            default:
                throw new Exception("Cant Find State");
        }

        _playerWealthState.SetText(textValue);
        _playerWealthState.DOColor(color, _colorChangingDuration);
    }

    private Color GetColor(float value)
    {
        for (int i = 0; i < _colorGrades.Length; i++)
        {
            if (value <= _colorGrades[i].Value)
            {
                return _colorGrades[i].Color;
            }
        }

        throw new Exception("Cant Find Color");
    }
}
