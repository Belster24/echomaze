using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class LightFunction : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public void enableLight()
    {
        if(gameObject.GetComponent<Light2D>().enabled == false)
            StartCoroutine(enable());
    }

    IEnumerator enable()
    {
        gameObject.GetComponent<SpriteRenderer>().color = GetComponent<Light2D>().color;
        gameObject.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Light2D>().enabled = false;
    }


    private void OnDisable()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
        
    }
}
