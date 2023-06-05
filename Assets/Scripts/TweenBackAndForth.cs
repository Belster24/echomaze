using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenBackAndForth : MonoBehaviour
{
    public Vector2 moveDistance = new Vector2(1f, 1f); // Distance to move in each axis
    public float tweenDuration = 1f; // Duration of each tween
    public Ease easeType = Ease.Linear; // Type of easing to use
    public int numLoops = -1; // Number of loops (-1 for infinite loops)
    public LoopType loopType = LoopType.Yoyo; // Type of loop
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
            .SetLoops(numLoops, loopType);

        // Tween the object back and forth in the y axis
        transform.DOMoveY(initialPosition.y + moveDistance.y, tweenDuration)
            .SetEase(easeType)
            .SetLoops(numLoops, loopType);
    }

  
}
