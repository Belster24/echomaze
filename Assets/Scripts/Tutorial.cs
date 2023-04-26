using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [SerializeField]AudioClip[] clip = new AudioClip[3];

    public void enemySound()
    {
        audioSource.PlayOneShot(clip[0]);
    }
      public void wallHitSound()
    {
        audioSource.PlayOneShot(clip[1]);
    }
      public void keySound()
    {
        audioSource.PlayOneShot(clip[2]);
    }


}
