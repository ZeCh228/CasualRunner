using UnityEngine;

public class WealthMultipl : MonoBehaviour
{
    [SerializeField] private int multiplayer; 
    [SerializeField] private WealthChecker _wealthChecker; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _wealthChecker.MultiplyMoney(multiplayer);
            Debug.Log("я вошёл");
        }        
    }
}
