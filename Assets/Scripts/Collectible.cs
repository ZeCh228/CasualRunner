using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] public int value;

 
    public abstract void ApplyEffect(Player player);

    public virtual void OnCollect() 
    {
        Destroy(gameObject);
    }


    protected virtual void PlayParticles()
    {
        // тут будут должны были быть партиклы
    }
}
