using UnityEngine;

public class CircleController : MonoBehaviour
{
    public GameObject circlePrefab; // Reference to the circle prefab
    public float growthRate = 1.0f; // Rate at which the circle grows
    public float fadeTime = 1.0f; // Time it takes for the circle to fade out
    private GameObject circleInstance; // Reference to the created circle instance
    private float fadeTimer = 0.0f; // Timer to keep track of the fade time

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Instantiate the circle prefab at the player's position
            circleInstance = Instantiate(circlePrefab, transform.position, Quaternion.identity);

            // Set the scale of the circle to 0 initially
            circleInstance.transform.localScale = Vector3.zero;

            // Reset the fade timer
            fadeTimer = 0.0f;
        }

        if (circleInstance != null)
        {
            // Increase the scale of the circle over time
            circleInstance.transform.localScale += new Vector3(growthRate, growthRate, 0) * Time.deltaTime;

            // Update the fade timer
            fadeTimer += Time.deltaTime;

            // Calculate the alpha value of the circle based on the fade time
            float alpha = Mathf.Lerp(1.0f, 0.0f, fadeTimer / fadeTime);

            // Update the circle's alpha value
            Color color = circleInstance.GetComponent<SpriteRenderer>().color;
            color.a = alpha;
            circleInstance.GetComponent<SpriteRenderer>().color = color;

            // Destroy the circle instance if the fade time has elapsed
            if (fadeTimer >= fadeTime)
            {
                Destroy(circleInstance);
            }
        }
    }
}
