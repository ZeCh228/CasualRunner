using UnityEngine;
using UnityEngine.EventSystems;

public class CheckFirstTouch : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _HudUI;
    [SerializeField] private GameObject _MenuUI;
    [SerializeField] private GameObject _playerStateCanvas;

    public void OnPointerClick(PointerEventData eventData)
    {
        _player.OnFirstTouch();
        _MenuUI.SetActive(false);
        _HudUI.SetActive(true);
        _playerStateCanvas.SetActive(true);

    }
}

