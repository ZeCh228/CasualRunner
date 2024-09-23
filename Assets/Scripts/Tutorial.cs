using DG.Tweening;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    [SerializeField] RectTransform _finger;
    [SerializeField] RectTransform _arrow;
    [SerializeField] float _duration;


    void Start()
    {
        float width = _arrow.rect.width;
        float height = _arrow.rect.height;
        print($"height {height} width {width}");

        Vector3 center = _arrow.anchoredPosition;
        print($"center {center} ");

        Vector3 leftPoint = new Vector3(center.x - width / 2, center.y, center.z);

        Vector3 rightPoint = new Vector3(center.x + width / 2, center.y, center.z);
        print($"leftPoint {leftPoint} rightPoint {rightPoint}");
        
        

        _finger.DOAnchorPos(new Vector2(leftPoint.x, _finger.anchoredPosition.y), _duration*2).OnComplete(() =>
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(_finger.DOAnchorPos(new Vector2(rightPoint.x, _finger.anchoredPosition.y), _duration)).SetEase(Ease.Linear);
            seq.Append(_finger.DOAnchorPos(new Vector2(leftPoint.x, _finger.anchoredPosition.y), _duration)).SetEase(Ease.Linear);
            seq.SetLoops(-1, LoopType.Yoyo);
        });
    }
}
 