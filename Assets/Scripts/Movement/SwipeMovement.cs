using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;


public class SwipeMovement : MonoBehaviour
{

    [SerializeField] private float _maxYAngle;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private float _restoreRotationOffset;
    [SerializeField] private SplineFollower _follower;
    [SerializeField] private float _sensitivity = 0.01f;
    [SerializeField] private float _maxOffsetX = 3f;
    [SerializeField] private float _minOffsetX = -3f;
    [SerializeField] private float _deathZone;
    [SerializeField] private Transform _player;

    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private Vector2 _previousTouchPosition;
    private bool _isTouching;





    private bool previousDirectionIsLeft = false;
    private Tween rotation;

  


    private void Start()
    {
        if (_follower == null)
        {
            _follower = GetComponent<SplineFollower>();
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 swipeVector = touch.position - _previousTouchPosition;
                _previousTouchPosition = touch.position;
                swipeVector.Normalize();
                _follower.motion.offset = new Vector2(Mathf.Clamp(_follower.motion.offset.x + swipeVector.x * (_sensitivity * Time.deltaTime), _minOffsetX, _maxOffsetX), _follower.motion.offset.y);

                if (swipeVector.x < 0)
                {
                    rotation?.Kill();
                    // follower.motion.rotationOffset = new Vector3(0, Mathf.Clamp(follower.motion.rotationOffset.y + -rotationSensivity*Time.deltaTime, -maxYAngle, maxYAngle), 0);

                    rotation = _player.DOLocalRotate(new Vector3(0, -_maxYAngle, 0), _rotationDuration).OnComplete(RestoreRotation);
                }
                else if (swipeVector.x > 0)
                {
                    rotation?.Kill();

                    //follower.motion.rotationOffset = new Vector3(0, Mathf.Clamp(follower.motion.rotationOffset.y + RotationDuration * Time.deltaTime, -maxYAngle, maxYAngle), 0);
                    rotation = _player.DOLocalRotate(new Vector3(0, _maxYAngle, 0), _rotationDuration)
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
            rotation = _player.DOLocalRotate(new Vector3(0, 0, 0), _rotationDuration);
        }
    }
}
//Я чё, правда пишу развороты с помощью дотвина.....