using System;
using Unity.VisualScripting;
using UnityEngine;


public class PeriodicBeeper: MonoBehaviour
{
    [SerializeField]float period = 2f;
    private AudioSource source;
    private Animator _animator;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        InvokeRepeating("Play",period,period);

    }

    void Play()
    {
        source.Play();
        _animator.SetTrigger("beep");
    }

    void Trigger()
    {
        gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            Invoke("Trigger",period);
        }
        
    }
}
