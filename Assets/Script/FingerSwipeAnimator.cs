using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FingerSwipeAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform finger;

    [SerializeField] private Vector3 initialScale;
    private float minXPos;
    private float maxXPos;
    private WaitForSeconds waitFor1Seconds;

    private void Awake()
    {
        waitFor1Seconds = new WaitForSeconds(1);
    }

    private void OnEnable()
    {
        finger.localPosition = new Vector3(0, finger.localPosition.y, 0);
        SetInitialFingerScale();
        CalculateMinMaxPositions();
        StartFingerAnimation();
    }

    private void SetInitialFingerScale()
    {
        finger.localScale = initialScale;
    }

    private void CalculateMinMaxPositions()
    {
        minXPos = -((arrow.rect.width / 2) - (finger.rect.width / 3));
        maxXPos = ((arrow.rect.width / 2) - (finger.rect.width / 6));
    }

    private void StartFingerAnimation()
    {
        finger.DOScale(Vector3.one, 0.5f)
            .OnComplete(StartFingerMovement);
    }

    private void StartFingerMovement()
    {
        finger.DOLocalMoveX(minXPos, 1f).OnComplete(StartContinuousFingerMovement);
    }

    private void StartContinuousFingerMovement()
    {
        StartCoroutine(FingerMove());
    }

    private IEnumerator FingerMove()
    {
        while (true)
        {
            finger.DOLocalMoveX(maxXPos, 1f);
            yield return waitFor1Seconds;
            finger.DOLocalMoveX(minXPos, 1f);
            yield return waitFor1Seconds;
        }
    }
}
