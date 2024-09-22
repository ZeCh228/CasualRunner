using UnityEngine;


public class FinishZone : MonoBehaviour
{
   // public ParticleSystem ?finishParticles;  
    [SerializeField] private GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*if (finishParticles != null)
            {
                finishParticles.Play();
            }*/
        
            FinishGame();
        }
    }


    private void FinishGame()
    {
        Time.timeScale = 0f;
    }
}
