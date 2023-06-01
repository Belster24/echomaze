using UnityEngine;

public class Lock : MonoBehaviour
{
    AudioSource audioSource;
     GameObject Player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        InvokeRepeating("PlayAudio", 1f, 1f);
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        audioSource.volume = Mathf.Clamp(1.0f - (distance / 20.0f), 0.0f, 1.0f);
    }
    void PlayAudio()
    {
        audioSource.Play();
    }

    private void OnDestroy()
    {  
      gameObject.GetComponentInParent<BellAndDoor>().playKeySound();
    }


}
