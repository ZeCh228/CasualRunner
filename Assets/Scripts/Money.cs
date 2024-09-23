using UnityEngine;


public class Money : Collectible
{
    public override void ApplyEffect(Player player)
    {
        player.ModifyWealth(value);
        PlayParticles();
    }

    protected override void PlayParticles()
    {
        // тут будут должны были быть партиклы
    }
}
