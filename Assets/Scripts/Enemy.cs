using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] float moveSpeed;
    [SerializeField] float distanceToSee;
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float distanceHear;
    [SerializeField] Vector2 rangeStart;
    [SerializeField] Vector2 rangeEnd;
    [SerializeField]Vector3 posMoveEnemy;
    Vector2 startPoint;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayAudio", 1f, 1f);
        rangeStart.x = transform.position.x-10f;
        rangeEnd.x = transform.position.x+10f;
        rangeStart.y = transform.position.y - 10f;
        rangeEnd.y = transform.position.y + 10f;    
        posMoveEnemy.x = Random.Range(rangeStart.x, rangeEnd.x);
        posMoveEnemy.y = Random.Range(rangeStart.y, rangeEnd.y);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posMoveEnemy, moveSpeed * Time.deltaTime);
        //Vector2 objectVector = Player.transform.position - transform.position;
        //float dot = Vector2.Dot(objectVector, Vector2.up);
        //if (dot > 1)
        //{
        //    audioSource.panStereo = 1f;
        //}
        //else if (dot < -1)
        //{
        //    audioSource.panStereo = -1f;
        //}
        //else
        //{

        //    audioSource.panStereo = 0f;
        //}
        if ( Mathf.Abs(Vector2.Distance(Player.transform.position, transform.position)) < distanceToSee )
        {
            posMoveEnemy = Player.transform.position;

        }
        else        
        {
            if (Vector2.Distance(transform.position, posMoveEnemy) <= 5f)
            {
                posMoveEnemy.x = Random.Range(rangeStart.x, rangeEnd.x);
                posMoveEnemy.y = Random.Range(rangeStart.y, rangeEnd.y);
            }

        }

        float distance = Vector2.Distance(transform.position, Player.transform.position);
        audioSource.volume = Mathf.Clamp(1.0f - (distance / distanceHear), 0.0f, 1.0f);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }

}
