using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject Player;

    private void Start()
    {
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
        audioSource.PlayOneShot(clip);
    }

    private void OnDestroy()
    {
        gameObject.GetComponentInParent<BellAndDoor>().playKeySound();
    }


}
