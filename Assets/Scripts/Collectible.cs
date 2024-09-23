using UnityEngine;

public abstract class Collectible : MonoBehaviour, ICollectible
{
    [SerializeField] public string name;
    [SerializeField] public int value;

 
    public abstract void ApplyEffect(Player player);


    protected virtual void Update()
    {
        RotateObject();
    }

 
    private void RotateObject()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }


    protected virtual void PlayParticles()
    {
        // тут будут должны были быть партиклы
    }
}
