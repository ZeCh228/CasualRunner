/*using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public Vector2 previousTouchPosition;
    public Vector2 currentTouchPosition;
    public Vector2 swipeVector;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

*//*            if (touch.phase == TouchPhase.Began)
            {
                previousTouchPosition = touch.position;
            }*//*

            if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPosition = touch.position;

                swipeVector = currentTouchPosition - previousTouchPosition;

                previousTouchPosition = currentTouchPosition;
            }
        }
    }
}

*/