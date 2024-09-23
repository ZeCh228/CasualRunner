using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIMANAGER : MonoBehaviour
{
    [SerializeField] private TMP_Text _wealthText;
    [SerializeField] private Player _player;


    private void Start()
    {
        _player.OnWealthChanged += UpdateWealthUI;
    }


    public void UpdateWealthUI(int wealth)
    {
        _wealthText.text = Mathf.Max(wealth, 0).ToString();
    }


    private void OnDestroy()
    {
        _player.OnWealthChanged -= UpdateWealthUI;
    }
}

