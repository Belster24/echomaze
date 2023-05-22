using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BellAndDoor : MonoBehaviour
{
    [SerializeField]List <GameObject> bells = new List <GameObject> ();
    [SerializeField] GameObject door;
    AudioSource audioSource;
    [SerializeField] AudioClip []clips = new AudioClip [2];
    public int count;

    private void Start()
    {
        audioSource = GetComponent<AudioSource> (); 
        count = 0;
    }

    private void Update()
    {
        if (count == bells.Count)
        {
           door.gameObject.GetComponent<Light2D>().color = Color.green;
            audioSource.clip = clips[1];
            audioSource.PlayDelayed(1);
            count = 0;
        }
    }


    public void playKeySound()
    {
        audioSource.PlayOneShot(clips[0]);
    }


}
