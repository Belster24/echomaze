using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]AudioClip wallSound;
    [SerializeField] GameObject door;
    [SerializeField] GameObject bellAndDoorManager;

    [SerializeField]int lockCount = 0;
    GameManager gameManager;
    [SerializeField]Transform spawn;
    public bool startTimer;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.CompareTag("wall"))
        {
            audioSource.PlayOneShot(wallSound);
        }
        else if (collision.gameObject.CompareTag("lock"))
        {
            Destroy(collision.gameObject);
            bellAndDoorManager.GetComponent<BellAndDoor>().count++; 
        }
        else if (collision.gameObject.CompareTag("door"))
        {
            if (bellAndDoorManager.GetComponent<BellAndDoor>().canEndLevel == true)
                 gameManager.MoveToNextLevel();
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            transform.position = spawn.position;
        }
    }
}
