using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject Player;
    [SerializeField]List<AudioListener> soundableObject = new List<AudioListener>();
    [SerializeField] GameObject activeObject;
    [SerializeField] float hearingDistance;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayAudio", 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        audioSource.volume = Mathf.Clamp(1.0f - (distance / hearingDistance), 0.0f, 1.0f);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}
