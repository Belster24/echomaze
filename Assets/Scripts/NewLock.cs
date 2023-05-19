using System.Collections;
using Shapes2D;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class NewLock : MonoBehaviour
{

    public GameObject targetObject; // Reference to the game object with Light2D component

    private Light2D targetLight;


    private void Start()
    {
        // Get the Light2D component from the target object
        targetLight = targetObject.GetComponent<Light2D>();

        if (targetLight == null)
        {
            Debug.LogError("Target object does not have Light2D component.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Au");

        if (gameObject.GetComponent<UnlockTest>().enabled == false)
            StartCoroutine(enable());

    }


    IEnumerator enable()
    {
        //  gameObject.GetComponent<Shape>().settings.fillColor2 = GetComponent<Light2D>().color;
        gameObject.GetComponent<UnlockTest>().enabled = true;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnlockTest>().enabled = false;
    }

    private void Update()
    {
        if (gameObject.GetComponent<UnlockTest>().enabled == true)
        {
            //Debug.Log("Unlocked");

            targetLight.color = Color.green;

        }
        else
        {
            //Debug.Log("Locked");

            targetLight.color = Color.red;
        }
    }

}
