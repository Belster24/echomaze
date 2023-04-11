using System.Collections;
using UnityEngine;

public class CircleGenerator : MonoBehaviour {

    public SpriteRenderer circlePrefab; // The circle prefab to generate
    private SpriteRenderer circle1;
    private SpriteRenderer circle2;

    public float waveSpeed = 2f; // The speed of the wave effect
    public float circleRadius = 5f; // The radius of the circles
    public float fadeOutTime = 0.3f; // The time it takes for the circles to fade out
    public float fadeOpacity = 0.1f;

    public void AnimateCircles () {
        // Generate two circles as child game objects of this game object
        circle1 = Instantiate(circlePrefab, transform.position, Quaternion.identity, transform);
        circle2 = Instantiate(circlePrefab, transform.position, Quaternion.identity, transform);
        circle2.transform.localScale = Vector3.one *2;

        // Start the wave animation coroutine
        StartCoroutine(WaveAnimation());
        
    }

    IEnumerator WaveAnimation () {
        float t = 0f;
        while (t < fadeOutTime) {
            // Set the scale of the circles to match the circle radius
            if (circle1 != null && circle2 != null) {
                circle1.transform.localScale = Vector3.one * circleRadius * t;
                circle2.transform.localScale = Vector3.one * circleRadius * t;
            }
            
            Color fadeColor = circle1.color;
            fadeColor.a = Mathf.Clamp01(fadeColor.a - fadeOpacity * Time.deltaTime);
            circle1.color = fadeColor;
            circle2.color = fadeColor;

            t += Time.deltaTime;
            yield return null;
        }
        // Destroy the circles once they have faded out
        if (circle1 != null) {
            Destroy(circle1.gameObject);
        }
        if (circle2 != null) {
            Destroy(circle2.gameObject);
        }
    }
}