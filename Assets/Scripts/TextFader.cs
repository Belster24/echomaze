using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFader : MonoBehaviour
{
    public float fadeDuration = 2f;  // The duration in seconds for the fade effect
    public TextMeshProUGUI textToFade;         // Reference to the Text component that you want to fade

    private CanvasGroup canvasGroup;
    private float currentAlpha;
    private float fadeTimer;
    private bool isFading;

    private void Start()
    {
        // Get the CanvasGroup component from the GameObject or add one if not already present
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        // Set the initial alpha value of the text
        currentAlpha = textToFade.color.a;

        // Start the fading effect
        StartFade();
    }

    private void Update()
    {
        if (isFading)
        {
            fadeTimer += Time.deltaTime;

            // Calculate the normalized fade progress
            float normalizedProgress = fadeTimer / fadeDuration;

            // Update the alpha value of the text based on the fade progress
            float newAlpha = Mathf.Lerp(currentAlpha, 0f, normalizedProgress);
            textToFade.color = new Color(textToFade.color.r, textToFade.color.g, textToFade.color.b, newAlpha);

            if (fadeTimer >= fadeDuration)
            {
                // Fade effect completed
                isFading = false;
                currentAlpha = newAlpha;
            }
        }
    }

    public void StartFade()
    {
        fadeTimer = 0f;
        isFading = true;
    }
}
