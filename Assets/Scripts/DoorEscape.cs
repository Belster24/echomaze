using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEscape : MonoBehaviour
{
    public bool canEndLevel;
    // Start is called before the first frame update
    void Start()
    {
        canEndLevel = false;    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canEndLevel)
            {
                Debug.Log("ended");
            }
        }
    }
}
