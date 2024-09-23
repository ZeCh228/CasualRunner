using UnityEngine;
using UnityEngine.Events;


public class FinishZone : MonoBehaviour
{  
    [SerializeField] private GameObject _player;
    [SerializeField] private UnityEvent _OnVictory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            FinishGame();
        }
    }


    private void FinishGame()
    {
        _player.GetComponent<Player>().SetState(PlayerState.EndLevel);
        _OnVictory?.Invoke();
    }
}
