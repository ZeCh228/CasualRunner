using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;
using System.Collections;

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
  
    
    private bool previousDirectionIsLeft = false;
    private Tween rotation;
    private void Start()
    {
        if (follower == null)
        {
            follower = GetComponent<SplineFollower>();
        }
    }





    private Coroutine rotationCoroutine;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 swipeVector = touch.position - previousTouchPosition;
                previousTouchPosition = touch.position;
                swipeVector.Normalize();

                // Обновляем offset по оси X
                follower.motion.offset = new Vector2(
                    Mathf.Clamp(follower.motion.offset.x + swipeVector.x * (sensitivity * Time.deltaTime), minOffsetX, maxOffsetX),
                    follower.motion.offset.y
                );

                // Поворот влево или вправо
                if (swipeVector.x < 0)
                {
                    StartRotation(-maxYAngle); // Поворот влево
                }
                else if (swipeVector.x > 0)
                {
                    StartRotation(maxYAngle); // Поворот вправо
                }

                previousDirectionIsLeft = swipeVector.x < 0;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                RestoreRotation(); // Возвращаем в исходное положение
            }
        }
    }

    // Метод для начала плавного поворота
    private void StartRotation(float targetAngle)
    {
        // Если есть активная корутина поворота, останавливаем её
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }

        // Запускаем новую корутину для поворота
        rotationCoroutine = StartCoroutine(RotateToAngle(targetAngle));
    }

    // Корутина для плавного поворота к указанному углу
    private IEnumerator RotateToAngle(float targetAngle)
    {
        float currentAngle = Player.localEulerAngles.y;
        float timeElapsed = 0f;

        while (timeElapsed < RotationDuration)
        {
            timeElapsed += Time.deltaTime;
            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, timeElapsed / RotationDuration);
            Player.localEulerAngles = new Vector3(0, newAngle, 0);
            yield return null;
        }

        Player.localEulerAngles = new Vector3(0, targetAngle, 0); // Устанавливаем конечный угол точно
    }

    // Метод для восстановления вращения в исходное положение (0)
    private void RestoreRotation()
    {
        StartRotation(0); // Возвращаемся в исходное положение
    }











    /* private void Update()
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
     }*/
}
