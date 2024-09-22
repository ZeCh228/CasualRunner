using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();  // �������� ������ �� ������
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��������� �� ������ ��������� ICollectible
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();

        if (collectible != null)
        {
            collectible.ApplyEffect(_player);  // ��������� ������ ������� �� ������
            Destroy(other.gameObject);  // ���������� ������ ����� �������
        }
    }
}
