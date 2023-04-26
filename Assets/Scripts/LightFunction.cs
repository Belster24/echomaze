using System.Collections;
using Shapes2D;
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
        //  gameObject.GetComponent<Shape>().settings.fillColor2 = GetComponent<Light2D>().color;
        gameObject.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Light2D>().enabled = false;
        gameObject.GetComponent<Shape>().settings.fillColor2 = Color.black;
    }


    private void OnDisable()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
        
    }
}
