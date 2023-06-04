using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BellAndDoor : MonoBehaviour
{
    [SerializeField]List <GameObject> locks = new List <GameObject> ();
    [SerializeField] GameObject door;
    AudioSource audioSource;
    [SerializeField] AudioClip []clips = new AudioClip [2];
    [SerializeField]GameManager gameManager;
    [HideInInspector]
    public int count;
    public bool canEndLevel = false;

    private void Start()
    {
      
        audioSource = GetComponent<AudioSource> (); 
        count = 0;
    }

    private void Update()
    {
        if (count == locks.Count) //this will change the door color when all the keys are catched
        {
           door.gameObject.GetComponent<Light2D>().color = Color.green;
           
            audioSource.clip = clips[1];
            audioSource.PlayDelayed(1);
            count = 0;
            canEndLevel = true;
        }
    }


    public void playKeySound()
    {
        audioSource.PlayOneShot(clips[0]);
    }


}
