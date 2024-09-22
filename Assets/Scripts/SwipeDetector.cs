using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 previousTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 swipeVector;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousTouchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPosition = touch.position;

                swipeVector = currentTouchPosition - previousTouchPosition;

                previousTouchPosition = currentTouchPosition;
            }
        }
    }
}

