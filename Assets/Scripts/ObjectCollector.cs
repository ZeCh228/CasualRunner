using UnityEngine;
using UnityEngine.Events;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UnityEvent<ICollectible> onCollectItem;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();

        if (collectible != null)
        {
            onCollectItem?.Invoke(collectible);
            collectible.ApplyEffect(_player);
            Destroy(other.gameObject);
            Debug.Log("я сломал");
        }
    }
}
