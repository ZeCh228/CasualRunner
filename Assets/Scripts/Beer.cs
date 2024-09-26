using UnityEngine;


public class Beer : Collectible
{
    public override void ApplyEffect(Player player)
    {
        player.ModifyWealth(-value);
        PlayParticles();
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }

    protected override void PlayParticles()
    {
        // тут будут должны были быть партиклы  
    }
}
