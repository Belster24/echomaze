using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenBackAndForth : MonoBehaviour
{
    public Vector2 moveDistance = new Vector2(1f, 1f); // Distance to move in each axis
    public float tweenDuration = 1f; // Duration of each tween
    public Ease easeType = Ease.Linear; // Type of easing to use

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        StartTween();
    }

    private void StartTween()
    {
        // Tween the object back and forth in the x axis
        transform.DOMoveX(initialPosition.x + moveDistance.x, tweenDuration)
            .SetEase(easeType)
            .OnComplete(() => ReverseTweenX());

        // Tween the object back and forth in the y axis
        transform.DOMoveY(initialPosition.y + moveDistance.y, tweenDuration)
            .SetEase(easeType)
            .OnComplete(() => ReverseTweenY());
    }

    private void ReverseTweenX()
    {
        transform.DOMoveX(initialPosition.x - moveDistance.x, tweenDuration)
            .SetEase(easeType)
            .OnComplete(() => StartTween());
    }

    private void ReverseTweenY()
    {
        transform.DOMoveY(initialPosition.y - moveDistance.y, tweenDuration)
            .SetEase(easeType)
            .OnComplete(() => StartTween());
    }
}
