using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EntityBell : MonoBehaviour
{
    public float bellLength = 5f;
    private bool triggered;
    private CircleInstantiator circleInstantiator;
    public CinemachineVirtualCamera virtualCamera;
    public Light2D light;

    private void Start()
    {
        circleInstantiator = GetComponent<CircleInstantiator>();
        InvokeRepeating("InvokeCircleInstantiator", 0f, 4f);
    }

    private void InvokeCircleInstantiator()
    {
        circleInstantiator.Invoking();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine("PlayBell");
        }
    }

    private IEnumerator PlayBell()
    {
        Debug.Log("yes madame, bell");
        virtualCamera.gameObject.SetActive(true);
        light.gameObject.SetActive(true);
        light.intensity = Mathf.Lerp(0, 0.6f, bellLength / 5);

        yield return new WaitForSeconds(bellLength);

        virtualCamera.gameObject.SetActive(false);
        triggered = false;
        StartCoroutine(DecreaseLightIntensity(bellLength / 3f));
    }

    private IEnumerator DecreaseLightIntensity(float duration)
    {
        float t = 0f;
        float startIntensity = light.intensity;
        while (t < duration)
        {
            t += Time.deltaTime;
            float lerpValue = Mathf.Clamp01(t / duration);
            light.intensity = Mathf.Lerp(startIntensity, 0f, lerpValue);
            yield return null;
        }
        light.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}