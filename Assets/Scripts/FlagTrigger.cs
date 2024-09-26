using UnityEngine;
using DG.Tweening; 


public class FlagCheckpoint : MonoBehaviour
{
    public FlagData[] flags;
    public float animationDuration = 1f;
    private bool flagsRaised = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !flagsRaised)
        {
            RaiseFlags();
            flagsRaised = true;
        }
    }


    private void RaiseFlags()
    {
        foreach (FlagData flag in flags)
        {
            flag.Flag.DORotate(flag.EndRotation, animationDuration).SetEase(Ease.OutBounce);
        }
    }
}
