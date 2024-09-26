using UnityEngine;

public class Doorway : Collectible
{
    public override void ApplyEffect(Player player)
    {
        player.ModifyWealth(value);
        PlayParticles();
    }
      

    public override void OnCollect()
    {
      Destroy(this.transform.parent.gameObject);
    }


    protected override void PlayParticles()
    {
        // тут будут должны были быть партиклы
    }
}
