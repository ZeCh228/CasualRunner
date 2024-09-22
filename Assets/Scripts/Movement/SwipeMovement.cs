using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class SwipeMovement : MonoBehaviour
{
    [SerializeField] private SplineFollower follower;
    [SerializeField] private float sensitivity = 0.01f;
    [SerializeField] private float maxOffsetX = 3f;
    [SerializeField] private float minOffsetX = -3f;
    [SerializeField] private float deathZone;
    [SerializeField] private Transform Player;
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 previousTouchPosition;
    private bool isTouching;

    [SerializeField] private float maxYAngle;
    [SerializeField] private float RotationDuration;
    [SerializeField] private float restoreRotationOffset;

    private bool previousDirectionIsLeft= false;
    private Tween rotation;
    private void Start()
    {
        if (follower == null)
        {
            follower = GetComponent<SplineFollower>();
        }
    }

   // private Vector3 previousTouchPosition; // для хранения предыдущей позиции касания

  /*  private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Проверяем, изменилось ли положение пальца
                if (touch.position != previousTouchPosition)
                {
                    rotation?.Kill();
                    rotation = Player.DOLocalRotate(new Vector3(0, 0, 0), RotationDuration);
                }

                Vector3 swipeVector = touch.position - previousTouchPosition;
                previousTouchPosition = touch.position;
                swipeVector.Normalize();

                follower.motion.offset = new Vector2(
                    Mathf.Clamp(follower.motion.offset.x + swipeVector.x * (sensitivity * Time.deltaTime), minOffsetX, maxOffsetX),
                    follower.motion.offset.y
                );

                if (swipeVector.x < 0)
                {
                    rotation?.Kill();
                    rotation = Player.DOLocalRotate(new Vector3(0, -maxYAngle, 0), RotationDuration);
                }
                else if (swipeVector.x > 0)
                {
                    rotation?.Kill();
                    rotation = Player.DOLocalRotate(new Vector3(0, maxYAngle, 0), RotationDuration);
                }

                previousDirectionIsLeft = swipeVector.x < 0;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                rotation?.Kill();
                rotation = Player.DOLocalRotate(new Vector3(0, 0, 0), RotationDuration);
            }
        }
    }*/

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 swipeVector = touch.position - previousTouchPosition;
                previousTouchPosition = touch.position;
                swipeVector.Normalize();
                follower.motion.offset = new Vector2(Mathf.Clamp(follower.motion.offset.x + swipeVector.x * (sensitivity * Time.deltaTime), minOffsetX, maxOffsetX), follower.motion.offset.y);

                if (swipeVector.x < 0)
                {
                    rotation?.Kill();
                    // follower.motion.rotationOffset = new Vector3(0, Mathf.Clamp(follower.motion.rotationOffset.y + -rotationSensivity*Time.deltaTime, -maxYAngle, maxYAngle), 0);

                    rotation = Player.DOLocalRotate(new Vector3(0, -maxYAngle, 0), RotationDuration).OnComplete(RestoreRotation);
                }
                else if (swipeVector.x > 0)
                {
                    rotation?.Kill();

                    //follower.motion.rotationOffset = new Vector3(0, Mathf.Clamp(follower.motion.rotationOffset.y + RotationDuration * Time.deltaTime, -maxYAngle, maxYAngle), 0);
                    rotation = Player.DOLocalRotate(new Vector3(0, maxYAngle, 0), RotationDuration)
                        .OnComplete(RestoreRotation);
                }

                previousDirectionIsLeft = swipeVector.x < 0 ? true : false;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                rotation?.Kill();
                RestoreRotation();
            }

        }


        void RestoreRotation()
        {
            rotation = Player.DOLocalRotate(new Vector3(0, 0, 0), RotationDuration);
        }
    }

  
    /* if (Input.touchCount > 0)
{
    Touch touch = Input.GetTouch(0);

    if (touch.phase == TouchPhase.Began)
    {
        isTouching = true;
        startTouchPosition = touch.position;

        float deltaX = (currentTouchPosition.x - startTouchPosition.x) * sensitivity;

        float newOffsetX = Mathf.Clamp(follower.motion.offset.x + deltaX, minOffsetX, maxOffsetX);

        follower.motion.offset = new Vector2(newOffsetX, follower.motion.offset.y);

        startTouchPosition = currentTouchPosition;
    }

    *//*            Touch touch = Input.GetTouch(0);

                isTouching = true;

                float deltaX = (touch.position.x - startTouchPosition.x)*//* < 0 ? -1 : 1*//* * sensitivity*//*;

                if (touch.phase == TouchPhase.Began)
                    startTouchPosition = touch.position;

                if (Mathf.Abs(deltaX) >= deathZone)
                {
                    float newOffsetX = Mathf.Clamp(touch.position.x > startTouchPosition.x ? 1 * sensitivity*Time.deltaTime : -1 * sensitivity * Time.deltaTime, minOffsetX, maxOffsetX);

                    follower.motion.offset += new Vector2(newOffsetX, follower.motion.offset.y);

                    print($"DeltaX {deltaX},  end position {newOffsetX}");
                    print($"IS LEFT {touch.position.x < startTouchPosition.x} IS RIGHT {touch.position.x > startTouchPosition.x}");
                }
    *//*

    startTouchPosition = touch.position;

    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
    {
        isTouching = false;
    }
}*/
}
