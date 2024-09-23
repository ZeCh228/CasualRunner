using UnityEngine;


public class Beer : Collectible
{
    public override void ApplyEffect(Player player)
    {
        player.ModifyWealth(-value);
        PlayParticles();
    }


    protected override void PlayParticles()
    {
        // тут будут должны были быть партиклы  
    }
}
