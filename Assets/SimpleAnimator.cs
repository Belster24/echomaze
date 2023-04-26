using UnityEngine;

public class SimpleAnimator : MonoBehaviour
{
    public float amplitudeY = 0.5f; // the distance the object will move up and down
    public float amplitudeX = 0.5f; // the distance the object will move up and down

    public float frequency = 1f; // the speed at which the object will move up and down

    private Vector3 startPos; // the starting position of the object

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newY = startPos.y + amplitudeY * Mathf.Sin(Time.time * frequency);
        float newX = startPos.x + amplitudeX * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}