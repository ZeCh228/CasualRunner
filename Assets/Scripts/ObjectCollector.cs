using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();  // Получаем ссылку на игрока
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, реализует ли объект интерфейс ICollectible
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();

        if (collectible != null)
        {
            collectible.ApplyEffect(_player);  // Применяем эффект объекта на игрока
            Destroy(other.gameObject);  // Уничтожаем объект после подбора
        }
    }
}
