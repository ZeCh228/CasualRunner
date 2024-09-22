using UnityEngine;
using Dreamteck.Splines;

public class SwipeMovement : MonoBehaviour
{
    [SerializeField] private SplineFollower follower;  
    [SerializeField] private float sensitivity = 0.01f;  
    [SerializeField] private float maxOffsetX = 3f;
    [SerializeField] private float minOffsetX = -3f;

    private Vector2 startTouchPosition; 
    private Vector2 currentTouchPosition;   
    [SerializeField]  private bool isTouching;

    void Start()
    {
        if (follower == null)
        {
            follower = GetComponent<SplineFollower>();
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                startTouchPosition = touch.position; 
            }

            if (touch.phase == TouchPhase.Moved && isTouching)
            {
                currentTouchPosition = touch.position;

                float deltaX = (currentTouchPosition.x - startTouchPosition.x) * sensitivity;

                float newOffsetX = Mathf.Clamp(follower.motion.offset.x + deltaX, minOffsetX, maxOffsetX);

                follower.motion.offset = new Vector2(newOffsetX, follower.motion.offset.y);

                startTouchPosition = currentTouchPosition;
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }
    }
}
