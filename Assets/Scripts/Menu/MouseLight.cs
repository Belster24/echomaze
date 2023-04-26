using UnityEngine;

public class MouseLight : MonoBehaviour
{
    private Light mouseLight;

    void Start()
    {
        mouseLight = GetComponent<Light>();

    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }
}
