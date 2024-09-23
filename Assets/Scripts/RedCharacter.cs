using UnityEngine;


public class RedCharacter : Collectible
{
    public override void ApplyEffect(Player player)
    {
        player.ModifyWealth(-value);
        Debug.Log("Player hit a red character! Wealth decreased.");
        PlayParticles();
    }


    protected override void PlayParticles()
    {
        // тут будут должны были быть партиклы
    }
}