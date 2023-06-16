using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

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
    [SerializeField]TextMeshProUGUI keyText;
    bool updateText = true;

    private void Start()
    {
      
        audioSource = GetComponent<AudioSource> (); 
        count = 0;
    }

    private void Update()
    {
        if (updateText&&keyText!=null)
            keyText.text = count.ToString() + "/" + locks.Count.ToString();
        if (count == locks.Count) //this will change the door color when all the keys are catched
        {
            Debug.Log("door unlocekd");
           door.GetComponent<Light2D>().color = Color.green;
           
            audioSource.clip = clips[1];
            audioSource.PlayDelayed(1);

            count = 0;
            updateText = false;
            if(keyText != null)
                keyText.text = "Door Unlocked";
            canEndLevel = true;
           
        }
        

    }


    public void playKeySound()
    {
        audioSource.PlayOneShot(clips[0]);
    }


}
