using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoListener : MonoBehaviour
{
    [SerializeField] GameObject player;
    

    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.tag == "Player")
        CheckForEcho();
        
    }

    void CheckForEcho()
    {
        player.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
