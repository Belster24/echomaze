using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]AudioClip wallSound;
    [SerializeField] GameObject door;

    [SerializeField]int lockCount = 0;

    // Start is called before the first frame update
    void Start()
    {
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
            lockCount++;
            if (lockCount >= 2)
            {
                door.GetComponent<Light2D>().color = Color.green;
                door.GetComponent<Door>().isLocked = false;

            }

        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("level_1");
        }
    }
}
