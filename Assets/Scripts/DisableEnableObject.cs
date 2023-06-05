using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DisableEnableObject : MonoBehaviour
{
    public List<GameObject> objectsToDisableEnable;
    public float disableDuration = 3f; // Duration in seconds
    public float enableDelay = 1f; // Delay before enabling the GameObjects again

    private void Start()
    {
        StartCoroutine(DisableEnableRoutine());
    }

    private IEnumerator DisableEnableRoutine()
    {
        // Disable all the GameObjects in the list
        foreach (var obj in objectsToDisableEnable)
        {
            obj.tag = "Untagged";
            obj.GetComponent<Light2D>().color = Color.green;
            obj.GetComponent<SpriteRenderer>().color = Color.green;
            obj.GetComponent<BoxCollider2D>().enabled = false;
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(disableDuration);


        foreach (var obj in objectsToDisableEnable)
        {
            obj.tag = "enemy";
            obj.GetComponent<Light2D>().color = Color.red;
            obj.GetComponent<SpriteRenderer>().color = Color.red;
            obj.GetComponent<BoxCollider2D>().enabled = true;
        }

        yield return new WaitForSeconds(disableDuration);

        StartCoroutine(DisableEnableRoutine());

    }
    
}
