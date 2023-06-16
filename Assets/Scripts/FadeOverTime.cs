using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOverTime : MonoBehaviour
{
    public float fadeDuration = 5f; // Duration of the fade in seconds

    private float timer; // Timer to keep track of the elapsed time

    private void Start()
    {
      
        timer = 0f;
    }

    private void Update()
    {
        // Increase the timer based on the time since the last frame
        timer += Time.deltaTime;

        // Calculate the current alpha value based on the elapsed time
        float currentAlpha = 1f - Mathf.Clamp01(timer / fadeDuration);

        // Update the material's alpha value
        Color color = gameObject.GetComponent<Image>().color;
        color.a = currentAlpha;
        gameObject.GetComponent<Image>().color = color;


        // Destroy the object if the fade is complete
        if (currentAlpha <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
