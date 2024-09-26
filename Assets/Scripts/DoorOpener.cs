using UnityEngine;
using DG.Tweening;

public class DoorOpener : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public Vector3 leftDoorOpenRotation = new Vector3(0, -90, 0);
    public Vector3 rightDoorOpenRotation = new Vector3(0, 90, 0);
    public float openDuration = 1f;
    private bool doorsOpened = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !doorsOpened)
        {
            OpenDoors();
            doorsOpened = true;
        }
    }


    private void OpenDoors()
    {
        leftDoor.DORotate(leftDoorOpenRotation, openDuration).SetEase(Ease.OutQuad);
        rightDoor.DORotate(rightDoorOpenRotation, openDuration).SetEase(Ease.OutQuad);
    }
}
