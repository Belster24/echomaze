using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tweening : MonoBehaviour
{
    [SerializeField]float Y = 2f;
    [SerializeField] float duration = 1f;
    [SerializeField] float pauseDuration = 1f;

    private bool movingUp = true;
    Vector3 targetPositionUp;
    Vector3 targetPositionDown;
    private void Start()
    {
        targetPositionUp = transform.position + new Vector3(0f, Y, 0f);
        targetPositionDown = transform.position + new Vector3(0f, -Y, 0f);
        MoveUp();
       
    }

    private void MoveUp()
    {
        transform.DOMove(targetPositionUp, duration)
            .SetEase(Ease.Linear)
            .OnComplete(PauseAtTop);
    }

    private void MoveDown()
    {
        transform.DOMove(targetPositionDown, duration)
            .SetEase(Ease.Linear)
            .OnComplete(PauseAtBottom);
    }

    private void PauseAtTop()
    {
        if (movingUp)
        {
            movingUp = false;
            DOVirtual.DelayedCall(pauseDuration, MoveDown);
        }
    }

    private void PauseAtBottom()
    {
        if (!movingUp)
        {
            movingUp = true;
            DOVirtual.DelayedCall(pauseDuration, MoveUp);
        }


    }
}
