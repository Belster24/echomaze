using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] float moveSpeed;
    [SerializeField] float distanceToSee;
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float distanceHear;
    [SerializeField] Vector3 posMoveEnemy;
    [SerializeField] float rangeEnemyCanGo;
    Vector2 defaultPos;
    Vector2 startPoint;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayAudio", 1f, 1f);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posMoveEnemy, moveSpeed * Time.deltaTime);
        if (Mathf.Abs(Vector2.Distance(Player.transform.position, transform.position)) < distanceToSee)
        {
            posMoveEnemy = Player.transform.position;

        }
        else
        {
            posMoveEnemy = defaultPos;

        }

        float distance = Vector2.Distance(transform.position, Player.transform.position);
        audioSource.volume = Mathf.Clamp(1.0f - (distance / distanceHear), 0.0f, 1.0f);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }

}
