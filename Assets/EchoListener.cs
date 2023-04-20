using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EchoListener : MonoBehaviour
{
    [SerializeField] GameObject player;
    private bool isListening = false;
    

    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.tag == "Player")
        CheckForEcho();
        
    }

    void CheckForEcho()
    {
         var controller = player.GetComponent<Controller>();
         if (Input.GetKeyDown(KeyCode.Space) && !isListening)
         {
             isListening = true;
             ListenerAction();
         }
    }

    void ListenerAction()
    {
        Debug.Log("Listener listens!");
    }

   
}
