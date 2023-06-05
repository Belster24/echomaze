using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                obj.SetActive(false);
            }

            // Wait for the specified duration
            yield return new WaitForSeconds(disableDuration);

        
            foreach (var obj in objectsToDisableEnable)
            {
                Debug.Log("s");
                obj.SetActive(true);
            }

            yield return new WaitForSeconds(disableDuration);

        StartCoroutine(DisableEnableRoutine());

    }
    
}
