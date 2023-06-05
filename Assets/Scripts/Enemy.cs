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
    public Vector2 defaultPos;
    public Vector2 startPoint;
    public Vector2 posNow;
    public bool toBack = false;

    GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayAudio", 1f, 1f);
       
    }

    // Update is called once per frame
    void Update()
    {
        posNow = transform.position;

        transform.position = Vector2.MoveTowards(transform.position, posMoveEnemy, moveSpeed * Time.deltaTime);
        if (Mathf.Abs(Vector2.Distance(Player.transform.position, transform.position)) < distanceToSee)
        {
            posMoveEnemy = Player.transform.position;

        }
        else
        {

            if (posNow == defaultPos || toBack)
            {
                toBack = true;
                posMoveEnemy = startPoint;

                if (posNow == startPoint)
                {
                    toBack = false;
                }
            }
            if (!toBack)
            {
                posMoveEnemy = defaultPos;

            }


        }

        

        float distance = Vector2.Distance(transform.position, Player.transform.position);
        audioSource.volume = Mathf.Clamp(1.0f - (distance / distanceHear), 0.0f, 1.0f);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")){

            Debug.Log("Mam te");
            gameManager.EnemyHit();

        }


    }

}
