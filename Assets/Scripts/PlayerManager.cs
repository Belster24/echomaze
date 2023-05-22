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

    // Start is called before the first frame update
    void Start()
    {
        bellAndDoorManager = GameObject.FindGameObjectWithTag("belldoormanager");
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

            //else if (collision.gameObject.CompareTag("enemy"))
            //{
            //    SceneManager.LoadScene("level_1");
            //}
        }
}
