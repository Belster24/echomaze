using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NewDoorUnlocker : MonoBehaviour
{

    public GameObject targetObject, doorObject; // Reference to the game object with Light2D component

 

    private Light2D targetLight;
    // Start is called before the first frame update
    void Start()
    { 
        
        // Get the Light2D component from the target object
        targetLight = targetObject.GetComponent<Light2D>();

    }

    void Update()
    {

        if (targetLight.color == Color.green)
        {
            Debug.Log("Color of active unlocker is green.");


            doorObject.GetComponent<Door>().isLocked = false;

        }
        else
        {
            Debug.Log("Isnt green");

            doorObject.GetComponent<Door>().isLocked = true;
        }

        if (GameObject.FindWithTag("activeLock") != null)
        {
            Debug.Log("There is an active lock");
        }

    }
}
