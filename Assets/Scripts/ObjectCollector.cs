using UnityEngine;
using UnityEngine.Events;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UnityEvent<Collectible> _onCollectItem;


    private void Start()
    {
        _player = GetComponent<Player>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.gameObject.GetComponent<Collectible>();

        if (collectible != null)
        {
            _onCollectItem?.Invoke(collectible);
            collectible.ApplyEffect(_player);
            collectible.OnCollect();
        } 
    }
}
